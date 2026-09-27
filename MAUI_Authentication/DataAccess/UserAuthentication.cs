using System.Net.Http.Headers;
using System.Text;

namespace MAUI_Authentication.DataAccess
{
    public class UserAuthentication
    {
        public bool AuthenticateUser(string username, string password)
        {
            using (var client = new HttpClient())
            {
                // Set the base address of the API
                client.BaseAddress = new Uri("http://localhost:43916/");

                // Create the authentication header value
                var authToken = 
                    Convert.ToBase64String(Encoding.UTF8.GetBytes($"{username}:{password}"));
                client.DefaultRequestHeaders.Authorization = 
                    new AuthenticationHeaderValue("Basic", authToken);
                // Set the endpoint to use the Values Controller
                var endpoint = "api/Values";

                // Send the POST request to the API endpoint
                var response = client.GetAsync(endpoint).Result;

                // Check if the response is successful (status code 200)
                return response.IsSuccessStatusCode;
            }
        }
    }
}
