using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class StudentRegistrationController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        RegistrationManager registrationManager = new RegistrationManager();
        CourseManager courseManager = new CourseManager();
        EnrollStudentManager enrollStudentManager = new EnrollStudentManager();

        //
        // GET: /StudentRegistration/

        public ActionResult RegisterStudent()
        {
            List<Department> aDepartments = departmentManager.ViewDepartment();
            ViewBag.Departmentlist = aDepartments;
            return View();
        }
        [HttpPost]
        public ActionResult RegisterStudent(RegisterStudent registerStudent)
        {
            List<Department> aDepartments = departmentManager.ViewDepartment();
            ViewBag.Departmentlist = aDepartments;
            string departmentCode = departmentManager.GetDepartmentCodeByID(registerStudent.DepartmentId);
            registerStudent.Code = departmentCode;

            string regno = departmentCode + "-";
            regno += registerStudent.Date.Year.ToString();
            regno += "-";
            int regNoId = registrationManager.GetRowCount(regno);
            //string s = (regNoId + 1).ToString("000");
            if (regNoId == 0)
            {
                regno += "00" + 1;
            }
            else
            {
                if (regNoId >= 1 && regNoId <= 9)
                {
                    int temp = regNoId + 1;
                    regno += "00" + temp;
                }
                else if (regNoId >= 10 && regNoId <= 99)
                {
                    int temp = regNoId + 1;
                    regno += "0" + temp;

                }
                else
                {
                    regno += "" + regNoId + 1;

                }
            }
            registerStudent.Registration_Number = regno;


            if (registrationManager.IsEmailExist(registerStudent.Email))
            {
                ViewBag.ErrorMessage = "Email already Exists";
            }
            else
            {
                int rowsAffected = registrationManager.SaveStudent(registerStudent);

                if (rowsAffected > 0)
                {
                    ViewBag.SuccessMessage = "Student inserted Successfully";
                }
                else
                {
                    ViewBag.ErrorMessage = "Insert Failed";
                }
            }
            return View();
        }

        public ActionResult EnrollStudent()
        {
            ViewBag.StudentList = registrationManager.GetAllStudent();
            ViewBag.DepartmentList = departmentManager.ViewDepartment();
            ViewBag.CourseList = courseManager.GetAllCourses();
            return View();
        }
        [HttpPost]
        public ActionResult EnrollStudent(EnrollStudent enrollStudent)
        {
            ViewBag.StudentList = registrationManager.GetAllStudent();
            ViewBag.DepartmentList = departmentManager.ViewDepartment();
            ViewBag.CourseList = courseManager.GetAllCourses();


            var courselist = enrollStudentManager.GetAllEnrollsById(enrollStudent.StudentId);
            var isExists = courselist.FirstOrDefault(a => a.CourseId == enrollStudent.CourseId);

            if (enrollStudent.CourseId == 0)
            {
                ViewBag.message = "Select Course";
            }
            else
            {
                if (isExists != null)
                {
                    ViewBag.message = "This Course Already Assigned";
                }
                else
                {
                    enrollStudentManager.SaveEnrollCourse(enrollStudent);
                    ViewBag.message = "Course Enrolled Successfully";
                }
            }
      
            return View();
        }
        public JsonResult GetStudentInfoByStudentId(int studentId)
        {
            var student = registrationManager.GetAllStudent();
            var StudentList = student.Where(m => m.Id == studentId).ToList();

            return Json(StudentList.Select(c => new
            {
                name = c.Name,
                email = c.Email,
                department = departmentManager.ViewDepartment().Where(x => x.Id == c.DepartmentId).Select(x => x.Name).Single()
            }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoursesByStudentId(int studentId)
        {
            var student = registrationManager.GetAllStudent().Find(m => m.Id == studentId);
            var courses = courseManager.GetAllCourses().Where(c => c.DepartmentId == student.DepartmentId);
            return Json(new SelectList(courses, "Id", "Name"));
        }


    }
}
