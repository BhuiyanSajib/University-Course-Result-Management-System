using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCoursesAndResultApp.Models.ViewModel
{
    public class ViewResult
    {
        public int StudentId { set; get; }
        public string CourseCode { set; get; }
        public string CourseName { set; get; }
        public string Grade { set; get; }
    }
}