using rame.componentdesign.datastore;
using rame.componentdesign.datastore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace rame.componentdesign.business.Internal
{
    internal class BusinessDomain(DatastoreFactory datastoreFactory) : IBusinessDomain
    {
        public List<Despacho> GetDespachos()
        {
            List<Despacho> despachos = datastoreFactory.DataDomain.GetFirst(count: 100);

            return despachos;
        }
    }
}
