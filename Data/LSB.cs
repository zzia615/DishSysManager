using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishSysManager.Data
{
    [Table("LSB")]
    public class LSB
    {
        [Key]
        [StringLength(20)]
        [Required]
        public string lb { get; set; }
        [Required]
        public int year { get; set; }
        [Required]
        public decimal lsh { get; set; }
    }
}
