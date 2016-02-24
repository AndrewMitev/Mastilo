namespace Mastilo.Data.Models
{
    using Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System;

    public class Genre : BaseModel<int>
    {
        public Genre()
        {
            this.Categories = new HashSet<Category>();
        }

        [Required]
        [MinLength(3, ErrorMessage ="A tag should be at least 3 symbols.")]
        public string Name { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
    }
}
