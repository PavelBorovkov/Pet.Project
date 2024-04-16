using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory.Domain;

namespace Inventory.Application.Interfaces
{
    public interface ITestDbContext
    {
        DbSet<Category> Categories { get; set; }
        DbSet<EventLog> EventLogs { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<ProductInventory> ProductInventories { get; set; }
        DbSet<Warehouse> Warehouses { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
