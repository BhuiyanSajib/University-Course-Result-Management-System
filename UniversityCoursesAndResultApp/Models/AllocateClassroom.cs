using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace UniversityCoursesAndResultApp.Models
{
    public class AllocateClassroom
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please select a Department")]
        public int DepartmentId { get; set; }
         [Required(ErrorMessage = "Please select a Course")]
        public int CourseId { get; set; }
         [Required(ErrorMessage = "Please select a Room")]
        public int RoomId { get; set; }
         [Required(ErrorMessage = "Please select a Day")]
        public int DayId { get; set; }
         [Required(ErrorMessage = "Please Enter time from")]
        public DateTime TimeFrom { get; set; }
        [Required(ErrorMessage = "Please Enter time to")]
        public DateTime TimeTo { get; set; }

    }
} 