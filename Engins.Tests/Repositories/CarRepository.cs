using Engins.DbProvider;
using Engins.Repositories;
using Engins.Tests.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engins.Tests.Repositories
{
    public class CarRepository : Repository<CarEntity>
    {
        public CarRepository()
        {
            Configure(new SqlDBProvider<CarEntity>("Data Source=IIS-SERVER;Initial Catalog=Unity;User ID=jcote;Password=Cote1!;TrustServerCertificate=True; ", "Locker", this));
        }
    }
}
