using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models;
using UniversityCoursesAndResultApp.Models.ViewModel;

namespace UniversityCoursesAndResultApp.BLL
{
    public class EnrollStudentManager
    {
        EnrollStudentGetWay enrollStudentGetway = new EnrollStudentGetWay();
        public int SaveEnrollCourse(EnrollStudent enrollStudent)
        {
            return enrollStudentGetway.SaveEnrollCourse(enrollStudent);
        }

        public List<ViewEnrollCourse> GetAllEnrollCourse()
        {
            return enrollStudentGetway.GetAllEnrollCourse();
        }

        public List<EnrollStudent> GetAllEnrollsById(int studentId)
        {
            return enrollStudentGetway.GetAllEnrollsById(studentId);
        } 
    }
}