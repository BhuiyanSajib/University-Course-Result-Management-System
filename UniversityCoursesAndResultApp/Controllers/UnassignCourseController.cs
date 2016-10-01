using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class UnassignCourseController : Controller
    {
        //
        // GET: /UnassignCourse/

        public ActionResult UnassignCourse()
        {
            return View();
        }
        [HttpPost]

        public ActionResult UnassignCourse(AssignCourseToTeacher assignCourseToTeacher)
        {

            return View();
        }

        public void UnassignAllCourse()
        {
            UnassignCourseManager unassignCourse=new UnassignCourseManager();
            unassignCourse.UnassignCourse();
        }

    }
}
