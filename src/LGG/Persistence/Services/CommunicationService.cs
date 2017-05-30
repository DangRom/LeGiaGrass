﻿using AutoMapper;
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

        public CommunicationService(IOptions<AppConfiguration> appConfiguration, IContactRepository contactRepository)
        {
            _appConfiguration = appConfiguration;
            _contactRepository = contactRepository;
        }

        /// <summary>
        /// When an notification email that someone is trying to contact you.
        /// </summary>
        public OperationResult<ContactViewModel> SendContactEmailNotification(ContactViewModel model)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(_appConfiguration.Value.SiteTitle + " - Contact", model.Email));
            message.To.Add(new MailboxAddress(_appConfiguration.Value.SiteTitle + " - Contact", _appConfiguration.Value.EmailUsername));
            message.Subject = _appConfiguration.Value.SiteTitle + " - Contact: " + model.Subject;
            message.Body = new TextPart("html")
            {
                Text = string.Format("<p>Email From: {0} ({1})</p><p>Message:</p><p>{2}</p>", model.Name, model.Email, model.Message)
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
