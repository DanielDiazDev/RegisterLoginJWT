using RegisterLoginJWT.Blazer.Services.Interfaces;
using RegisterLoginJWT.Model.DTOs;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json.Serialization;
using System.Text;
using Newtonsoft.Json;

namespace RegisterLoginJWT.Blazer.Services
{
    public class UserServices : IUserSevices
    {
        private readonly IHttpClientFactory _clientFactory;
        public UserServices(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<LoginResultDTO> Login(string userName, string password)
        {
            var client = _clientFactory.CreateClient("BackEnd");
            var response = await client.GetAsync($"https://localhost:7175/api/User/Login/?userName={userName}&password={password}");
            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<LoginResultDTO>(content);
            }
            else
            {
                throw new Exception(await response.Content?.ReadAsStringAsync());
            }
        }

        public async Task<LoginResultDTO> RegisterUser(RegisterUserDTO user)
        {
            var client = _clientFactory.CreateClient("BackEnd");
            var data = JsonConvert.SerializeObject(user);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            var response = await client.PostAsync("https://localhost:7175/api/User", content);
            if (response.IsSuccessStatusCode)
            {
                response.EnsureSuccessStatusCode();
                string jsonResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<LoginResultDTO>(jsonResponse);
            }
            throw new Exception(response.RequestMessage.ToString());
        }
        
        
            
    }
}
