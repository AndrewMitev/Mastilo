namespace Mastilo.Data.Models
{
    using Common.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class TimelinePost : BaseModel<int>
    {
        public TimelinePost()
        {
            this.Likes = new HashSet<Like>();
            this.Comments = new HashSet<Comment>();
            this.SeenBy = new HashSet<SeenBy>();
        }

        [Required]
        [MinLength(5, ErrorMessage = "Твърде кратък цитат!")]
        public string Text { get; set; }

        public string Url { get; set; }

        public int? ImageId { get; set; }

        [ForeignKey("ImageId")]
        public virtual Image Image { get; set; }

        public virtual ICollection<Like> Likes { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<SeenBy> SeenBy { get; set; }
    }
}
