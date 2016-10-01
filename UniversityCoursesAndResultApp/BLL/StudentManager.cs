using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.BLL
{

    public class StudentManager
    {
        StudentGateway studentGateway = new StudentGateway();

        public int SaveStudent(Student student)
        {
            return studentGateway.SaveStudent(student);
        }
    }
}