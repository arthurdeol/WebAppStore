using Microsoft.AspNetCore.Mvc;

namespace ModernStore.Api.Controllers
{
    public class ProductController : Controller
    {
        [HttpGet]
        [Route("produtos/{number}")]
        public string Teste(string number)
        {
            return $"Produto {number}";
        }
    }
}
