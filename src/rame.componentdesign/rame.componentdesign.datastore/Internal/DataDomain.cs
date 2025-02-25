using Microsoft.Extensions.Configuration;
using rame.componentdesign.datastore.Data;

namespace rame.componentdesign.datastore.Internal
{
    internal class DataDomain(MainDbContext mainDbContext) : IDataDomain
    {
        public List<string> GetFirst(int count)
        {
            List<string> res = [.. mainDbContext.Despacho
                .Take(100)
                .Select(o => o.Observacoes)];

            return res;
        }
    }
}