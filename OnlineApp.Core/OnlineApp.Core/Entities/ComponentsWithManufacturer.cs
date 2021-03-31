using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Core.Entities
{
    public class ComponentsWithManufacturer
    {
        [Key]
        public int ComponentsWithManufacturer_Id { get; set; }//Order_Id
        public string ComponentsWithManufacturer_ComponentName { get; set; }//Ordername
        public string ComponentsWithManufacturer_ManufacturerName { get; set; }//OrderMananame
        public decimal Price { get; set; }//OrderPrice
        public string Type { get; set; }//OrderType
        public int Quantity { get; set; }//OrderQuantity
    }
}
