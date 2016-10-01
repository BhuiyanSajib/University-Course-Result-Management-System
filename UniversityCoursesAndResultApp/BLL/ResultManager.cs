using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.BLL
{
    public class ResultManager
    {
        ResultGetWay resultGetWay = new ResultGetWay();
        public List<Grade> GetAllGrades()
        {
            return resultGetWay.GetAllGrades();
        }

        public int SaveResult(Results result)
        {
            return resultGetWay.SaveResult(result);
        }

        public bool IsresultExist(Results result)
        {
            return resultGetWay.IsresultExist(result);
        }
    }
}