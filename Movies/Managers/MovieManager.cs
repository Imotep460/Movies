using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Movies.Data;
using Newtonsoft.Json;

namespace Movies.Managers
{
    class MovieManager
    {
        private const string ApiUrl = "https://fast-castle-50377.herokuapp.com/"; // Main Url for the API use this to build paths for Api calls.
        private string _authKey = ""; // Use this to store the jwt token.

        public MovieManager()
        {

        }

        private async Task<HttpClient> GetClient()
        {
            HttpClient client = new HttpClient();

            if (string.IsNullOrEmpty(_authKey)) // Check if the _authKey is set.
            {
                try
                {
                    UserItem userItem = new UserItem();
                    // Setup the UserItem as one would in Postman.
                    userItem.identifier = "student";
                    userItem.password = "Student1234";

                    var content = new StringContent(JsonConvert.SerializeObject(userItem), Encoding.UTF8, "application/json");
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json")); // Accept Header.

                    // Build the login Url and attempt a login with the User created in userItem, to get hold of a jwt token.
                    var response = await client.PostAsync(ApiUrl + "auth/local", content);

                    // Ensure that we get a success status code.
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Get the Jwt token from the responseBody and set a new _authKey.
                    _authKey = "Bearer " + JsonConvert.DeserializeObject<LoginUser>(responseBody).jwt;
                }
                catch (Exception error)
                {
                    string.IsNullOrEmpty(_authKey);
                    Console.WriteLine(error);
                }
            }

            client.DefaultRequestHeaders.Add("Authorization", _authKey);
            client.DefaultRequestHeaders.Add("Accept", "application/json");

            return client;
        }

        /// <summary>
        /// Get All the movies.
        /// </summary>
        /// <returns></returns>
        public async Task<IEnumerable<Movie>> GetAllMovies()
        {
            HttpClient client = await GetClient();
            string response = await client.GetStringAsync(ApiUrl + "Movies");
            var result = JsonConvert.DeserializeObject<IEnumerable<Movie>>(response);
            return result;
        }
    }
}
