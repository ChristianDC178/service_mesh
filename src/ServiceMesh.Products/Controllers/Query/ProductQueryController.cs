using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ServiceMesh.Products.Controllers.Query
{
    [ApiController]
    [Route("product")]
    public class ProductQueryController : ControllerBase
    {

        public ProductQueryController()
        { 
        }

        [HttpGet]
        public string GetProducts()
        {
            return "hello";
        }

    }
}
