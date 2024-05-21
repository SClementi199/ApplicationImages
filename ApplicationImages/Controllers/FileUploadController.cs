using DBLayer.DTO;
using DBLayer.Interface;
using DBLayer.Model;
using iTextSharp.text.pdf.qrcode;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.InterfaceService;
using System.Collections;
using System.Drawing;
using System.IO;
using System.Net;
using System.Net.Http.Headers;
using System.Threading;

namespace ApplicationImages.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileUploadController : ControllerBase
    {
        private readonly IFileUploadService _uploadService;
        private readonly IUnitOfWork _unitOfWork;

        public FileUploadController(IFileUploadService uploadService, IUnitOfWork unitOfWork)
        {
            _uploadService = uploadService;
            _unitOfWork = unitOfWork;
        }

        [HttpPost]
        public async Task<IActionResult> AddFile([FromForm] FileUploadDto fileUploadDto)
        {
            if (fileUploadDto.imageData == null || fileUploadDto.imageData.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            await _uploadService.AddAsync(fileUploadDto);
            return Ok("Image uploaded successfully.");
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var res = await _unitOfWork.FileUploadRepository.GetByIdAsync(id);


            // Create an HttpResponseMessage with the image data
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.OK);
            response.Content = new StreamContent(new MemoryStream(res.Files));
            response.Content.Headers.ContentType = new MediaTypeHeaderValue("image/jpg");

            return Ok(response);
        }

       

    }
}
