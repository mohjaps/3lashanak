using _3lashanak.Models;
using _3lashanak.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace _3lashanak.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly IRepository<Settings> service;
        private readonly IWebHostEnvironment en;

        public SettingsController(IRepository<Settings> service, IWebHostEnvironment en)
        {
            this.service = service;
            this.en = en;
        }
        public async Task<IActionResult> Index()
        {
            var data =  service.GetAll().Result.Where(x => x.Key != "Subscribe").ToList();
            return View(data);
        }

        public async Task<IActionResult> GetSubscribe()
        {
            var data = service.GetAll().Result.Where(x => x.Key == "Subscribe").ToList();
            return View(data);
        }

        public async Task<IActionResult> Details(long id)
        {
            return View(await service.GetOne(id));
        }

        public ActionResult Create()
        {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Settings collection)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    TempData["SuccessSub"] = "يرجى ادخال ايميل بشكل صحيح";
                    return LocalRedirect("/Home/Index");
                   
                }
                    
                TempData["SuccessSub"] = "تم ارسال طلب اشتراك";
                if (service.Add(collection))
                    return LocalRedirect("/Home/Index");
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
        public  ActionResult Edit(Settings collection, IFormFile file)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                if (file is not null)
                {
                    string path = Path.Combine("/Index/images/"+ Guid.NewGuid().ToString() + file.FileName);
                    using (var Stream = new FileStream(en.WebRootPath + path, FileMode.Create))
                        file.CopyTo(Stream);
                    collection.Icon = path;
                }
                else
                {
                    var x = service.GetOne(collection.Id).Result;

                    collection.Icon = x.Icon;
                }
             
                var data = new Settings
                {
                    Icon = collection.Icon,
                    Key = collection.Key,
                    Id = collection.Id,
                    Name = collection.Name,
                    Type = collection.Type,
                    Value  = collection.Value
                };
                if (service.Update(data))
                    return RedirectToAction(nameof(Index));
                return View();
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
