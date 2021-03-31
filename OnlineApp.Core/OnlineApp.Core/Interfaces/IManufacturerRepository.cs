using OnlineApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Core.Interfaces
{
    public interface IManufacturerRepository
    {
        void AddManufacturer(Manufacturer manufacturer);
        void EditManufacturer(Manufacturer manufacturer);
        void RemoveManufacturer(int Manufacturer_Id);
        IEnumerable<Manufacturer> GetManufacturers();
        Manufacturer FindManufacturerById(int Manufacturer_Id);
    }
}
