using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models.ViewModel;

namespace UniversityCoursesAndResultApp.BLL
{
    public class ViewCourseStaticsManager
    { ViewCourseStaticsGateway viewCourseStaticsGateway=new ViewCourseStaticsGateway();
        public List<ViewCourseStatics> GetAllCourseStaticsesbyDepartmentId(int departmentId)
        {
            return viewCourseStaticsGateway.GetAllCourseStaticsesbyDepartmentId(departmentId);
        }

        public List<ViewCourseStatics> GetAllCourseStaticses()
        {
            return viewCourseStaticsGateway.GetAllCourseStaticses();
        }

    }
}