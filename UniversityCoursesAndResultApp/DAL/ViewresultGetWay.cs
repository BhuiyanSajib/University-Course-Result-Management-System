using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models.ViewModel;

namespace UniversityCoursesAndResultApp.DAL
{
    public class ViewresultGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public List<ViewResult> GetAllViewReult()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select *From ResultView";
            SqlCommand command = new SqlCommand(query, connection);
            List<ViewResult> courseInfo = new List<ViewResult>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewResult viewresult = new ViewResult();
                    viewresult.StudentId = int.Parse(reader["StudentId"].ToString());
                    viewresult.CourseCode = (reader["Course_Code"].ToString());
                    viewresult.CourseName = (reader["Course_Name"].ToString());
                    viewresult.Grade = (reader["Grade"].ToString());
                    courseInfo.Add(viewresult);
                }
                reader.Close();
            }
            connection.Close();
            return courseInfo;
        }
    }
}