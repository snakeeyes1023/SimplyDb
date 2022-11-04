using Dapper.Contrib.Extensions;
using SimplyDb.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplyDb.Tests.Fixtures.SampleData.Entities
{

    [Table("Car")]
    public class CarEntity : Entity
    {
        public string Name { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Year { get; set; }
    }
}
