using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.BLL
{
    public class TeacherManager
    {
        TeacherGateway teacherGateway=new TeacherGateway();

        public int SaveTeacher(Teacher teacher)
        {
            return teacherGateway.SaveTeacher(teacher);
        }

        public bool IsEmailExists(Teacher teacher)
        {
            return teacherGateway.IsEmailExists(teacher);
        }

        public List<Designation> GetAllDesignation()
        {
            return teacherGateway.GetAllDesignation();
        }

        public List<Teacher> GetAllTeacher()
        {
            return teacherGateway.GetAllTeacher();
        }

        public Teacher GetTeacherById(int? teacherId)
        {
            return teacherGateway.GetTeacherById(teacherId);
        }

        public int UpdateRemainingCreditInTeacher(Teacher teacher)
        {
            return teacherGateway.UpdateRemainingCreditInTeacher(teacher);
        }
    }
}