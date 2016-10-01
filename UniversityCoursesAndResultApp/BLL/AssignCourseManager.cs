using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.BLL
{
    public class AssignCourseManager
    {
        AssignCourseGateway assignCourseGateway=new AssignCourseGateway();

        public int AssignCourseToTeacher(AssignCourseToTeacher assign)
        {
            return assignCourseGateway.AssignCourseToTeacher(assign);
        }

        public List<AssignCourseToTeacher> GetAllCourseassinAssignToTeachers()
        {
            return assignCourseGateway.GetAllCourseassinAssignToTeachers();
        }

        public void UpdateRemainingCredit(double credit, int id)
        {
            assignCourseGateway.UpdateRemainingCredit(credit,id);
        }
    }
}