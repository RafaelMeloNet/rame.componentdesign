using rame.componentdesign.datastore.Models;

namespace rame.componentdesign.business
{
    public interface IBusinessDomain
    {
        List<Despacho> GetDespachos();
    }
}