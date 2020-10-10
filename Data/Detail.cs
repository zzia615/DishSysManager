using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DishSysManager.Data
{
    [Table("Detail")]
    public class Detail
    {
        [Key]
        [Required]
        public int id { get; set; }
        [StringLength(20)]
        [Required]
        public string ord_no { get; set; }

        [Required]
        public int m_id { get; set; }

        [StringLength(50)]
        [Required]
        public string m_mc { get; set; }

        [Required]
        public double m_price { get; set; } = 0;

        [Required]
        public int m_sl { get; set; } = 1;
    }
}
