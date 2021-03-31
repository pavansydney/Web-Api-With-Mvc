using OnlineApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Infrastructure
{
    public class OnlineContext : DbContext
    {
        public OnlineContext() : base("name = Onlineappconnectionstring")
        {
            Database.SetInitializer(new OnlineDbInitalize());
        }

        public DbSet<Components> Components { get; set; }

        public DbSet<Manufacturer> Manufacturers { get; set; }

        public System.Data.Entity.DbSet<OnlineApp.Core.Entities.ComponentsWithManufacturer> ComponentsWithManufacturers { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<Order> Orders { get; set; }

        public DbSet<Admin> Admins { get; set; }


    }
}
