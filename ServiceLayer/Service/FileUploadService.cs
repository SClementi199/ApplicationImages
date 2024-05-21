using DBLayer.DTO;
using DBLayer.Interface;
using DBLayer.Model;
using ServiceLayer.InterfaceService;
using Microsoft.AspNetCore.Hosting;
using AutoMapper;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using System.Collections;
using iTextSharp.text.pdf.qrcode;
using System.Drawing;
using Image = System.Drawing.Image;
using System.Net.Mime;
using Newtonsoft.Json;

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
            if (entity.imageData.Length > 0)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await entity.imageData.CopyToAsync(memoryStream);
                    var image = new FileUpload
                    {
                        ImageTitle = entity.name,
                        Files = memoryStream.ToArray()
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

        public async Task<FileUploadDto> GetByIdAsync(int id)
        {
            return null;
        }


        public async Task<FileUpload> GetAllAsync()
        {
            throw new NotImplementedException();
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
