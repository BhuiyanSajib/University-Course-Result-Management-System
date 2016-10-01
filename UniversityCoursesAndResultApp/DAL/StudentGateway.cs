using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.DAL
{
    public class StudentGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public int SaveStudent(Student student)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_student (StudentName,Email,ContactNo,RegistrationDate,Address,Department_Id,RegistrationNo) VALUES ('" + student.StudentName + "','" +
                           student.Email + "','" + student.ContactNo + "','" + student.RegistrationDate + "','" + student.Address + "','" + student.DepartmentId + "','" + student.RegistrationNo + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffecetd = command.ExecuteNonQuery();
            return rowsAffecetd;
        }

        
    }
}