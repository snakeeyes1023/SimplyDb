using Dapper;
using Engins.Entities;
using Engins.Repositories;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engins.DbProvider
{
    public class SqlDBProvider<T> : IDbProvider<T>
        where T : Entity
    {
        private readonly string ConnectionSql;
        private readonly string TableName;

        public IRepositoryConfiguration<T> Configuration { get; set; }


        public SqlDBProvider(string connectionSql, string tableName , IRepositoryConfiguration<T> configuration)
        {
            ConnectionSql = connectionSql;
            Configuration = configuration;
            TableName = tableName;
        }

        public string SaveStatement => throw new NotImplementedException();
        public string UpdateStatement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string DeleteStatement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string QueryStatement { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public T Create(T entity)
        {
            throw new NotImplementedException();
        }

        public T Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<T> GetAll()
        {
            using (IDbConnection db = new SqlConnection(ConnectionSql))
            {   
                db.Open();
                
                return db.Query<T>($"SELECT * FROM {TableName}");
            } 
        }

        public T Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
