using _3lashanak.Models;
using _3lashanak.Models.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;

namespace _3lashanak.Controllers
{
    public class SettingsControllers : Controller
    {
        private readonly IRepository<Settings> service;
        private readonly IWebHostEnvironment en;

        public SettingsControllers(IRepository<Settings> service, IWebHostEnvironment en)
        {
            this.service = service;
            this.en = en;
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Settings collection)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();

                if (service.Add(collection))
                    return RedirectToAction(nameof(Index));
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        public async Task<IActionResult> Edit(long id)
        {
            return View(await service.GetOne(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Settings collection, IFormFile file)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                string path = Path.Combine(en.WebRootPath, "Images");
                using (var Stream = new FileStream(path, FileMode.Create))
                    file.CopyTo(Stream);
                collection.Icon = Path.Combine(en.WebRootPath, "Images", file.FileName + Guid.NewGuid());
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
                Settings msg = await service.GetOne(id);
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
