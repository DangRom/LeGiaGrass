using LGG.Core.Dtos;
using LGG.Core.Models;
using System.Collections.Generic;

namespace LGG.Core.Repositories
{
    public interface ITagRepository
    {
        IEnumerable<Tag> GetAll();
        IEnumerable<Tag> GetAllPaged(int count, int page);
        Tag GetById(int id);
        Tag Add(Tag tag);
        void Update(TagDto tag);
        void Remove(int id);
        bool CheckName(string name);
    }
}
