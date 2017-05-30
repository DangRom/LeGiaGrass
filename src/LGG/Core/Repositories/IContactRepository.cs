using LGG.Core.Models;

namespace LGG.Core.Repositories
{
    public interface IContactRepository
    {
        Contact Add(Contact contact);
        Contact GetByEmail(string email);
    }
}
