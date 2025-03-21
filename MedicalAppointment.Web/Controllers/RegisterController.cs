using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers
{
    [Route("Access/SignIn")]
    public class RegisterController : Controller
    {
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        //[HttpPost]
        //public Task<IActionResult> Register(PatientUserModel user)
        //{
        //    return View();
        //}
    }
}
