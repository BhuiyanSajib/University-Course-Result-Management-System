using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class StudentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        StudentManager studentManager = new StudentManager();

        public ActionResult StudentRegistration()
        {
            ViewBag.departments= departmentManager.ViewDepartment();
            return View();
        }

        [HttpPost]
        public ActionResult StudentRegistration(Student student)
        {
            ViewBag.departments= departmentManager.ViewDepartment();
            return View();
        }

    }
}
