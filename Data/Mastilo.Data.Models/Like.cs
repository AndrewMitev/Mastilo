namespace Mastilo.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Like
    {
        public int UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Author { get; set; }
    }
}
