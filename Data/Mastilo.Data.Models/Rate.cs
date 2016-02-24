namespace Mastilo.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Rate : BaseModel<int>
    {
        [Range(1, 5)]
        public int Value { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }

        public int? MasterpieceId { get; set; }

        public virtual Masterpiece RatedMasterpiece { get; set; }
    }
}
