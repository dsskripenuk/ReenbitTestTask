using Microsoft.AspNetCore.Mvc;
using Microsoft.WindowsAzure.Storage.Blob;
using Microsoft.WindowsAzure.Storage;
using TestTask.Services;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("api/fileupload")]
    public class FileUploadController : ControllerBase
    {
        private IBlobService _blobService;

        public FileUploadController(IBlobService blobService)
        {
            _blobService = blobService;
        }

        [HttpPost(""), DisableRequestSizeLimit]
        public async Task<ActionResult> UploadFile()
        {
            IFormFile file = Request.Form.Files[0];
            if (file == null)
            {
                return BadRequest();
            }

            var result = await _blobService.UploadFileBlobAsync(
                    "files",
                    file.OpenReadStream(),
                    file.ContentType,
                    file.FileName);

            var toReturn = result.AbsoluteUri;

            return Ok(new { path = toReturn });
        }
    }
}

