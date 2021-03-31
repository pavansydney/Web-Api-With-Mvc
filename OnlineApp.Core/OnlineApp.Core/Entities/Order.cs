using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Core.Entities
{
    public class Order
    {
        public Order()
        {

        }
        [Key]
        public int Order_Id { get; set; }
        public string Order_ComponentName { get; set; }
        //public string Order_CompanyName { get; set; }
        public decimal Order_Price { get; set; }
        public string Order_Type { get; set; }
        public int Order_Quantity { get; set; }
        //[ForeignKey("Company")]
        //public string Company_Name { get; set; }
        //public Company Company { get; set; }
        public int Component_Id { get; set; }
        [ForeignKey("Component_Id")]
        public Components Components { get; set; }

        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public User User { get; set; }

        public decimal total { get; set; }
    }
}
