using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class AssignCourseToTeacherController : Controller
    {
        AssignCourseManager assignCourseManager=new AssignCourseManager();
        TeacherManager teacherManager=new TeacherManager();
        CourseManager courseManager=new CourseManager();
        DepartmentManager departmentManager=new DepartmentManager();
        //
        // GET: /AssignCourseToTeacher/

        public ActionResult AssignCourse()
        {
            ViewBag.teacherList = teacherManager.GetAllTeacher();
            ViewBag.departmentList = departmentManager.ViewDepartment();
            ViewBag.courseList = courseManager.GetAllCourses();
            return View();
        }

        [HttpPost]
        public ActionResult AssignCourse(AssignCourseToTeacher assignCourse)
        {
            if (assignCourse.RemainingCredit<assignCourse.CourseCredit)
            {
                ViewBag.Errormessage = "Course can't be assigned";
            }
            else
            {
                var assignedCourseList = assignCourseManager.GetAllCourseassinAssignToTeachers();
                var assignCourseToTeacher = assignedCourseList.FirstOrDefault(m => m.CourseId == assignCourse.CourseId);
                if (assignCourseToTeacher!=null)
                {
                    ViewBag.Errormessage = "Course already assigned";
                }
                else
                {
                    int rowsAffected = assignCourseManager.AssignCourseToTeacher(assignCourse);
                    if (rowsAffected>0)
                    {
                        assignCourseManager.UpdateRemainingCredit(assignCourse.CourseCredit,assignCourse.TeacherId);
                        ViewBag.SuccessMessage = "Course is assigned";
                    }
                    else
                    {
                        ViewBag.Errormessage = "Course assign failed";
                    }
                }
            }
            ViewBag.teacherList = teacherManager.GetAllTeacher();
            ViewBag.departmentList = departmentManager.ViewDepartment();
            ViewBag.courseList = courseManager.GetAllCourses();
            return View();
        }

        public JsonResult GetTeacherByDepartmentId(int departmentId)
        {
            var teachers = teacherManager.GetAllTeacher();
            var teacherList = teachers.Where(a => a.Departmentid == departmentId).ToList();
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetTeacherById(int teacherId)
        {
            var teachers = teacherManager.GetAllTeacher();
            var teacherList = teachers.FirstOrDefault(a => a.Id == teacherId);
            return Json(teacherList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseByDeptId(int deptId)
        {
            var course = courseManager.GetAllCourses();
            var courseList = course.Where(m => m.DepartmentId == deptId).ToList();
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCourseBycourseId(int courseId)
        {
            var course = courseManager.GetAllCourses();
            var courseList = course.FirstOrDefault(m => m.Id == courseId);
            return Json(courseList, JsonRequestBehavior.AllowGet);
        }

        //public ActionResult ViewCourse()
        //{
        //    ViewBag.departmentList = departmentManager.ViewDepartment();
        //    return View();
        //}
        //public JsonResult GetViewCourse(int deptId)
        //{
        //    var ViewCourses = viewCourseManager.GetAllViewCourse();
        //    var ViewCourseList = ViewCourses.Where(m => m.Department_Id == deptId).ToList();
        //    return Json(ViewCourseList, JsonRequestBehavior.AllowGet);
        //}

    }
}
