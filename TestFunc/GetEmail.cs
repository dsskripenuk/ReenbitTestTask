using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestFunc
{
    public class GetEmail
    {
        string email;
        [FunctionName("GetEmail")]
        public async Task<IActionResult> Run(
        [HttpTrigger(AuthorizationLevel.Function, "post", Route = null)] HttpRequest req,
        ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            // Read the email address from the request body
            string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            dynamic data = JsonConvert.DeserializeObject(requestBody);
            email = data.email;

            log.LogInformation($"Received email address: {email}");

            // Process the userEmail (e.g., send an email)

            return new OkObjectResult("Email received and processed successfully.");
        }

        public string Get()
        {
            return email;
        }
    }
}
