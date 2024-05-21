using DBLayer.Context;
using DBLayer.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBLayer.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ImageContext _context;

        public UnitOfWork(ImageContext context)
        {
            _context = context;
            FileUploadRepository = new FileUploadRepository(_context);
        }

        public IFileUploadRepository FileUploadRepository { get; set; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
