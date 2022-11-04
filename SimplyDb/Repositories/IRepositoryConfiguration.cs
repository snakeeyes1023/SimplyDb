using SimplyDb.DbProvider;
using SimplyDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDb.Repositories
{
    public interface IRepositoryConfiguration<T>
        where T : Entity
    {
        IDbProvider<T> DbProvider { get; }
    }
}
