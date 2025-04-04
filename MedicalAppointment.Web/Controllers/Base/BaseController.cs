using MedicalAppointment.Application.Contracts_Interfaces_;
using Microsoft.AspNetCore.Mvc;

namespace MedicalAppointment.Web.Controllers.Base
{
    /// <summary>
    /// Controlador base para todas las pantallas
    /// </summary>
    /// <typeparam name="TModel">Modelo que se usara para mostrar y enviar datos a las peticiones</typeparam>
    public abstract class BaseController<TModel>(IAppHttpClient client, string controllerName) : Controller
    {
        private readonly IAppHttpClient _client = client;
        private readonly string _controllerName = controllerName;

        [HttpGet]
        // GET: BaseController
        public async Task<IActionResult> Index()
        {
            var result = await _client.GetResourseAsync<List<TModel>>($"{_controllerName}/GetAllEntities");
            return View(result.Data);
        }

        [HttpGet]
        // GET: BaseController/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var result = await _client.GetResourseAsync<TModel>($"{_controllerName}/GetEntityById?id={id}");
            return View(result.Data);
        }

        // GET: BaseController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: BaseController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TModel model)
        {
            try
            {
                var response = await _client.PostResourseAsync($"{_controllerName}/SaveEntity", model!);
                if (response.Success)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    ViewBag.Message = response.Message;
                    return View();
                }
            }
            catch (Exception)
            {
                return View();
            }
        }

        [HttpGet]
        // GET: BaseController/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var result = await _client.GetResourseAsync<TModel>($"{_controllerName}/GetEntityById?id={id}");
            return View(result.Data);
        }

        // POST: BaseController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(TModel model)
        {
            try
            {
                var response = await _client.PostResourseAsync($"{_controllerName}/UpdateEntity", model!);
                if (response.Success)
                    return RedirectToAction(nameof(Index));
                else
                {
                    ViewBag.Message = response.Message;
                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // POST: BaseController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var response = await _client.DeleteResourseAsync($"{_controllerName}/RemoveEntity", id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
