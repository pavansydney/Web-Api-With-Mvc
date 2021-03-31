using OnlineApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Core.Interfaces
{
    public interface IComponentsWithManufacturerRepository
    {
        List<ComponentsWithManufacturer> GetComponentsWithManufacturers();
        ComponentsWithManufacturer FindComponentsWithManufacturerById(int ComponentWithManufacturer_Id);
    }
}
