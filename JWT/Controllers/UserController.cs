using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using RegisterLoginJWT.Model.DTOs;
using RegisterLoginJWT.Service.Interfaces;

namespace RegisterLoginJWT.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IRegisterServices _registerServices;
        private readonly ILoginServices _loginServices;
        private readonly IConfiguration _configuration;

        public UserController(IRegisterServices registerServices, ILoginServices loginServices, IConfiguration configuration)
        {
            _registerServices = registerServices;
            _loginServices = loginServices;
            _configuration = configuration;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResultDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Register([FromBody] RegisterUserDTO registerUserDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _registerServices.Execute(registerUserDTO.UserName, registerUserDTO.Password);
                if(result != null)
                {
                    var convertResultJson = JsonConvert.SerializeObject(result);
                    return Content(convertResultJson, "application/json");
                }
                else
                {
                    throw new Exception("Usuario no valido");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("Login")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(LoginResultDTO))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(string))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(string))]
        public async Task<IActionResult> Login(string userName, string password)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var result = await _loginServices.Execute(userName, password);
                if (result != null)
                {
                    var convertResultJson = JsonConvert.SerializeObject(result);
                    return Content(convertResultJson, "application/json");
                }
                else
                {
                    throw new Exception("Usuario o contraseña incorrecta");
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}
