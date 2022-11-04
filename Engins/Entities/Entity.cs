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
    public class Entity : IHasID
    {
        string IHasID.Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public void BeforeSave()
        {

        }
    }

 
}
