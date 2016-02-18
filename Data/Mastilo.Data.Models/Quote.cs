namespace Mastilo.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Quote
    {
        [Required]
        [MinLength(5, ErrorMessage = "Too short quote!")]
        public string Text { get; set; }

        public int ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; }
    }
}
