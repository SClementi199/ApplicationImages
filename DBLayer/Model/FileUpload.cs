
namespace DBLayer.Model
{
    public class FileUpload
    {
        public int Id { get; set; }
        public string ImageTitle { get; set; }
        public byte[] Files {  get; set; }
    }
}

