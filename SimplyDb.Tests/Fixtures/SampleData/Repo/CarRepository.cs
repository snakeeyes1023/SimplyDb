using SimplyDb.DbProvider;
using SimplyDb.Repositories;
using SimplyDb.Tests.Fixtures.SampleData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDb.Tests.Fixtures.SampleData.Repo
{
    public class CarRepository : Repository<CarEntity>
    {
        public CarRepository()
        {
            Configure(new SqlDBProvider<CarEntity>("Data Source=IIS-SERVER;Initial Catalog=SimplyDbTest;User ID=jcote;Password=Cote1!;TrustServerCertificate=True;", "Car", this));
        }
    }
}
