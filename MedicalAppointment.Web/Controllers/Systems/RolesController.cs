﻿using MedicalAppointment.Application.Contracts_Interfaces_;
using MedicalAppointment.Web.Controllers.Base;
using MedicalAppointment.Web.Models.SystemModels;

namespace MedicalAppointment.Web.Controllers.System
{
    public class RolesController(IAppHttpClient client) : BaseController<RoleModel>(client, "Roles")
    {
        private readonly IAppHttpClient _client = client;

        // [HttpGet]
        // GET: RolesController
        // public async Task<IActionResult> Index()
        // {
        //     var result = await _client.GetResourseAsync<List<RoleModel>>("Roles/GetAllEntities");
        //     return View(result.Data);
        // }

        // [HttpGet]
        // GET: RolesController/Details/5
        // public async Task<IActionResult> Details(int id)
        // {
        //     var result = await _client.GetResourseAsync<RoleModel>($"Roles/GetEntityById?id={id}");
        //     return View(result.Data);
        // }

        // GET: RolesController/Create
        // public ActionResult Create()
        // {
        //     return View();
        // }

        // POST: RolesController/Create
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create(RoleModel role)
        // {
        //     try
        //     {
        //         var response = await _client.PostResourseAsync("Roles/SaveEntity", role);
        //         if (response.Success)
        //         {
        //             return RedirectToAction(nameof(Index));
        //         }
        //         else
        //         {
        //             ViewBag.Message = response.Message;
        //             return View();
        //         }
        //     }
        //     catch (Exception)
        //     {
        //         return View();
        //     }
        // }

        // [HttpGet]
        // GET: RolesController/Edit/5
        // public async Task<IActionResult> Edit(int id)
        // {
        //     var result = await _client.GetResourseAsync<RoleModel>($"Roles/GetEntityById?id={id}");
        //     return View(result.Data);
        // }

        // POST: RolesController/Edit/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit(RoleModel rol)
        // {
        //     try
        //     {
        //         var response = await _client.PutResourseAsync($"Roles/UpdateEntity", rol);
        //         if (response.Success)
        //             return RedirectToAction(nameof(Index));
        //         else
        //         {
        //             ViewBag.Message = response.Message;
        //             return View();
        //         }
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }

        // [HttpGet]
        // GET: RolesController/Delete/5
        // public ActionResult Delete(int id)
        // {
        //     return View();
        // }

        // POST: RolesController/Delete/5
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public ActionResult Delete(int id, IFormCollection collection)
        // {
        //     try
        //     {
        //         return RedirectToAction(nameof(Index));
        //     }
        //     catch
        //     {
        //         return View();
        //     }
        // }
    }
}
