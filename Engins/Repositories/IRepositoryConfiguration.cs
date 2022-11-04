using Engins.DbProvider;
using Engins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engins.Repositories
{
    public interface IRepositoryConfiguration<T> 
        where T : Entity
    {
        IDbProvider<T> DbProvider { get; }
    }
}
