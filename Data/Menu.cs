using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DishSysManager.Data
{
    [Table("Menu")]
    public class Menu:EventArgs
    {
        [Key]
        public int id { get; set; }
        [StringLength(50)]
        [Required]
        public string mc { get; set; }

        [Required]
        public int ct_id { get; set; }

        [Required]
        public double price { get; set; } = 0;

        [Required]
        public int isTjc { get; set; } = 0;

        [Required]
        public int isRxc { get; set; } = 0;
    }
}
