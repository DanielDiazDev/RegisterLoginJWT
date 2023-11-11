using RegisterLoginJWT.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLoginJWT.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        private readonly ApplicationDbContext _context;

        public UnitOfWork(IUserRepository userRepository, ApplicationDbContext context)
        {
            UserRepository = userRepository;
            _context = context;
        }

        public async Task<int> Save()
            => await _context.SaveChangesAsync();

       

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
