using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.DAL
{
    public class AssignCourseGateway
    {
        private string connectionString =
            WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;

        public int AssignCourseToTeacher(AssignCourseToTeacher assign)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_AssignCourse (Teacher_Id,Course_Id,Status) VALUES('" + assign.TeacherId +
                           "','" + assign.CourseId + "','1')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }

        public List<AssignCourseToTeacher> GetAllCourseassinAssignToTeachers()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_AssignCourse";
            SqlCommand command = new SqlCommand(query, connection);
            List<AssignCourseToTeacher> assignCourseTo = new List<AssignCourseToTeacher>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    AssignCourseToTeacher assignToTeacher = new AssignCourseToTeacher();
                    assignToTeacher.TeacherId = Convert.ToInt32(reader["Teacher_Id"].ToString());
                    assignToTeacher.CourseId = Convert.ToInt32(reader["Course_Id"].ToString());
                    assignToTeacher.Status = Convert.ToBoolean(reader["Status"].ToString());
                    assignCourseTo.Add(assignToTeacher);
                }
                reader.Close();
            }
            connection.Close();
            return assignCourseTo;
        }

        public void UpdateRemainingCredit(double credit, int id)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE  t_teacher SET RemainingCredit-='" + credit + "' WHERE Id='" + id + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();

        }
    }
}