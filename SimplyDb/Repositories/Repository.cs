using SimplyDb.DbProvider;
using SimplyDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace SimplyDb.Repositories
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class Repository<T> : IRepository<T>, IRepositoryConfiguration<T>, IDisposable
        where T : Entity, IHasID, new()
    {
        protected Repository()
        {
            EntitiesToAdd = new List<T>();
            EntitiesToDelete = new List<T>();
            Entities = new DbData<T>(this);
        }


        #region Configuration
        public IDbProvider<T> DbProvider { get; private set; }
        #endregion

        #region Dirty Add and Delete
        private List<T> EntitiesToAdd { get; set; }
        private List<T> EntitiesToDelete { get; set; }
        #endregion

        //SPEED UP WITH TOTAL ENTITIES LIST

        public DbData<T> Entities { get; private set; }

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

        public virtual DbData<T> GetAll()
        {
            return Entities.FillEntities();
        }
        
        /// <summary>
        /// Save all update
        /// </summary>
        public virtual void Save()
        {
            // Add new entities
            DbProvider.Create(EntitiesToAdd);
            EntitiesToAdd.Clear();
            
            foreach (var entity in Entities)
            {
                entity.BeforeSave();
            }
        }

        public virtual void Delete(T entityToDelete)
        {
            EntitiesToDelete.Add(entityToDelete);
        }

        public virtual void Configure(IDbProvider<T> dbProvider)
        {
            DbProvider = dbProvider;
        }

        public void Dispose()
        {
            EntitiesToAdd.Clear();
            EntitiesToDelete.Clear();
            Entities.Clear();
        }

    }
}
