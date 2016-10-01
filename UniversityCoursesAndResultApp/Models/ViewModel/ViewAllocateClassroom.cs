using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCoursesAndResultApp.Models.ViewModel
{
    public class ViewAllocateClassroom
    {

       
        public int DepartmentId { get; set; }
        public string CourseCode { get; set; }
        public string CourseName { get; set; }
        public string RoomName { get; set; }
        public string Day { get; set; }
        public string TimeFrom { get; set; }
        public string TimeTo { get; set; }
         

    }
}