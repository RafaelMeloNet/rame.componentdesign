using Microsoft.AspNetCore.Mvc;
using rame.componentdesign.business;
using rame.componentdesign.datastore.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rame.componentdesign.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController(BusinessFactory businessFactory) : ControllerBase
    {
        private static DateTime dateTime = DateTime.Now;

        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Despacho> Get()
        {
            var despachos = businessFactory.BusinessDomain.GetDespachos();

            //if (dateTime.Ticks + (DateTime.Now - dateTime).Ticks >= dateTime.AddMinutes(1).Ticks)
            //{
            //    GC.Collect();

            //    dateTime = DateTime.Now.AddDays(7);
            //}

            return despachos;
        }
    }
}
