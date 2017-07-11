using LeGiaGrass.Models;
using LeGiaGrass.Services.IServices;
using LeGiaGrass.Services.IRepository;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;

namespace LeGiaGrass.Services.Services


{
    public class CommunicationService : ICommunicationService
    {
        private readonly IOptions<AppConfiguration> _appConfiguration;
        private readonly ICompanyRepository _companyRepo;
        public CommunicationService(IOptions<AppConfiguration> appConfiguration, ICompanyRepository companyRepo)
        {
             _appConfiguration = appConfiguration;
            _companyRepo = companyRepo;
        }

       /// <summary>
        /// When an notification email that someone is trying to contact you.
        /// </summary>
        public OperationResult<ContactViewModel> SendContactEmailNotification(ContactViewModel model)
        {
            var company = _companyRepo.GetCompany();

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_appConfiguration.Value.SiteTitle + " - Liên Hệ", model.Email));
            message.To.Add(new MailboxAddress(_appConfiguration.Value.SiteTitle + " - Liên Hệ", !string.IsNullOrEmpty(company?.Email) ? company?.Email : _appConfiguration.Value.EmailUsername));
            message.Subject = _appConfiguration.Value.SiteTitle + " - Liên Hệ: " + model.Subject + " " + model.Service;
            message.Body = new TextPart("html")
            {
                Text = $"<p>Lời nhắn được gửi từ: {model.Name} ({model.Email})</p><p>Điện Thoại:</p><p>{model.Phone}</p><p>Địa Chỉ:</p><p>{model.Address}</p><p>Nội Dung:</p><p>{model.Message}</p>"
            };

            try
            {
                using (var client = new SmtpClient())
                {
                    client.Connect(_appConfiguration.Value.EmailHost, Convert.ToInt32(_appConfiguration.Value.EmailPort), false);
                    client.Authenticate(_appConfiguration.Value.EmailUsername, _appConfiguration.Value.EmailPassword);
                    client.Send(message);
                    client.Disconnect(true);
                    return new OperationResult<ContactViewModel>(model, OperationStatus.Ok);
                }
            }
            catch (Exception)
            {
                // TODO: Log
                return new OperationResult<ContactViewModel>(model, OperationStatus.Error);
            }
        }
    }
}