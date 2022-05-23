using _3lashanak.Data;
using _3lashanak.Models;
using _3lashanak.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _3lashanak.Controllers
{
    [Authorize]
    public class MessagesController : Controller
    {
        private readonly IRepository<Messages> service;

        public MessagesController(IRepository<Messages> service)
        {
            this.service = service;
        }
        public async Task<IActionResult> Index()
        {
            return View(await service.GetAll());
        }

        public async Task<IActionResult> Details(long id)
        {
            return View(await service.GetOne(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Messages collection)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                TempData["success"] = "تم ارسال الرسالة بنجاح";
                if (service.Add(collection))
                    return LocalRedirect("/Home/Index");

                return LocalRedirect("/Home/Index");
            }
            catch
            {
                return LocalRedirect("/Home/Index");
            }
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await service.GetOne(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Messages collection)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                if (service.Update(collection))
                    return RedirectToAction(nameof(Index));
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                Messages msg = await service.GetOne(id);
                if (msg is null)
                    return View(nameof(Index));
                if (service.Delete(msg))
                    return RedirectToAction(nameof(Index));
                return View(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
