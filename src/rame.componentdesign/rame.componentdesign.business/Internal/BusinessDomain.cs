using rame.componentdesign.datastore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rame.componentdesign.business.Internal
{
    internal class BusinessDomain(DatastoreFactory datastoreFactory) : IBusinessDomain
    {
        public bool CheckBootstrap()
        {
            List<string> stringList = datastoreFactory.DataDomain.GetFirst(count: 100);

            if (stringList.Count < 100)
            {
                throw new Exception("Count error");
            }

            return true;
        }
    }
}
