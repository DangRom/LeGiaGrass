using LGG.Core.Dtos;
using LGG.Core.Helpers;
using LGG.Core.ViewModels;

namespace LGG.Core.Services
{
    /* Use MailKit */
    public interface ICommunicationService
    {
        OperationResult<ContactViewModel> SendContactEmailNotification(ContactViewModel model);
        OperationResult<ContactDto> SignUpToMailingList(SignUpViewModel model);
    }
}
