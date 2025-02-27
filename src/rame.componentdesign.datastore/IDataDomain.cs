
using rame.componentdesign.datastore.Models;

namespace rame.componentdesign.datastore
{
    public interface IDataDomain
    {
        List<Despacho> GetFirst(int count);
    }
}