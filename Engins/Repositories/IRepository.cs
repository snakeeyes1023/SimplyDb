using Engins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engins.Repositories
{
    public interface IRepository<T> where T : Entity
    {
        DbData<T> Entities { get; }
        T AddNewEntity();
        void DeleteEntity(T entityToDelete);
    }
}
