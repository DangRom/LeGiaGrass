using LGG.Core.Dtos;
using LGG.Core.Models;
using System.Collections.Generic;


namespace LGG.Core.Repositories
{
    public interface ITestimonialRepository
    {
        IEnumerable<Testimonial> GetAll();
        Testimonial GetById(int id);
        Testimonial Add(Testimonial tes);
        void Update(TestimonialDto tes);
        void Remove(int id);
    }
}
