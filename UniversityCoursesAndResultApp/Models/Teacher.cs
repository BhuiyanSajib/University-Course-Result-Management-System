using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UniversityCoursesAndResultApp.Models
{
    public class Teacher
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string ContactNo { get; set; }
        public int DesignationId { get; set; }
        public int Departmentid { get; set; }
        public double CreditTaken { get; set; }
        public double RemainingCredit { get; set; }

    }
}
