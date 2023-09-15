using System;
using System.IO;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;

namespace AzureFunction
{
    public class BlobFunction
    {
        [FunctionName("BlobFunction")]
        public void Run([BlobTrigger("samples-workitems/{files}", Connection = "DefaultEndpointsProtocol=https;AccountName=dsskripenukbloobstorage;AccountKey=n/v7AM0pikR9opkaDqBG1xCaYrrPH8DUfUkCL1yJG3bfqFb5bvnCTxZVtcervlvE/56m/TCQMbxr+AStL+jqiQ==;EndpointSuffix=core.windows.net")]Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");
        }
    }
}
