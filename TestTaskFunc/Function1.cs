using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace TestTaskFunc
{
    public static class Function1
    {
        [FunctionName("Function1")]

        public static void Run(
        [BlobTrigger("files/{name}", Connection = "DefaultEndpointsProtocol=https;AccountName=dsskripenukbloobstorage;AccountKey=8eYvHzc0lESibm/UsM6lIBdMmS5Uwg0say9iyom09v0MXogpfbWbCtcCq1SWuqUoxj5n80lM/vHm+AStPgMCOA==;EndpointSuffix=core.windows.net")] Stream myBlob,
        string name,
        ILogger log)
        {
            log.LogInformation($"C# Blob trigger function processed blob\n Name:{name} \n  Size: {myBlob.Length} Bytes");


            //    public static async Task<IActionResult> Run(
            //    [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            //    ILogger log)
            //{
            //    log.LogInformation("C# HTTP trigger function processed a request.");

            //    string name = req.Query["name"];

            //    string requestBody = await new StreamReader(req.Body).ReadToEndAsync();
            //    dynamic data = JsonConvert.DeserializeObject(requestBody);
            //    name = name ?? data?.name;

            //    string responseMessage = string.IsNullOrEmpty(name)
            //        ? "This HTTP triggered function executed successfully. Pass a name in the query string or in the request body for a personalized response."
            //        : $"Hello, {name}. This HTTP triggered function executed successfully.";

            //    return new OkObjectResult(responseMessage);
            //}
        }
    }
}
