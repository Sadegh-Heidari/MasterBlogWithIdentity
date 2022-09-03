using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.BaseDomainAgg;

namespace DomainServices.Base
{
    public interface IBaseRepository<T> where T : DomainBase
    {
        List<T> getAll();
        void Add(T entity);
        void Update(T entity);
    }
}
