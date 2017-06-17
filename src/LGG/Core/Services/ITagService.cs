using LGG.Core.Dtos;
using System.Collections.Generic;

namespace LGG.Core.Services
{
    public interface ITagService
    {
        IEnumerable<TagDto> GetAll();
        IEnumerable<TagDto> GetAllPaged(int count, int page = 1);
        string GetTagNameFromTagUrlInTagCollection(string tagUrl, List<TagDto> tags);
        TagDto GetById(int id);
        TagDto Add(TagDto tag);
        void Update(TagDto tag);
        void Remove(int id);
        bool CheckName(string name);
    }
}
