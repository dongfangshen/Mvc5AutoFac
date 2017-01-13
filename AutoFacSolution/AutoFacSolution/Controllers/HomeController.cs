using James.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFacSolution.Controllers
{
    public class HomeController : Controller
    {
        private readonly IStudentRepository _studentRepository;
        //由构造函数来提供Controller的依赖IStudentRepository 
        public HomeController(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public ActionResult StuList()
        {
            var students = _studentRepository.GetStudents();
            return View(students);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}