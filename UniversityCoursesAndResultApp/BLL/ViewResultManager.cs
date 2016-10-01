using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models.ViewModel;

namespace UniversityCoursesAndResultApp.BLL
{
    public class ViewResultManager
    {

        ViewresultGetWay viewResultGetWay = new ViewresultGetWay();
        public List<ViewResult> GetAllViewCourse()
        {
            return viewResultGetWay.GetAllViewReult();
        }
    }
}