using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BootstrapExample.Models
{
    [Table("Position")]
    public class Position
    {
        [Key]
        public int PositionID { get; set; }
        public string Name { get; set; }
    }
}