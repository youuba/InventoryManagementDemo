using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InventoryManagement.Core.Interfaces;
using InventoryManagement.Core.Models;
using InventoryManagement.Core.Repositories;
using InventoryManagement.EF.Models;

namespace InventoryManagement.EF.Repositories
{
    public class UnitOfWork: IUnitOfWork
    {
        protected readonly InventoryManagementContext _context;

        public IGenericRepository<Inventory> Inventories { get; }

        public IGenericRepository<Category> Categories { get; }

        public IGenericRepository<Product> Products { get; }

        public IGenericRepository<User> Users { get; }

        public IGenericRepository<Supplier> Suppliers { get; }

        public IGenericRepository<Customer> Customers { get; }

        public IGenericRepository<Order> Orders { get; }

        public IGenericRepository<OrderItem> OrderItems { get; }

        public UnitOfWork(InventoryManagementContext context)
        {
            _context   = context;
            Inventories = new GenericRepository<Inventory>(_context);
            Products = new GenericRepository<Product>(_context);
            Categories = new GenericRepository<Category>(_context);
            Users = new GenericRepository<User>(_context);
            Suppliers = new GenericRepository<Supplier>(_context);
            Customers = new GenericRepository<Customer>(_context);
            Orders = new GenericRepository<Order>(_context);
            OrderItems = new GenericRepository<OrderItem>(_context);
        }
        public void Dispose()
        {
            _context.Dispose();
        }
        public int SaveChanges()
        {
           return _context.SaveChanges();
        }
    }
}
