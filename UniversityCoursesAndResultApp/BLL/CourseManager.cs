using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.BLL
{
    public class CourseManager
    {
        CourseGateway courseGateway = new CourseGateway();

        public int SaveCourse(Course course)
        {
            return courseGateway.SaveCourse(course);
        }

        public List<Semester> GetAllSemester()
        {
            return courseGateway.GetAllSemester();
        }

        public string GetDepartmentNameById(int DepartmentId)
        {
            return courseGateway.GetDepartmentNameById(DepartmentId);
        }

        public bool IsCourseExists(Course course)
        {
            return courseGateway.IsCourseExists(course);
        }

        public List<Course> GetAllCourses()
        {
            return courseGateway.GetAllCourses();
        }
    }
}