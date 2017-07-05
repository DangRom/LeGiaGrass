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
    public class TestimonialService : ITestimonialService
    {
        private readonly ITestimonialRepository _testimonialRepository;

        public TestimonialService(ITestimonialRepository testimonialRepository)
        {
            _testimonialRepository = testimonialRepository;
        }

        public TestimonialDto Add(TestimonialDto tes)
        {
            if (string.IsNullOrEmpty(tes.Name) || string.IsNullOrEmpty(tes.Position) || string.IsNullOrEmpty(tes.Content))
            {
                tes.Name = Guid.NewGuid().ToString();
                tes.Position = Guid.NewGuid().ToString();
                tes.Content = Guid.NewGuid().ToString();
            }

            var response = _testimonialRepository.Add(Mapper.Map<TestimonialDto, Testimonial>(tes));
            tes.Id = response.Id;

            return tes;
        }

        public IEnumerable<TestimonialDto> GetAll()
        {
            return _testimonialRepository.GetAll()
               .Select(Mapper.Map<Testimonial, TestimonialDto>)
               .ToList();
        }

        public TestimonialDto GetById(int id)
        {
            return Mapper.Map<Testimonial, TestimonialDto>(_testimonialRepository.GetById(id));
        }

        public void Remove(int id)
        {
            _testimonialRepository.Remove(id);
        }

        public void Update(TestimonialDto tes)
        {
            _testimonialRepository.Update(tes);
        }
    }
}
