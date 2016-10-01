using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCoursesAndResultApp.Models
{
    public class AssignCourseToTeacher
    {
        public int Id { set; get; }
        public int DepartmentId { set; get; }
        public int TeacherId { set; get; }
        public int CourseId { set; get; }
        public string CourseName { get; set; }
        public string CourseCode { get; set; }
        public double CourseCredit { get; set; }
        public double CreditToBeTaken { set; get; }
        public double RemainingCredit { set; get; }

        public bool Status { set; get; }
    }
}