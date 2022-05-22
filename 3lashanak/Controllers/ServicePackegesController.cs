using _3lashanak.Models;
using _3lashanak.Models.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace _3lashanak.Controllers
{
    
    public class ServicePackegesController : Controller
    {
        private readonly IRepository<ServicePackeges> _repository;
        private readonly IRepository<Packages> _packege;
        public ServicePackegesController(IRepository<ServicePackeges> repository,
            IRepository<Packages> packege)
        {
            _repository = repository;
            _packege = packege;
        }

        public async Task<IActionResult> Index()
        {
            var data = await _repository.GetAll();
            return View(data);
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.PackageId = new SelectList(await _packege.GetAll(),"Id", "Title");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServicePackeges servicePackege)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(servicePackege);
               return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit(int Id)
        {
            ViewBag.PackageId = new  SelectList(await _packege.GetAll(), "Id", "Title");
            var data = _repository.GetOne(Id).Result;
            return View(data);
        }
        [HttpPost]
        public IActionResult Edit(ServicePackeges servicePackege)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(servicePackege);
              return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Details(int Id)
        {
            var data = _repository.GetOne(Id).Result;
            return View(data);
        }
        public IActionResult Delete(int Id)
        {
           var service =  _repository.GetOne(Id).Result;
            var data = _repository.Delete(service);
            return RedirectToAction(nameof(Index));
        }
    }
}
