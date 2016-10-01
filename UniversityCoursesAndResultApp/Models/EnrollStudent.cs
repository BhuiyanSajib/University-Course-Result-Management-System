using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCoursesAndResultApp.Models
{
    public class EnrollStudent
    {
        public int Id { set; get; }
        public int StudentId { set; get; }
        public string StudentName { set; get; }
        public string StudentEmail { set; get; }
        public int CourseId { set; get; }
        public DateTime EnrollDate { set; get; }
        public bool Status { get; set; }    

    }
}