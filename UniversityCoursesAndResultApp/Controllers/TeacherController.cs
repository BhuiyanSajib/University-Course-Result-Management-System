using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class TeacherController : Controller
    {
      TeacherManager teacherManager=new TeacherManager();
        DepartmentManager departmentManager=new DepartmentManager();

        public ActionResult SaveTeacher()
        {
            ViewBag.Departments = departmentManager.ViewDepartment();
            ViewBag.Designation = teacherManager.GetAllDesignation();
            return View();
        }

        [HttpPost]
        public ActionResult SaveTeacher(Teacher teacher)
        {
            if (teacherManager.IsEmailExists(teacher))
            {
                ViewBag.ErrorMessage = "Email already Exists";
            }
            else
            {
                if (teacher.CreditTaken<0)
                {
                    ViewBag.ErrorMessage = "Credit to be taken must contain a non-negative value";
                }
                else
                {
                    teacher.RemainingCredit = teacher.CreditTaken;
                    int rowsAffected = teacherManager.SaveTeacher(teacher);

                    if (rowsAffected > 0)
                    {
                        ViewBag.SuccessMessage = "Teacher inserted Successfully";
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "Insert Failed";
                    }
                }
            }
            ViewBag.Departments = departmentManager.ViewDepartment();
            ViewBag.Designation = teacherManager.GetAllDesignation();
            return View();
        }



    }
}
