using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Windows.Controls;

namespace DishSysManager.Data
{
    [Table("Order")]
    public class Order
    {
        [Key]
        [StringLength(20)]
        [Required]
        public string no { get; set; }
        [Required]
        public DateTime date { get; set; } = DateTime.Now;

        [StringLength(50)]
        public string desk { get; set; }

        [Required]
        public int isJz { get; set; } = 0;

        [StringLength(50)]
        public string zffs { get; set; }

        [Required]
        public double zje { get; set; } = 0;

        [Required]
        public double yhje { get; set; } = 0;

        public string memo { get; set; }

    }
}
