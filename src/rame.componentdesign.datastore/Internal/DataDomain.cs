using Microsoft.Extensions.Configuration;
using rame.componentdesign.datastore.Data;
using rame.componentdesign.datastore.Models;

namespace rame.componentdesign.datastore.Internal
{
    internal class DataDomain(MainDbContext mainDbContext) : IDataDomain
    {
        public List<Despacho> GetFirst(int count)
        {
            List<Despacho> res = [.. mainDbContext.Despacho
                .Where(o => o.DataEntrega >= DateTime.Now 
                    && o.DataEntrega < DateTime.Now.AddDays(10))
                .Take(100)
                .ToList()];

            return res;
        }
    }
}