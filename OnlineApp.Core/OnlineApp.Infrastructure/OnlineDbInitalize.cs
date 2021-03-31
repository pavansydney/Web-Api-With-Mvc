using OnlineApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineApp.Infrastructure
{
    public class OnlineDbInitalize : DropCreateDatabaseIfModelChanges<OnlineContext>
    {
        protected override void Seed(OnlineContext context)
        {
            //Adding initial Author data
            context.Components.Add
                 (
                  new Components
                  {
                      Components_Id = 1,
                      Components_Name = "Aurdino",
                      Type = "Processors",
                      Price = 1000,
                      Manufacturer_Id = 1,
                      Quantity = 2
                  }
                );

            //Adding initial Book data
            context.Manufacturers.Add
                 (
                     new Manufacturer
                     {
                         Manufacturer_Id = 1,
                         Manufacturer_Name = "Texas Instruments",
                         IsAuthorized = "Y"
                     }
                 );

            context.SaveChanges();

            base.Seed(context);

        }
    }
}
