using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCoursesAndResultApp.Models
{
    public class Results
    {
        public int Id { set; get; }
        public int StudentId { set; get; }
        public int DepartmentId { set; get; }
        public int CourseId { set; get; }
        public int GradeId { set; get; }
    }
}