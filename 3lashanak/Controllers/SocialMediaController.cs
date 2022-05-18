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
    public class SocialMediaController : Controller
    {
        private readonly IRepository<SocialMedia> service;
        private readonly IWebHostEnvironment en;

        public SocialMediaController(IRepository<SocialMedia> service, IWebHostEnvironment en)
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
        public async Task<ActionResult> CreateAsync(SocialMedia collection, IFormFile file)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                if (file is not null)
                {
                    string path = Path.Combine(en.WebRootPath, "Images");
                    using (var Stream = new FileStream(path, FileMode.Create))
                        file.CopyTo(Stream);
                    collection.Image = Path.Combine(en.WebRootPath, "Images", file.FileName + Guid.NewGuid());
                }
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
        public ActionResult Edit(SocialMedia collection, IFormFile file)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                if(file is not null)
                {
                    string path = Path.Combine(en.WebRootPath, "Images");
                    using (var Stream = new FileStream(path, FileMode.Create))
                        file.CopyTo(Stream);
                    collection.Image = Path.Combine(en.WebRootPath, "Images", file.FileName + Guid.NewGuid());
                }
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
                SocialMedia msg = await service.GetOne(id);
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
