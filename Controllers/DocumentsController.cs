using DormAPI.Database.Ado.Common;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;

namespace DormAPI.Controllers
{
    [ApiController]
    [Route("api/document")]
    public class DocumentsController : ControllerBase

    {

        private readonly clsExternalLayer _clsExternalLayerRepo;
        public DocumentsController(clsExternalLayer clsExternalLayerRepo)
        {
            _clsExternalLayerRepo = clsExternalLayerRepo;
        }



        [HttpGet("get")]
        //[Produces("application/pdf")] // Tells Swagger/OpenAPI this returns a PDF file
        [Produces("application/octet-stream")] // Generalized for binary files in Swagger
        public async Task<IActionResult> GetDocumentByPath([FromQuery] int studentId, [FromQuery] string documentName)
        {


            if (string.IsNullOrWhiteSpace(documentName))
            {
                return BadRequest("Document name is required.");
            }

            // "C:\Users\kalum\Desktop\Dorm Graduation Project\DormDocuments\Students\
            // 1\598d3e31-921a-44c8-a3c2-8603f81154dc.pdf"

            var rootPath = Path.GetFullPath(@"C:\Users\kalum\Desktop\Dorm Graduation Project\DormDocuments\Students");
            var studentDirectory = Path.GetFullPath(Path.Combine(rootPath, studentId.ToString()));

            var combinedPath = Path.GetFullPath(Path.Combine(studentDirectory, documentName));

            // Ensure the final path stays strictly inside the targeted student folder
            if (!combinedPath.StartsWith(studentDirectory, StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest("Invalid document path.");
            }


            if (!System.IO.File.Exists(combinedPath))
            {
                return NotFound();
            }


            var fileBytes = await System.IO.File.ReadAllBytesAsync(combinedPath);

            //var contentType = "application/pdf";


            // Automatically detect the correct content type (e.g., .pdf, .jpg, .docx, .png)
            var provider = new FileExtensionContentTypeProvider();
            if (!provider.TryGetContentType(combinedPath, out var contentType))
            {
                contentType = "application/octet-stream"; // Fallback for unknown extensions
            }

            var downloadName = Path.GetFileName(combinedPath);
            return PhysicalFile(combinedPath, contentType, fileDownloadName: downloadName);


        }


        // uploading document
        [HttpPost("upload/document/{studentId}/{fileName}")]
        public async Task<IActionResult> UploadDocument(IFormFile file, int studentId, string fileName)
        {

            if (file == null)
            {

                return BadRequest("File is not uploadded");
            }

            else
            {
                Console.WriteLine($"File name: {file.FileName}");
                Console.WriteLine($"File size: {file.Length}");
                Console.WriteLine($"Content type: {file.ContentType}");

                // First, Store the document in the folder 
                var rootPath = @"C:\Users\kalum\Desktop\Dorm Graduation Project\DormDocuments";
                string studentFolder = Path.Combine(
                    rootPath,
                    "Students",
                    studentId.ToString()

                );

                Directory.CreateDirectory(studentFolder);





                var extension = Path.GetExtension(file.FileName).ToLowerInvariant();
                var storedFileName = $"{Guid.NewGuid()}{extension}";

                var filePath = Path.Combine(
                    studentFolder,
                    storedFileName
                );

                await using var stream = new FileStream(
                    filePath,
                    FileMode.Create,
                    FileAccess.Write
                );


                await file.CopyToAsync(stream);

                // Second, Store the path in the Database 
                bool isPathStored = _clsExternalLayerRepo.UploadFilePath(studentId, filePath, fileName, extension);




                return Ok();
            }
        }

    }
}
