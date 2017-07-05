using LGG.Core.Dtos;
using System.Collections.Generic;

namespace LGG.Core.Services
{
    public interface ITestimonialService
    {
        IEnumerable<TestimonialDto> GetAll();
        TestimonialDto GetById(int id);
        TestimonialDto Add(TestimonialDto tes);
        void Update(TestimonialDto tes);
        void Remove(int id);
    }
}
