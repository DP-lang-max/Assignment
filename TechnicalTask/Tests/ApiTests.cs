using TechnicalTask.API;
using System.Net;
using NLog;
using Newtonsoft.Json.Linq;

namespace TechnicalTask.Tests
{
    public class ApiTests
    {
        private ApiClient apiClient;
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        [SetUp]
        public void Setup()
        {
            // Log the setup process
            logger.Info("Setting up API tests");
            // Initialize the API client with the base URL
            apiClient = new ApiClient("https://reqres.in/api");
        }

        [Test]
        public void TestGetUsers()
        {
            // Log the start of the GET /users test
            logger.Info("Testing GET /users endpoint");
            // Call the API to get users with page number 2
            var response = apiClient.GetUsers(2);
            // Assert that the response status code is OK (200)
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.OK));

            var content = response.Content;
            // Assert that the response content is not null or empty
            Assert.That(content, Is.Not.Null.And.Not.Empty, "Response content is null or empty.");

            // Parse the response content to JSON
            var jsonResponse = JObject.Parse(content);
            var users = jsonResponse["data"];
            // Assert that the users data is not null or empty
            Assert.That(users, Is.Not.Null.And.Not.Empty, "No users found in the response.");

            var firstUser = users?.FirstOrDefault();
            // Assert that the first user is not null
            Assert.That(firstUser, Is.Not.Null, "The first user is null.");

            var firstUserId = firstUser?["id"]?.ToString();
            // Assert that the first user's ID is not empty
            Assert.That(firstUserId, Is.Not.Empty, "The first user's ID is empty.");
        }

        [Test]
        public void TestCreateUser()
        {
            // Log the start of the POST /users test
            logger.Info("Testing POST /users endpoint");
            // Call the API to create a new user with name and job
            var response = apiClient.CreateUser("John Doe", "QA Engineer");
            // Assert that the response status code is Created (201)
            Assert.That(response.StatusCode, Is.EqualTo(HttpStatusCode.Created));

            var content = response.Content;
            // Assert that the response content is not null or empty
            Assert.That(content, Is.Not.Null.And.Not.Empty, "Response content is null or empty.");

            // Parse the response content to JSON
            var jsonResponse = JObject.Parse(content);
            var id = jsonResponse["id"]?.ToString();
            var name = jsonResponse["name"]?.ToString();
            var job = jsonResponse["job"]?.ToString();

            // Assert that the response contains an ID
            Assert.That(id, Is.Not.Empty, "The response does not contain an ID.");
            // Assert that the response contains the correct name
            Assert.That(name, Is.EqualTo("John Doe"), "The response does not contain the correct name.");
            // Assert that the response contains the correct job
            Assert.That(job, Is.EqualTo("QA Engineer"), "The response does not contain the correct job.");
        }
    }
}
