using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Core.Models;
using InventoryManagement.Core.Repositories;

namespace InventoryManagement.Core.Interfaces
{
    public interface IUnitOfWork:IDisposable 
    {
        IGenericRepository<Inventory> Inventories { get; }
        IGenericRepository<Category> Categories { get; }
        IGenericRepository<Product> Products { get; }
        IGenericRepository<User> Users { get; }
        IGenericRepository<Supplier> Suppliers { get; }              
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<OrderItem> OrderItems { get; }
        int SaveChanges();
    }
}
