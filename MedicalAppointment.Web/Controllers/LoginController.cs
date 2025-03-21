using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers
{
    [Route("Access/Login")]
    public class LoginController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }
    }
}
