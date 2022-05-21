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

        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.PackageId = new SelectList(await _packege.GetAll(),"Id", "Service");
            return View();
        }
        [HttpPost]
        public IActionResult Create(ServicePackeges servicePackege)
        {
            if (ModelState.IsValid)
            {
                _repository.Add(servicePackege);
                RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Edit()
        {
            ViewBag.PackageId = new  SelectList(await _packege.GetAll(), "Id", "Service");
            return View();
        }
        [HttpPost]
        public IActionResult Edit(ServicePackeges servicePackege)
        {
            if (ModelState.IsValid)
            {
                _repository.Update(servicePackege);
                RedirectToAction(nameof(Index));
            }
            return View();
        }

        public IActionResult Details(int Id)
        {
            var data = _repository.GetOne(Id);
            return View(data);
        }
    }
}
