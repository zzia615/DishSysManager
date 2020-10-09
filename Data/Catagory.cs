using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DishSysManager.Data
{
    [Table("Catagory")]
    public class Catagory
    {
        [Key]
        public int id { get; set; }
        [Required]
        [StringLength(50)]
        public string mc { get; set; }
    }
}
