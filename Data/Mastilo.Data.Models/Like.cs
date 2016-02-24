namespace Mastilo.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Like : BaseModel<int>
    {
        public string UserId { get; set; }

        [ForeignKey("UserId")]
        public virtual User Author { get; set; }
    }
}
