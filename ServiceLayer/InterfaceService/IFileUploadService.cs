using DBLayer.DTO;
using DBLayer.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.InterfaceService
{
    public interface IFileUploadService
    {
        Task<FileUploadDto> GetByIdAsync(int id);
        Task<FileUpload> GetAllAsync();
        Task<FileUpload> AddAsync(FileUploadDto entity);
        Task<FileUpload> RemoveAsync(Guid id);

        Task<FileUpload> Update(FileUpload entity);
    }
}
