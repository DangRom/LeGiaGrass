using AutoMapper;
using LGG.Core.Dtos;
using LGG.Core.Helpers;
using LGG.Core.Models;
using LGG.Core.Repositories;
using LGG.Core.Services;
using LGG.Core.ViewModels;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using System;

namespace LGG.Persistence.Services
{
    public class CommunicationService : ICommunicationService
    {
        private readonly IOptions<AppConfiguration> _appConfiguration;
        private readonly IContactRepository _contactRepository;
        private readonly ICompanyService _companyService;
        public CommunicationService(IOptions<AppConfiguration> appConfiguration, IContactRepository contactRepository,
            ICompanyService companyService)
        {
            _appConfiguration = appConfiguration;
            _contactRepository = contactRepository;
            _companyService = companyService;
        }

        /// <summary>
        /// When an notification email that someone is trying to contact you.
        /// </summary>
        public OperationResult<ContactViewModel> SendContactEmailNotification(ContactViewModel model)
        {
            var company = _companyService.GetCompanyFirstOrDefault(false, false, false);

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

        /// <summary>
        /// Sign someone up to the mailing list.
        /// </summary>
        public OperationResult<ContactDto> SignUpToMailingList(SignUpViewModel model)
        {
            if (_contactRepository.GetByEmail(model.Email) != null)
            {
                return new OperationResult<ContactDto>(null, OperationStatus.Error, "This email has already been added to the mailing list.");
            }

            var response = _contactRepository.Add(Mapper.Map<ContactDto, Contact>(new ContactDto { Email = model.Email }));
            return new OperationResult<ContactDto>(Mapper.Map<Contact, ContactDto>(response), OperationStatus.Created);
        }
    }
}
