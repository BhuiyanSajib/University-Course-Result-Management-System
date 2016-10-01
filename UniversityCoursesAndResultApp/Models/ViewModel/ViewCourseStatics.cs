using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCoursesAndResultApp.Models.ViewModel
{
    public class ViewCourseStatics
    {
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string SemesterName { get; set; }
        public int DepartmentId { get; set; }
        public string TeacherName { get; set; }
        public string Status { get; set; }
    }
}