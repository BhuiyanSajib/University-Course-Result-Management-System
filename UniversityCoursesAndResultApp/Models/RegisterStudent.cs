﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCoursesAndResultApp.Models
{
    public class RegisterStudent
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public int DepartmentId { get; set; }
        public string Code { set; get; }
        public string Registration_Number { get; set; }
        public Department department { set; get; }
    }
}