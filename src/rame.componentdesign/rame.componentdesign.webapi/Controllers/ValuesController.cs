using Microsoft.AspNetCore.Mvc;
using rame.componentdesign.business;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace rame.componentdesign.webapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController(BusinessFactory businessFactory) : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            bool isBootstrapOk = businessFactory.BusinessDomain.CheckBootstrap();

            if(!isBootstrapOk)
            {
                return [];
            }

            return ["value1", "value2"];
        }
    }
}
