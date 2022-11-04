using Engins.DbProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engins.Entities
{
    public interface ISave<T> where T : Entity
    {
        void Save(IDbProvider<T> dbProvider);
    }
}
