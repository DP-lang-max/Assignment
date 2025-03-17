using RestSharp;
using NLog;

namespace TechnicalTask.API
{
    public class ApiClient
    {
        private RestClient client;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        // Constructor to initialize the API client with a base URL
        public ApiClient(string baseUrl)
        {
            logger.Info($"Initializing API client with base URL: {baseUrl}");
            client = new RestClient(baseUrl);
        }

        // Method to send a GET request to fetch users on a specific page
        public RestResponse GetUsers(int page)
        {
            logger.Info($"Sending GET request to fetch users on page {page}");
            var request = new RestRequest($"/users?page={page}", Method.Get);
            var response = client.Execute(request);
            logger.Info($"Received response: {response.StatusCode}");
            return response;
        }

        // Method to send a POST request to create a new user with a name and job
        public RestResponse CreateUser(string name, string job)
        {
            logger.Info($"Sending POST request to create user: Name={name}, Job={job}");
            var request = new RestRequest("/users", Method.Post);
            request.AddJsonBody(new { name, job });
            var response = client.Execute(request);
            logger.Info($"Received response: {response.StatusCode}");
            return response;
        }
    }
}

