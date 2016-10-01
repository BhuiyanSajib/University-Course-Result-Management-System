using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models;
using UniversityCoursesAndResultApp.Models.ViewModel;

namespace UniversityCoursesAndResultApp.DAL
{
    public class EnrollStudentGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public int SaveEnrollCourse(EnrollStudent enrollStudent)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Insert Into t_EnrollStudent (Name,Email,studentId,CourseId,EnrollDate,Status) Values('" + enrollStudent.StudentName + "','" + enrollStudent.StudentEmail + "','" + enrollStudent.StudentId + "','" + enrollStudent.CourseId + "','" + enrollStudent.EnrollDate + "','True')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public List<ViewEnrollCourse> GetAllEnrollCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Select *From t_ViewEnrollCourse ";
            SqlCommand command = new SqlCommand(query, connection);
            List<ViewEnrollCourse> viewEnrollCourses = new List<ViewEnrollCourse>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    ViewEnrollCourse viewEnrollCourse = new ViewEnrollCourse();
                    viewEnrollCourse.CourseId = int.Parse(reader["Course_Id"].ToString());
                    viewEnrollCourse.CourseName = reader["Course_Name"].ToString();
                    viewEnrollCourse.StudentId = int.Parse(reader["StudentId"].ToString());
                    viewEnrollCourse.Status = bool.Parse(reader["Status"].ToString());
                    viewEnrollCourses.Add(viewEnrollCourse);
                }
                reader.Close();
            }
            connection.Close();
            return viewEnrollCourses;
        }

        public List<EnrollStudent> GetAllEnrollsById(int studentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_EnrollStudent WHERE studentId='" + studentId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            List<EnrollStudent> list = new List<EnrollStudent>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    EnrollStudent aEnroll = new EnrollStudent();
                    aEnroll.StudentId = Convert.ToInt32(reader["studentId"].ToString());
                    aEnroll.CourseId = Convert.ToInt32(reader["CourseId"].ToString());
                    aEnroll.EnrollDate = Convert.ToDateTime(reader["EnrollDate"].ToString());
                    aEnroll.Status = Convert.ToBoolean(reader["Status"].ToString());
                    list.Add(aEnroll);
                }
                reader.Close();
            }
            connection.Close();
            return list;
        }
    }
}