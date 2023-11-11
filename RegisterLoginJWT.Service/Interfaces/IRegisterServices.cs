using RegisterLoginJWT.Model.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLoginJWT.Service.Interfaces
{
    public interface IRegisterServices
    {
        Task<LoginResultDTO> Execute(string userName, string password);
    }

}
