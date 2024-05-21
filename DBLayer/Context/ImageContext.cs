using DBLayer.Model;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace DBLayer.Context
{
    public class ImageContext : DbContext
    {
        public ImageContext(DbContextOptions<ImageContext> options) : base(options) { }

        public DbSet<FileUpload> FilesUpload { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
