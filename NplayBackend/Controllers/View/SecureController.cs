using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace NplayBackend.Controllers.View
{
    public class SecureController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }
    }
}
