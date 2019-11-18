using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using E_Schedule_DAL.ORMs;
using E_Schedule_DAL.Contexts;

namespace E_Schedule_DAL.Repository
{
    public class EF_Repository<T> : IRepository<T> where T : class
    {
        ScheduleContext _context;
        DbSet<T> _dbSet;

        public EF_Repository(ScheduleContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public void Insert(T entity)
        {
            _dbSet.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(object id)
        {
            _dbSet.Remove(GetByID(id));
            _context.SaveChanges();
        }

        public T GetByID(object id)
        {
            return _dbSet.Find(id);
        }

        public void Update(object id, T entity)
        {
            _context.Entry(GetByID(id)).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public IEnumerable<T> GetAll()
        {
            return _dbSet.ToList();
        }
    }
}