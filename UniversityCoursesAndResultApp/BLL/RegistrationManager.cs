using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.BLL
{
    public class RegistrationManager
    {
        RegistrationGetWay registrationGetWay = new RegistrationGetWay();

        public int SaveStudent(RegisterStudent registerStudent)
        {
            return registrationGetWay.SaveStudent(registerStudent);
        }
        public int GetRowCount(string regno)
        {
            return registrationGetWay.GetRowCount(regno);
        }
        public List<RegisterStudent> GetAllStudent()
        {
            return registrationGetWay.GetAllStudent();
        }
        public RegisterStudent GetStudentByRegNo(string regNo)
        {
            return registrationGetWay.GetStudentByRegNo(regNo);
        }

        public bool IsEmailExist(string Email)
        {
            return registrationGetWay.IsEmailExist(Email);
        }
    }
}