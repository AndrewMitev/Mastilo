namespace Mastilo.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Mastilo.Data.Common.Models;

    public class Category : BaseModel<int>
    {
        public Category()
        {
            this.Masterpieces = new HashSet<Masterpiece>();
        }

        [Required]
        [MinLength(2, ErrorMessage = "Името на категорията трябва да е поне 3 символа!")]
        public string Name { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        public virtual ICollection<Masterpiece> Masterpieces { get; set; }
    }
}
