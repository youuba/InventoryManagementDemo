using InventoryManagement.Core.Repositories;
using InventoryManagement.EF.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.EF.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly InventoryManagementContext _context;
        protected DbSet<T> _entities;
        public GenericRepository(InventoryManagementContext context)
        {
            _context = context;
            _entities= _context.Set<T>();
    }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public T Insert(T entity)
        {
            _entities.Add(entity);
            return entity;
        }

        public T Update(T entity)
        {
            _entities.Update(entity);
            return entity;
        }

        public void Delete(T enity)
        {
            _entities.Remove(enity);
        }

        public T GetById(int id)
        {
            return _entities.Find(id);
        }

    }
}
