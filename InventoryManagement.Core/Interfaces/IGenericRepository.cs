using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryManagement.Core.Repositories
{
    public interface IGenericRepository <T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(int id);
        T Insert(T entity);
        T Update(T entity);
        void Delete(T entity);
    }
}
