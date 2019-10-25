using Microsoft.AspNetCore.Mvc;

namespace tools.Controllers
{
    public class IndexController : Controller
    {
        // GET
        [HttpGet]
        [Route("api/v1/Index")]
        public string Index()
        {
            return "Tools were free to every one,you can use it freely and freely!";
        }
    }
}