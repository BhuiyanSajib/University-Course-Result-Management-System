using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class CourseController : Controller
    {
       
        CourseManager courseManager=new CourseManager();
        DepartmentManager departmentManager=new DepartmentManager();
        public ActionResult Save()
        {
            ViewBag.Departments=departmentManager.ViewDepartment();
            ViewBag.Semesters=courseManager.GetAllSemester();
            return View();
        }

        [HttpPost]
        public ActionResult Save(Course course)
        {

                if (courseManager.IsCourseExists(course))
                {
                    ViewBag.ErrorMessage= "Course already Exists";
                }
                else
                {
                    if (course.Credit >= 0.5 && course.Credit <= 5.0)
                    {
                        int rowsAffected = courseManager.SaveCourse(course);

                        if (rowsAffected > 0)
                        {
                            ViewBag.SuccessMessage= "Course inserted Successfully";
                        }
                        else
                        {
                            ViewBag.ErrorMessage= "Insert Failed";
                        }
                    }
                    else
                    {
                       ViewBag.ErrorMessage = "Credit range must be 0.5 to 5.0";
                    }
                }
             ViewBag.Departments=departmentManager.ViewDepartment();
            ViewBag.Semesters=courseManager.GetAllSemester();
            return View();
            }

           
        }


    }
