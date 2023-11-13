using RegisterLoginJWT.Data.Repositories.Interfaces;
using RegisterLoginJWT.Model;

namespace RegisterLoginJWT.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _context;

        public UserRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Add(User user)
        {
             await _context.AddAsync(user);
            return true;
        }

        public async Task<User> Get(string userName, string password)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserName == userName && x.Password == password);

            if(user != null)
            {
                return user;
            }
            return null;
        }

        public bool UserExist(string username)
        {
            return _context.Users.Any(user => user.UserName == username);
        }
    }
}
