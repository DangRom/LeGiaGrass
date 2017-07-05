using LGG.Core.Dtos;
using LGG.Core.Models;
using LGG.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace LGG.Persistence.Repositories
{
    public class TestimonialRepository : ITestimonialRepository
    {
        private readonly ApplicationDbContext _context;

        public TestimonialRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Testimonial Add(Testimonial tes)
        {
            _context
               .Testimonials
               .Add(tes);
            _context.SaveChanges();

            return tes;
        }

        public IEnumerable<Testimonial> GetAll()
        {
            return _context
                      .Testimonials
                      .ToList();
        }

        public Testimonial GetById(int id)
        {
            return _context
                   .Testimonials
                   .FirstOrDefault(x => x.Id == id);
        }

        public void Remove(int id)
        {
            var entity = _context
               .Testimonials
               .FirstOrDefault(x => x.Id == id);

            _context.Testimonials.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(TestimonialDto tes)
        {
            var entity = _context
               .Testimonials
               .FirstOrDefault(x => x.Id == tes.Id);

            entity.Name = tes.Name;
            entity.Position = tes.Position;
            entity.Content = tes.Content;
            entity.SmallImage = tes.SmallImage;

            _context.SaveChanges();
        }
    }
}
