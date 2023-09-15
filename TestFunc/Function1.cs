using System;
using System.IO;
using System.Net.Mail;
using System.Net;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Host;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Extensions.Http;

namespace TestFunc
{
    public class Function1
    {
        [FunctionName("Function1")]
        public static void Run([BlobTrigger("files/{name}", Connection = "ConnectionString")] Stream myBlob, string name, ILogger log)
        {
            log.LogInformation($"C# Blob trigger function Processed blob\n Name:{name} \n Size: {myBlob.Length} Bytes");

            //GetEmail email = new GetEmail();

            SendEmailNotification(name/*, email.Get()*/);

        }

        public static void SendEmailNotification(string blobName)
        {
            string smtpServer = "smtp.gmail.com";
            int smtpPort = 587;
            string smtpUsername = "dsskripenuc770@gmail.com";
            string smtpPassword = "lrhnekmerktwnoxk";

            SmtpClient smtpClient = new SmtpClient(smtpServer)
            {
                Port = smtpPort,
                Credentials = new NetworkCredential(smtpUsername, smtpPassword),
                EnableSsl = true
            };

            MailMessage mailMessage = new MailMessage(smtpUsername, "dsskripenuk770@gmail.com")
            {
                Subject = "New Blob Uploaded",
                Body = $"A new Blob '{blobName}' has been uploaded to your Azure Storage Container.",
            };

                smtpClient.Send(mailMessage);            


        }
    }
}
