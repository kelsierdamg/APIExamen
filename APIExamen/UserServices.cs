using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Http.Json;

namespace APIExamen
{
    public class UserServices
    {
        private readonly HttpClient _http = new HttpClient();

        public UserServices()
        {
            _http = new HttpClient
            {
                Timeout = TimeSpan.FromSeconds(5)
            };
        }

        public async Task<List<User>> GetUsersAsync()
        {
            try
            {
                var url = "https://jsonplaceholder.typicode.com/users";
                var users = await _http.GetFromJsonAsync<List<User>>(url);
                return users ?? new List<User>();
            }
            catch (Exception ex)
            {
                throw new Exception("La API está caída", ex);
            }
        }
    }
}
