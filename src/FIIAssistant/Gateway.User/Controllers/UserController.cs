using Microsoft.AspNetCore.Mvc;

namespace Gateway.User.Controllers {
    [Route("/v1/users")]
    public class UserController : Controller
    {
        // GET
        [HttpGet]
        public JsonResult Index() {
            return new JsonResult(Ok("Students"));
        }
    }
}