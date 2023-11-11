using RegisterLoginJWT.Model.DTOs;

namespace RegisterLoginJWT.Service.Interfaces
{
    public interface ILoginServices
    {
        Task<LoginResultDTO> Execute( string userName, string password);
    }

}
