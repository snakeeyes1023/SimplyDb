using Engins.DbProvider;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Engins.Entities
{
    /// <summary>
    /// Can be compare to a table in sql
    /// </summary>
    public class Entity : IHasID
    {
        public int Id { get; private set; }

        public virtual void BeforeSave()
        {
            Console.WriteLine("I will save");
        }
    }

 
}
