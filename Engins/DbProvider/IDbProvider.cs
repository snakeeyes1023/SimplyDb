using Engins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engins.DbProvider
{
    public interface IDbProvider<T>
        where T : Entity
    {

        string SaveStatement { get; }
        string UpdateStatement { get; set; }
        string DeleteStatement { get; set; }
        string QueryStatement { get; set; }

        T Create(T entity);
        T Update(T entity);
        T Delete(T entity);
        IEnumerable<T> GetAll();
    }
}
