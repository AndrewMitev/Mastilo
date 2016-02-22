namespace Mastilo.Data.Models
{
    using Common.Models;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class Like : BaseModel<int>
    {
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Author { get; set; }
    }
}
