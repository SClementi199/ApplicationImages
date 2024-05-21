

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;

namespace DBLayer.DTO
{
    public class FileUploadDto
    {
        public string name {  get; set; }
        public IFormFile imageData { get; set; }
    }
}
