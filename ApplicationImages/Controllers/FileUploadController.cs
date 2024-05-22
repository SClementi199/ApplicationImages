using DBLayer.DTO;
using DBLayer.Interface;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.InterfaceService;

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
            var res = await _uploadService.GetByIdAsync(id);

            return Ok(res); 
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<FileContentResult>>> GetAllImage()
        {
            var list = await _uploadService.GetAllAsync();
            return Ok(list);
        }



    }
}
