using System;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Core.Entities
{
    public class Components
    {
        public Components()
        {
              
        }
        [Key]
        public int Components_Id { get; set; }

        [Required]
        public string Components_Name { get; set; }

        [DataType("decimal(16,3)")]
        public decimal Price { get; set; }
        public string Type { get; set; }

        [ForeignKey("Manufacturer")]
        public int Manufacturer_Id { get; set; }
        public Manufacturer Manufacturer { get; set; }
        public int Quantity { get; set; }
    }
}
