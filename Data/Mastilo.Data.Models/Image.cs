namespace Mastilo.Data.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;

    public class Image : BaseModel<int>
    {
        public byte[] ImageData { get; set; }

        public string ImageName { get; set; }

        public bool IsActive { get; set; }
    }
}
