using SimplyDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDb.DbProvider
{
    public interface IDbProvider<T>
        where T : Entity
    {

        string SaveStatement { get; }
        string UpdateStatement { get; set; }
        string DeleteStatement { get; set; }
        string QueryStatement { get; set; }
        
        void Create(T entity);
        void Create(IEnumerable<T> entity);

        void Update(T entity);
        void Delete(T entity);
        IEnumerable<T> GetAll();
    }
}
