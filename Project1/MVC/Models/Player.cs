using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootstrapExample.Models
{
    [Table("Player")]
    public class Player
    {
        [Key]
        public int PlayerID { get; set; }
        public string Name { get; set; }
        public int Number { get; set; }

        [ForeignKey("Position")]
        public int PositionID { get; set; }
        public virtual Position Position { get; set; }
    }
}