namespace Mastilo.Data.Models
{
    using Common.Models;

    public class Image : BaseModel<int>
    {
        public byte[] Content { get; set; }

        public string FileExtension { get; set; }
    }
}
