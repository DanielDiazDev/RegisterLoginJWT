using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RegisterLoginJWT.Model.DTOs
{
    [Serializable]
    public class RegisterUserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

}
