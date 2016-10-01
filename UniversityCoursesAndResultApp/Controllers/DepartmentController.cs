using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class DepartmentController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();

        public ActionResult SaveDepartment()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult SaveDepartment(Department department)
        {
            
            int codeLength = department.Code.Length;


            bool IsDepartmentExists = departmentManager.IsDepartmentExists(department);

            if (IsDepartmentExists)
            {
                ViewBag.Message = "Department Name or Code Exists";
            }
            else
            {
                if (codeLength >= 2 && codeLength <= 7)
                {
                    var rowAffecetd = departmentManager.SaveDepartment(department);

                    if (rowAffecetd > 0)
                    {
                        ViewBag.Message = "Deparetment Name and Code inserted Successfully";
                    }
                    else
                    {
                        ViewBag.Message = "Insert Failed";
                    }
                }
                else
                {
                   ViewBag.Message = "Code must be two (2) to seven (7) characters long";
                }
            }
            return View();
        }

        public ActionResult ViewDepartment()
        {
            var departments = departmentManager.ViewDepartment();
            ViewBag.departments = departments;
            return View();
        }
       
    }
}
