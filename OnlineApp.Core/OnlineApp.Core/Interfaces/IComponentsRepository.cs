using OnlineApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Core.Interfaces
{
    public interface IComponentsRepository
    {
        void AddComponent(Components component);//AddToCart
        void EditComponent(Components component);
        void RemoveComponent(int Components_Id);
        IEnumerable<Components> GetComponents();
        Components FindComponenttById(int Components_Id);
    }
}
