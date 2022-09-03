using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.BaseDomainAgg;
using DomainServices.Base;
using Infrastructure.EFCORE.ContextDB;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.EFCORE.Base
{
    public class BaseRepository<T>:IBaseRepository<T>where T:DomainBase
    {
        private MasterContext _context { get; }

        public BaseRepository(MasterContext context)
        {
            _context = context;
        }

        public List<T> getAll()
        {
            return  _context.Set<T>().ToList();
        }

        public void Add(T entity)
        {
            _context.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            if (_context.Entry(entity).State != EntityState.Deleted)
            {
                _context.Set<T>().Update(entity);
            }
        }
    }
}
