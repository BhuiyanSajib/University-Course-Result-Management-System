using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;

namespace UniversityCoursesAndResultApp.BLL
{
    public class UnassignCourseManager
    {
        UnassignCourseGateway aGateway=new UnassignCourseGateway();
        public void UnassignCourse()
        {
            aGateway.UnassignCourse();
        }

    }
}