using AutoMapper;
using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using LGG.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LGG.Persistence.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        /// <summary>
        /// Get all tags
        /// </summary>
        /// <returns>Collection of tags</returns>
        public IEnumerable<TagDto> GetAll()
        {
            return _tagRepository.GetAll()
                .Select(Mapper.Map<Tag, TagDto>)
                .OrderBy(x => x.Name)
                .ToList();
        }

        /// <summary>
        /// Get a tag name, based on tagUrl, from a collection tags
        /// </summary>
        /// <param name="tagUrl">tag url to find match against</param>
        /// <param name="tags">Collection of tags to search for match</param>
        /// <returns>TagDto name</returns>
        public string GetTagNameFromTagUrlInTagCollection(string tagUrl, List<TagDto> tags)
        {
            foreach (var tag in tags)
            {
                if (tagUrl != tag.Url) continue;
                return tag.Name;
            }
            return "";
        }

        /// <summary>
        /// Get Tag by id
        /// </summary>
        /// <param name="id">Tag id</param>
        /// <returns>Tag Object</returns>
        public TagDto GetById(int id)
        {
            return Mapper.Map<Tag, TagDto>(_tagRepository.GetById(id));
        }

        /// <summary>
        /// Create Tag record
        /// If a Name is not provided, set Name and URL to a GUID
        /// </summary>
        /// <param name="tag">Tag</param>
        public TagDto Add(TagDto tag)
        {
            if (tag.Name == null)
            {
                tag.Name = Guid.NewGuid().ToString();
                tag.Url = tag.Name;
            }

            var response = _tagRepository.Add(Mapper.Map<TagDto, Tag>(tag));
            tag.TagId = response.TagId;
            return tag;
        }

        /// <summary>
        /// Update Tag record
        /// </summary>
        /// <param name="tag">Updated Tag</param>
        public void Update(TagDto tag)
        {
            _tagRepository.Update(tag);
        }

        /// <summary>
        /// Delete Tag record based on id
        /// </summary>
        /// <param name="id">Tag Id</param>
        public void Remove(int id)
        {
            _tagRepository.Remove(id);
        }

        /// <summary>
        /// Get paged collection of tags
        /// </summary>
        /// <param name="count">Number of tags in page</param>
        /// <param name="page">Page of tags</param>
        /// <returns>Count of tags starting at page</returns>
        public IEnumerable<TagDto> GetAllPaged(int count = 10, int page = 1)
        {
            return _tagRepository.GetAllPaged(count, page).Select(Mapper.Map<Tag, TagDto>);
        }

        public bool CheckName(string name)
        {
            return _tagRepository.CheckName(name);
        }
    }
}
