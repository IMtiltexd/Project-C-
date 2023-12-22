using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ESHOP.Models
{
    public class Manufacturer

    {
        [Key]
        public int Id {  get; set; }
        [Required]
        public string Title { get; set; }

        public ICollection<Item> Items { get; set; }
    }
}
