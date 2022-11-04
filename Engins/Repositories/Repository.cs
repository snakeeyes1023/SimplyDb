using Engins.DbProvider;
using Engins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engins.Repositories
{
    public abstract class Repository<T> : IRepository<T>, IRepositoryConfiguration<T>
        where T : Entity, IHasID, new()
    {

        public IDbProvider<T> DbProvider { get; private set; }

        //SPEED UP WITH TOTAL ENTITIES LIST

        private DbData<T>? _Entities;
        public DbData<T> Entities 
        {
            get
            {
                if (_Entities == null)
                {
                    _Entities = new DbData<T>((IRepositoryConfiguration<T>)this);
                }

                return _Entities;
            }
            private set
            {
                _Entities = value;
            }
        }

        public virtual T AddNewEntity()
        {
            T createdEntity = new T();
            Entities.Add(createdEntity);
            return createdEntity;
        }

        public virtual void DeleteEntity(T entityToDelete)
        {
            // delete from Entities list
            Entities.Remove(entityToDelete);
        }

        public virtual void Save()
        {
            foreach (var entity in Entities)
            {
                entity.BeforeSave();
            }
        }

        public virtual void Configure(IDbProvider<T> provider)
        {
            DbProvider = provider;

            Entities = new DbData<T>(this);
        }
    }
}
