namespace Mastilo.Data.Models
{
    using Mastilo.Data.Common.Models;
    using System.ComponentModel.DataAnnotations.Schema;

    public class SeenBy : BaseModel<int>
    {
        public string SeenByUsername { get; set; }

        public int MasterpieceId { get; set; }

        [ForeignKey("MasterpieceId")]
        public virtual Masterpiece SeenMasterpiece { get; set; }
    }
}
