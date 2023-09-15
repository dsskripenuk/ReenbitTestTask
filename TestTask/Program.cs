using Azure.Storage.Blobs;
using Microsoft.Extensions.Configuration;
using System.Configuration;
using TestTask.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped(x => new BlobServiceClient("DefaultEndpointsProtocol=https;AccountName=dsskripenukbloobstorage;AccountKey=n/v7AM0pikR9opkaDqBG1xCaYrrPH8DUfUkCL1yJG3bfqFb5bvnCTxZVtcervlvE/56m/TCQMbxr+AStL+jqiQ==;EndpointSuffix=core.windows.net"));

builder.Services.AddScoped<IBlobService, BlobService>();

builder.Services.AddCors(options => options.AddDefaultPolicy(
    policy =>
    {
        policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
    }
    ));

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseCors();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html"); ;

app.Run();
