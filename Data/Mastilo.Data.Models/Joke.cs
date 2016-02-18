using Mastilo.Data.Common.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mastilo.Data.Models
{
    public class Joke : BaseModel<int>
    {
        [Required]
        public string Text { get; set; }

        public string Info { get; set; }
    }
}
