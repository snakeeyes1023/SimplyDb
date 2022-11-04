using Engins.DbProvider;
using Engins.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engins.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IRepository<T>, IRepositoryConfiguration<T>
        where T : Entity, IHasID, new()
    {    
        protected Repository(IDbProvider<T> dbProvider)
        {
            EntitiesToAdd = new List<T>();
            EntitiesToDelete = new List<T>();
            DbProvider = dbProvider;
        }

        #region Configuration
        public IDbProvider<T> DbProvider { get; private set; }
        #endregion

        #region Dirty Add and Delete
        private List<T> EntitiesToAdd { get; set; }
        private List<T> EntitiesToDelete { get; set; }
        #endregion

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

        /// <summary>
        /// Add a new entities
        /// </summary>
        /// <returns></returns>
        public virtual T AddNewEntity()
        {
            T createdEntity = new T();
            Entities.Add(createdEntity);
            EntitiesToAdd.Add(createdEntity);
            return createdEntity;
        }

        /// <summary>
        /// Delete an entity
        /// </summary>
        /// <param name="entityToDelete"></param>
        public virtual void DeleteEntity(T entityToDelete)
        {
            // delete from Entities list
            Entities.Remove(entityToDelete);
            EntitiesToDelete.Add(entityToDelete);
        }

        /// <summary>
        /// Save all update
        /// </summary>
        public virtual void Save()
        {
            foreach (var entity in Entities)
            {
                entity.BeforeSave();
            }
        }


        /// <summary>
        /// Set the engine that will be used to save the data
        /// </summary>
        /// <param name="provider"></param>
        public virtual void Configure(IDbProvider<T> provider)
        {
            DbProvider = provider;

            Entities = new DbData<T>(this);
        }
    }
}
