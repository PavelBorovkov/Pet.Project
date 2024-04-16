using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Persistance
{
    public class DbInitializer
    {
        public static void Initialize(TestDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
