using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Schedule_DAL.Repository
{
    public interface IRepository<T>
    {
        T GetByID(object id);
        void Insert(T entity);
        void Update(object id,T entity);
        void Delete(object id);
        IEnumerable<T> GetAll();
    }
}