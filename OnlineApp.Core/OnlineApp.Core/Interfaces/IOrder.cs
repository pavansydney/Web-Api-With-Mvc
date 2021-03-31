using OnlineApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Core.Interfaces
{
    public interface IOrder
    { 
        void AddToCart(Order order);
        IEnumerable<Order> GetOrders();

    }
}
