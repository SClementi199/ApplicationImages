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
        Task<FileUpload> GetByIdAsync(int id);
        Task<IEnumerable<FileUpload>> GetAllAsync();
        Task<FileUpload> AddAsync(FileUploadDto entity);
        Task<FileUpload> RemoveAsync(Guid id);

        Task<FileUpload> Update(FileUpload entity);
    }
}
