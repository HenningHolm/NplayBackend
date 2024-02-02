using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using NplayBackend.Features.Shared;

namespace NplayBackend.Controllers.View;
    public class LoginController : Controller
    {
        private readonly ILogger<LoginController> _logger;
        private readonly IGetSharedContentQuery _getSharedContentQuery;

        public LoginController(ILogger<LoginController> logger, IGetSharedContentQuery getSharedContentQuery)
        {
            _logger = logger;
            _getSharedContentQuery = getSharedContentQuery;
        }

        public async Task<IActionResult> Index()
        {
            var sharedContent = await _getSharedContentQuery.ExecuteAsync();
            return View(sharedContent);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }

    }
