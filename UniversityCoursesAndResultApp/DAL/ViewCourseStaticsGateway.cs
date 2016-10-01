using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models.ViewModel;

namespace UniversityCoursesAndResultApp.DAL
{
    public class ViewCourseStaticsGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public List<ViewCourseStatics> GetAllCourseStaticsesbyDepartmentId(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM ViewCourseStatics WHERE DepartmentId='" + departmentId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            List<ViewCourseStatics> aList = new List<ViewCourseStatics>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewCourseStatics aCourseStatics = new ViewCourseStatics();
                    aCourseStatics.CourseCode = reader["Course_Code"].ToString();
                    aCourseStatics.CourseName = reader["Course_Name"].ToString();
                    aCourseStatics.SemesterName = reader["Semester_Name"].ToString();
                    aCourseStatics.DepartmentId = Convert.ToInt32(reader["Department_Id"].ToString());
                    aCourseStatics.TeacherName = reader["TeacherName"].ToString();
                    aCourseStatics.Status = reader["Status"].ToString();
                    aList.Add(aCourseStatics);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }

        public List<ViewCourseStatics> GetAllCourseStaticses()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM ViewCourseStatics";
            SqlCommand command = new SqlCommand(query, connection);
            List<ViewCourseStatics> aList = new List<ViewCourseStatics>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewCourseStatics aCourseStatics = new ViewCourseStatics();
                    aCourseStatics.CourseCode = reader["Course_Code"].ToString();
                    aCourseStatics.CourseName = reader["Course_Name"].ToString();
                    aCourseStatics.SemesterName = reader["Semester_Name"].ToString();
                    aCourseStatics.DepartmentId = Convert.ToInt32(reader["Department_Id"].ToString());
                    aCourseStatics.TeacherName = reader["TeacherName"].ToString();
                    aCourseStatics.Status = reader["Status"].ToString();
                    aList.Add(aCourseStatics);
                }
                reader.Close();
            }
            connection.Close();
            return aList;
        }
    }
}