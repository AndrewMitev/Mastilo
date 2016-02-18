namespace Mastilo.Data.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Tag
    {
        [Required]
        [MinLength(3, ErrorMessage ="A tag should be at least 3 symbols.")]
        public string Name { get; set; }
    }
}
