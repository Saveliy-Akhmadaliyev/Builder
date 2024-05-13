using Microsoft.AspNetCore.Mvc;

namespace Простое_расписание.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
