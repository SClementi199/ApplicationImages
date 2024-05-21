using DBLayer.Context;
using DBLayer.Interface;
using DBLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Repository
{
    public class FileUploadRepository : GenericRepository<FileUpload>, IFileUploadRepository
    {
        public FileUploadRepository(ImageContext context) : base(context)
        {
        }
    }
}
