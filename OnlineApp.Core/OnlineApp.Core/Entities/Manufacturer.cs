using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Core.Entities
{
    public class Manufacturer
    {
        public Manufacturer()
        {
                
        }

        [Key]
        public int Manufacturer_Id { get; set; }

        [Index("IX_FirstAndSecond", 1, IsUnique = true)]
        [StringLength(50)]
        public string Manufacturer_Name { get; set; }

        [StringLength(1)]
        [Column(TypeName = "char")]
        public string IsAuthorized { get; set; }

        public ICollection<Components> Components { get; set; }
    }
}
