using LGG.Core;
using LGG.Core.Repositories;

namespace LGG.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        public IPostRepository Posts { get; private set; }

        private readonly ApplicationDbContext _context;


        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            //Posts = new PostRepository(context);
        }
        public void Complete()
        {
            ///TODO: Save data here
        }
    }
}
