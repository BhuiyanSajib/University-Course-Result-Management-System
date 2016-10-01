using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.BLL
{
    public class DepartmentManager
    {
        DepartmentGateway aDepartmentGateWay = new DepartmentGateway();
        public int SaveDepartment(Department aDepartment)
        {
            return aDepartmentGateWay.SaveDepartment(aDepartment);
        }

        public bool IsDepartmentExists(Department aDepartment)
        {
            return aDepartmentGateWay.IsDepartmentExists(aDepartment);
        }

        public List<Department> ViewDepartment()
        {
            return aDepartmentGateWay.ViewDepartment();
        }

        public string GetDepartmentCodeByID(int departmentId)
        {
            string departmentCode = aDepartmentGateWay.GetDepartmentCodeById(departmentId);

            return departmentCode;
        }

        public int GetDepatmentIdByCode(string code)
        {
            int deptID = aDepartmentGateWay.GetDepatmentIdByCode(code);
            return deptID;
        }
    }
}