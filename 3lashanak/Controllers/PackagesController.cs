using _3lashanak.Models;
using _3lashanak.Models.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace _3lashanak.Controllers
{
    [Authorize]
    public class PackagesController : Controller
    {
        private readonly IRepository<Packages> service;

        public PackagesController(IRepository<Packages> service)
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
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateAsync(Packages collection)
        {
            try
            {
                var items = await service.GetAll();
                if (items.Count() > 4)
                    return View(collection);
                if(items.Select(x => x.IsMajor).Count() >= 1)
                    return View();
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
        public async Task<ActionResult> Edit(Packages collection)
        {
            try
            {
                if (!ModelState.IsValid)
                    return View();
                var items = await service.GetAll();
                if (items.Select(x => x.IsMajor).Count() >= 1)
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
                Packages msg = await service.GetOne(id);
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
