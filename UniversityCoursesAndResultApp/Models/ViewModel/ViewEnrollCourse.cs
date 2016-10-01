using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCoursesAndResultApp.Models.ViewModel
{
    public class ViewEnrollCourse
    {
        public int CourseId { set; get; }
        public string CourseName { set; get; }
        public int StudentId { set; get; }
        public bool Status { get; set; }
    }
}