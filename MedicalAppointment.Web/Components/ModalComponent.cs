using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Components
{
    [ViewComponent(Name = "Modal")]
    public class ModalComponent : ViewComponent
    {
        public IViewComponentResult Invoke(string modalTittle, string controllerName, string actionName)
        {
            ViewData["ModalTitle"] = modalTittle;
            ViewData["ControllerName"] = controllerName;
            ViewData["ActionName"] = actionName;
            return View("Default");
        }
    }
}
