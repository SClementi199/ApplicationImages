using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.DTO
{
    public class ImageReturnDto
    {
        public string name {  get; set; }
        public FileContentResult image { get; set; }
    }
}
