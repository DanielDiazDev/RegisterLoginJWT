using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RegisterLoginJWT.Data.Repositories.Interfaces;
using RegisterLoginJWT.Model;
using RegisterLoginJWT.Model.DTOs;
using RegisterLoginJWT.Service.Interfaces;
using RegisterLoginJWT.Util;

namespace RegisterLoginJWT.Service
{
    public class RegisterServices : IRegisterServices
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public RegisterServices(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<LoginResultDTO> Execute(string userName, string password)
        {
            if(_unitOfWork.UserRepository.UserExist(userName))
            {
                throw new Exception("El usuario ya existe");
            }
            var passwordEncypted = Encrypt.GetSHA256(password);

            User user = new User()
            {
                UserName = userName,
                Password = passwordEncypted
            };
            _ = await _unitOfWork.UserRepository.Add(user);
            _ = await _unitOfWork.Save();
            return _mapper.Map<LoginResultDTO>(user);
        }

        
    }
}