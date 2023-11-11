using RegisterLoginJWT.Model.DTOs;

namespace RegisterLoginJWT.Blazer.Services.Interfaces
{
    public interface IUserSevices
    {
        Task<LoginResultDTO> RegisterUser(RegisterUserDTO user);
        Task<LoginResultDTO> Login(string userName, string password);
    }
}
