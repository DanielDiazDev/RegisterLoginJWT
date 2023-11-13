using Microsoft.EntityFrameworkCore;
using RegisterLoginJWT.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLoginJWT.Data.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<bool> Add(User user);
        Task<User> Get(string userName, string password);
        bool UserExist(string username);
    }
}
