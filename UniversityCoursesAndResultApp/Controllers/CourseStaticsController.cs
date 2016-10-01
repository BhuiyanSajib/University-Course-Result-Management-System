using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models.ViewModel;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class CourseStaticsController : Controller
    {
        ViewCourseStaticsManager viewCourseStaticsManager =new ViewCourseStaticsManager();
        DepartmentManager departmentManager=new DepartmentManager();
        // GET: /CourseStatics/

        public ActionResult CourseStatics()
        {
            ViewBag.departments=departmentManager.ViewDepartment();
            return View();
        }

        public JsonResult GetCourseStatics(int departmentId)
        {
            var courseList = viewCourseStaticsManager.GetAllCourseStaticses();
            var courseStaticsById = courseList.Where(m => m.DepartmentId == departmentId).ToList();
            return Json(courseStaticsById,JsonRequestBehavior.AllowGet);

        }
    }
}
