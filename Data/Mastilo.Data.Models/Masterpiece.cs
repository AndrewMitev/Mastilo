namespace Mastilo.Data.Models
{
    using Mastilo.Data.Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Masterpiece : BaseModel<int>
    {
        public Masterpiece()
        {
            this.Comments = new HashSet<Comment>();
            this.SeenBy = new HashSet<SeenBy>();
            this.Rates = new HashSet<Rate>();
            this.Categories = new HashSet<Category>();
        }

        [Required]
        [MinLength(3, ErrorMessage = "Title is too short!")]
        public string Title { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Your creation is too short!")]
        public string Content { get; set; }

        public bool Pending { get; set; }

        public bool IsAssessed { get; set; }

        public string DisapprovedMessage { get; set; }

        public int GenreId { get; set; }

        [ForeignKey("GenreId")]
        public virtual Genre Genre { get; set; }

        public string AuthorId { get; set; }

        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }

        public virtual ICollection<Category> Categories { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<SeenBy> SeenBy { get; set; }

        public virtual ICollection<Rate> Rates { get; set; }
    }
}
