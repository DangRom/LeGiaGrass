using AutoMapper;
using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using LGG.Core.Services;

namespace LGG.Persistence.Services
{
    public class PostTagService : IPostTagService
    {
        private readonly IPostTagRepository _postTagRepository;

        public PostTagService(IPostTagRepository postTagRepository)
        {
            _postTagRepository = postTagRepository;
        }

        /// <summary>
        /// Add a new PostTag record
        /// </summary>
        /// <param name="postTag">Compound Key</param>
        /// <returns>Qualified PostTagDto</returns>
        public PostTagDto Add(PostTagDto postTag)
        {
            var entity = _postTagRepository.Add(Mapper.Map<PostTagDto, PostTag>(postTag));
            postTag.PostTagId = entity.PostTagId;
            return postTag;
        }

        /// <summary>
        /// Delete a PostTag by compound key
        /// </summary>
        /// <param name="postTag">Compound Key</param>
        public void Delete(PostTagDto postTag)
        {
            _postTagRepository.RemoveByCompound(Mapper.Map<PostTagDto, PostTag>(postTag));
        }
    }
}
