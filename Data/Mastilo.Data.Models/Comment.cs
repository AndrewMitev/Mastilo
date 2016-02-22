namespace Mastilo.Data.Models
{
    using Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Comment : BaseModel<int>
    {
        public Comment()
        {
            this.Likes = new HashSet<Like>();
        }

        [Required]
        [MinLength(5, ErrorMessage = "Too short comment! Enter at least 5 symbols.")]
        public string Text { get; set; }

        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }

        public int? MasterpieceId { get; set; }

        [ForeignKey("MasterpieceId")]
        public virtual Masterpiece Masterpiece { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
