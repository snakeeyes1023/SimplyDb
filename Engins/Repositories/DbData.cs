using Engins.Entities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Engins.Repositories
{
    public class DbData<T> : List<T> where T : Entity, IHasID
    {
        private readonly IRepositoryConfiguration<T> _configuration;
        public List<T> DefaultData { get; set; }

        public DbData(IRepositoryConfiguration<T> configuration)
        {
            _configuration = configuration;
            DefaultData = new List<T>();
        }

        public new T Add(T n)
        {
            base.Add(n);
            return n;
        }

        public new T Remove(T n)
        {
            base.Remove(n);
            return n;
        }

        public DbData<T> FillEntities()
        {
            foreach (var entity in _configuration.DbProvider.GetAll())
            {
                DefaultData.Add((T)entity.CloneJson());
                base.Add((T)entity);
            }

            return this;
        }
    }
    public static class CloneExtension
    {
        public static T CloneJson<T>(this T source)
        {
            // Don't serialize a null object, simply return the default for that object
            if (ReferenceEquals(source, null)) return default;

            // initialize inner objects individually
            // for example in default constructor some list property initialized with some values,
            // but in 'source' these items are cleaned -
            // without ObjectCreationHandling.Replace default constructor values will be added to result
            var deserializeSettings = new JsonSerializerSettings { ObjectCreationHandling = ObjectCreationHandling.Replace };

            return JsonConvert.DeserializeObject<T>(JsonConvert.SerializeObject(source), deserializeSettings);
        }
    }
}
