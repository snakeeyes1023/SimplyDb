using SimplyDb.DbProvider;
using SimplyDb.Tests.Fixtures.SampleData.Entities;
using SimplyDb.Tests.Fixtures.SampleData.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDb.Tests.Fixtures.SampleData.DbContext
{
    public class GlobalDbContext : IDisposable
    {
        public GlobalDbContext()
        {
            Cars = new CarRepository();
        }

        public CarRepository Cars { get; set; }

        public void Dispose()
        {
            Cars.Dispose();
        }
    }
}
