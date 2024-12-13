using ASPCoreMVCDapper.Data_Access_Layer.UnitOfWork;
using ASPCoreMVCDapper.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ASPCoreMVCDapper.Controllers
{
   public class HomeController : Controller
   {
      private readonly ILogger<HomeController> _logger;
      private IUnitOfWork _unitOfWork;

      public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
      {
         _logger = logger;
         _unitOfWork = unitOfWork;
      }

      public IActionResult Index()
      {
         List<Customer> model;

         model = new List<Customer>();
         model = _unitOfWork.CustomerRepository.GetAll().ToList();

         return View(model);
      }

      [HttpGet]
      public IActionResult Create()
      {
         return View();
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public IActionResult Create(Customer customer)
      {
         if (ModelState.IsValid)
         {
            _unitOfWork.CustomerRepository.SetInsertParams(customer);
            _unitOfWork.CustomerRepository.Add();

            return RedirectToAction("Index");
         }

         return View("Index");
      }

      [HttpGet]
      public IActionResult Edit(int? id)
      {
         Customer model;

         model = new Customer();

         if (id == null)
            return NotFound();

         model = _unitOfWork.CustomerRepository.FindByID(Convert.ToInt32(id));

         if (model == null)
            return NotFound();

         return View(model);
      }

      [HttpPost]
      public ActionResult Edit(Customer customer)
      {
         try
         {
            _unitOfWork.CustomerRepository.SetUpdateParams(customer);
            _unitOfWork.CustomerRepository.Update();
            return RedirectToAction("Index");
         }
         catch
         {
            return View();
         }
      }

      [HttpGet]
      public IActionResult Delete(int? id)
      {
         Customer model;

         model = new Customer();

         if (id == null)
            return NotFound();

         model = _unitOfWork.CustomerRepository.FindByID(Convert.ToInt32(id));

         if (model == null)
            return NotFound();

         return View(model);
      }

      [HttpPost]
      [ValidateAntiForgeryToken]
      public ActionResult Delete(Customer customer)
      {
         try
         {
            _unitOfWork.CustomerRepository.Delete(customer.CustomerID);
            return RedirectToAction("Index");
         }
         catch
         {
            return View();
         }
      }

      public IActionResult Privacy()
      {
         return View();
      }

      [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
      public IActionResult Error()
      {
         return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
      }
   }
}
