using SimplyDb.Tests.Fixtures.SampleData.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDb.Tests.Fixtures
{
    public class DataFixture : IDisposable
    {
        public readonly GlobalDbContext _GlobalDbContext;
        
        public DataFixture()
        {
            _GlobalDbContext = new GlobalDbContext();
        }

        public void Dispose()
        {
            _GlobalDbContext.Dispose();
        }
    }
}
