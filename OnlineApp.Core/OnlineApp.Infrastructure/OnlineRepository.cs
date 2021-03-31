using OnlineApp.Core.Entities;
using OnlineApp.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Infrastructure
{
    public class OnlineRepository : IComponentsRepository,
                                    IManufacturerRepository, 
                                    IComponentsWithManufacturerRepository, 
                                    IBasic,
                                    IUser,
                                    IOrder
    {
        OnlineContext context = new OnlineContext();
        #region
        public void AddComponent(Components component)
        {
            context.Components.Add(component);
            context.SaveChanges();
        }

        public void EditComponent(Components component)
        {
            context.Entry(component).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public Components FindComponenttById(int Components_Id)
        {
            var c = (from r in context.Components where r.Components_Id == Components_Id select r).FirstOrDefault();
            return c;
        }

        public IEnumerable<Components> GetComponents()
        {
            return context.Components;
        }

        public void RemoveComponent(int Components_Id)
        {
            Components components = context.Components.Find(Components_Id);
            context.Components.Remove(components);
            context.SaveChanges();
        }

        public decimal findComponentsPrice(int? component_id)
        {
            var componentprice = (from r in context.Components where r.Components_Id == component_id select r.Price).FirstOrDefault();
            return componentprice;
        }

        public decimal findComponentsPrice(int? component_id, string componentname)
        {
            var componentprice = (from product in context.Components
                                where product.Components_Id == component_id | product.Components_Name == componentname
                                select product.Price).FirstOrDefault();
            return componentprice;
        }

        public void AddManufacturer(Manufacturer manufacturer)
        {
            context.Manufacturers.Add(manufacturer);
            context.SaveChanges();
        }

        public void EditManufacturer(Manufacturer manufacturer)
        {
            context.Entry(manufacturer).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public void RemoveManufacturer(int Manufacturer_Id)
        {
            Manufacturer manufacturer = context.Manufacturers.Find(Manufacturer_Id);
            context.Manufacturers.Remove(manufacturer);
            context.SaveChanges();
        }

        public IEnumerable<Manufacturer> GetManufacturers()
        {
            return context.Manufacturers;
        }

        public Manufacturer FindManufacturerById(int Manufacturer_Id)
        {
            var c = (from r in context.Manufacturers where r.Manufacturer_Id == Manufacturer_Id select r).FirstOrDefault();
            return c;
        }
        public List<ComponentsWithManufacturer> GetComponentsWithManufacturers()
        {
            var componentswithmanufacturers = (
                            from Components in context.Components
                            join Manufacturer in context.Manufacturers
                            on Components.Manufacturer_Id equals Manufacturer.Manufacturer_Id
                            select new
                            {
                                ComponnetWithManufacturer_Id = Components.Components_Id,
                                ComponnetWithManufacturer_ComponentName = Components.Components_Name,
                                ComponnetWithManufacturer_ManufacturerName = Manufacturer.Manufacturer_Name,
                                Type = Components.Type,
                                Price = Components.Price,
                                Quantity = Components.Quantity
                            }).ToList();
            List<ComponentsWithManufacturer> lstcomponentsWithManufacturers = new List<ComponentsWithManufacturer>();
            foreach (var product in componentswithmanufacturers)
            {
                ComponentsWithManufacturer obj = new ComponentsWithManufacturer();
                obj.ComponentsWithManufacturer_Id = product.ComponnetWithManufacturer_Id;
                obj.ComponentsWithManufacturer_ComponentName = product.ComponnetWithManufacturer_ComponentName;
                obj.ComponentsWithManufacturer_ManufacturerName = product.ComponnetWithManufacturer_ManufacturerName;
                obj.Type = product.Type;
                obj.Price = product.Price;
                obj.Quantity = product.Quantity;
                lstcomponentsWithManufacturers.Add(obj);
            }
            return lstcomponentsWithManufacturers;
        }
        public ComponentsWithManufacturer FindComponentsWithManufacturerById(int ComponentWithManufacturer_Id)
        {
            var componentwithmanufacturer = (
                              from Components in context.Components
                              join Manufacturer in context.Manufacturers
                              on Components.Manufacturer_Id equals Manufacturer.Manufacturer_Id
                              where Components.Components_Id == ComponentWithManufacturer_Id
                              select new ComponentsWithManufacturer
                              {
                                  ComponentsWithManufacturer_Id = Components.Components_Id,
                                  ComponentsWithManufacturer_ComponentName = Components.Components_Name,
                                  ComponentsWithManufacturer_ManufacturerName = Manufacturer.Manufacturer_Name,
                                  Type = Components.Type,
                                  Price = Components.Price,
                                  Quantity = Components.Quantity
                              }).FirstOrDefault();
            return componentwithmanufacturer;
        }

        public IEnumerable<Basic> GetManufacturersIdName()
        {
            var manufactureridname = (from Manufacturer in context.Manufacturers
                                      select new Basic
                                      {
                                          ID = Manufacturer.Manufacturer_Id,
                                          NAME = Manufacturer.Manufacturer_Name
                                      }).ToList();
            return manufactureridname;
        }

        public IEnumerable<Basic> GetTypeIdName()
        {
            return new List<Basic>(new[]
            {
                new Basic()
                {
                    ID = 1,
                    NAME = "Sensors"
                },
                new Basic()
                {
                    ID =2,
                    NAME = "Processors"
                },
            });
        }

        public IEnumerable<Basic> GetAuthorizationStatusIdName()
        {
            return new List<Basic>(new[]
           {
                new Basic()
                {
                    ID=1,
                    NAME = "Y"
                },
                new Basic()
                {
                    ID=2,
                    NAME="N"
                }
            });
        }

        public User LoginValidate(User user)
        {
            bool validUser = this.context.Users.Any(u => u.Username == user.Username && u.Password == user.Password);
            if (validUser)
            {
                user.UserId = this.context.Users.Where(u => u.Username == user.Username && u.Password == user.Password).FirstOrDefault().UserId;
                return user;
            }
            else
                return null;

        }

        //public User LoginValidate(User user)
        //{
        //    User checkuser = this.GetByUserId(user.Username, user.Password);
        //    User validUser = this.context.Users.SingleOrDefault(u => u.Username == user.Username && u.Password == user.Password);
        //    return validUser;
        //}

        //public User GetByUserId(string username, string password)
        //{
        //    var c = (from r in context.Users where r.Username == username && r.Password == password select r).FirstOrDefault();
        //    return c;
        //}

        public bool Registration(User user)
        {
            User validUserByUsername = this.context.Users.SingleOrDefault(u => u.Username == user.Username);
            User validUserByEmail = this.context.Users.SingleOrDefault(u => u.Email == user.Email);
            Admin validAdmin = this.context.Admins.SingleOrDefault(u => u.Username == user.Username);

            if (validUserByUsername == null && validUserByEmail == null)
            {
                this.context.Users.Add(user);
                this.context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        public void AddToCart(Order addOrupdateOrder)
        {
            var order = context.Orders.Where(x => x.Component_Id == addOrupdateOrder.Component_Id && x.UserId == addOrupdateOrder.UserId).FirstOrDefault();
            if (order != null)
            {
                order.Order_Quantity = order.Order_Quantity + 1;
                order.total = order.Order_Quantity * order.Order_Price;
                context.Entry(order).State = System.Data.Entity.EntityState.Modified;
            }
            else
            {
                var e = context.Components.Where(x => x.Components_Id == addOrupdateOrder.Component_Id).SingleOrDefault();
                context.Orders.Add(
                    new Order()
                    {
                    //Order_Id = e.Components_Id,
                    //Order_CompanyName = e.ProductWithCompany_CompanyName,
                        Order_ComponentName = e.Components_Name,
                        Order_Price = e.Price,
                        Order_Quantity = 1,
                        Order_Type = e.Type,
                        Component_Id = e.Components_Id,
                        UserId = addOrupdateOrder.UserId,
                        total = e.Quantity * e.Price

                    });
            }
            context.SaveChanges();
        }

        public IEnumerable<Order> GetOrders()
        {
            return context.Orders;
        }

        public IEnumerable<User> GetUsers()
        {
            return context.Users;
        }

        public void EditUser(User user)
        {
            context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            context.SaveChanges();
        }

        public User FindUserById(int User_Id)
        {
            var c = (from r in context.Users where r.UserId == User_Id select r).FirstOrDefault();
            return c;
        }

        public IEnumerable<Basic> GetUsersIdName()
        {
            var useridname = (from User in context.Users
                                      select new Basic
                                      {
                                          ID = User.UserId,
                                          NAME = User.Username
                                      }).ToList();
            return useridname;
        }
        #endregion
    }
}
