using DBLayer.DTO;
using DBLayer.Interface;
using DBLayer.Model;
using ServiceLayer.InterfaceService;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using System.Drawing;

namespace ServiceLayer.Service
{
    public class FileUploadService : IFileUploadService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public FileUploadService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<FileUpload> AddAsync(FileUploadDto entity)
        {
            //if (entity.imageData.Length > 0)
            //{
            //    using (var memoryStream = new MemoryStream())
            //    {
            //        await entity.imageData.CopyToAsync(memoryStream);
            //        var image = new FileUpload
            //        {
            //            ImageTitle = entity.name,
            //            Files = memoryStream.ToArray()
            //        };
            //        var res = await _unitOfWork.FileUploadRepository.AddAsync(image);
            //        await _unitOfWork.SaveAsync();
            //        return res;
            //    }
            //}
            //else
            //{
            //    return null;
            //}
            if(entity.imageData.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await entity.imageData.CopyToAsync(ms);
                    var fileBytes = ms.ToArray();
                    var base64String = Convert.ToBase64String(fileBytes);
                    var image = new FileUpload
                    {
                        ImageTitle = entity.name,
                        Files = base64String
                    };
                    var res = await _unitOfWork.FileUploadRepository.AddAsync(image);
                    await _unitOfWork.SaveAsync();
                    return res;
                }
            }
            else
            {
                return null;
            }
            
        }

        public async Task<FileUpload> GetByIdAsync(int id)
        {
            var res = await _unitOfWork.FileUploadRepository.GetByIdAsync(id);
            byte[] imageBytes = Convert.FromBase64String(res.Files);
            string imageSrc = Convert.ToBase64String(imageBytes);
            res.Files = imageSrc;

            return res;
        }


        public async Task<IEnumerable<FileUpload>> GetAllAsync()
        {
            var list = await _unitOfWork.FileUploadRepository.GetAllAsync();
            List<FileUpload> res = new List<FileUpload>();
            foreach (var item in list)
            {
                byte[] imageBytes = Convert.FromBase64String(item.Files);
                string imageSrc = Convert.ToBase64String(imageBytes);
                item.Files = imageSrc;
                res.Add(item);
            }

            return res;
        }

        

        public async Task<FileUpload> RemoveAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<FileUpload> Update(FileUpload entity)
        {
            throw new NotImplementedException();
        }
    }
}
