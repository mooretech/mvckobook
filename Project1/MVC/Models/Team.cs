using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootstrapExample.Models
{
    [Table("Team")]
    public class Team
    {
        [Key]
        public int TeamID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Player> Players { get; set; }
    }
}