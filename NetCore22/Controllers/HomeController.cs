using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AModel;
using IAService;
using Microsoft.AspNetCore.Mvc;
using NetCore22.Models;

namespace NetCore22.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentService _studentsverVice;
        public HomeController(IStudentService studentsverVice)
        {
            _studentsverVice = studentsverVice;           
        }
        public IActionResult Index()
        {
            return View();
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
        public IActionResult Save(Student model)
        {
            var k = _studentsverVice.Insert(model);       
            return Json(k);
        }
    }
}
