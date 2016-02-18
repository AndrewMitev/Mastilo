namespace Mastilo.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment
    {
        public Comment()
        {
            this.Likes = new HashSet<Like>();
        }

        [Required]
        [MinLength(5, ErrorMessage = "Too short comment! Enter at least 5 symbols.")]
        public string Text { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
