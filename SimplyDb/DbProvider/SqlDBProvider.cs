using Dapper;
using Dapper.Contrib.Extensions;
using Microsoft.Data.SqlClient;
using SimplyDb.Entities;
using SimplyDb.Repositories;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDb.DbProvider
{
    public class SqlDBProvider<T> : IDbProvider<T>
        where T : Entity
    {
        private readonly string ConnectionSql;
        private readonly string TableName;

        public IRepositoryConfiguration<T> Configuration { get; set; }


        public SqlDBProvider(string connectionSql, string tableName, IRepositoryConfiguration<T> configuration)
        {
            ConnectionSql = connectionSql;
            Configuration = configuration;
            TableName = tableName;
        }

        public string SaveStatement => throw new NotImplementedException();
        public string UpdateStatement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DeleteStatement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string QueryStatement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void Create(T entity)
        {
            using (IDbConnection db = new SqlConnection(ConnectionSql))
            {
                db.Open();

                entity.Id = int.Parse(db.Insert(entity).ToString());
            }
        }

        public void Create(IEnumerable<T> entities)
        {
            using (IDbConnection db = new SqlConnection(ConnectionSql))
            {
                db.Open();

                db.Insert(entities);
            }
        }

        public void Delete(T entity)
        {
            using (IDbConnection db = new SqlConnection(ConnectionSql))
            {
                db.Open();

                entity.Id = int.Parse(db.Insert(entity).ToString());
            }
        }

        public IEnumerable<T> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionSql))
            {
                db.Open();

                return db.Query<T>($"SELECT * FROM {TableName}");
            }
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
