using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.DAL
{
    public class ResultGetWay
    {

        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public List<Grade> GetAllGrades()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_grades";
            SqlCommand Command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            List<Grade> grades = new List<Grade>();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Grade grade = new Grade();
                    grade.Id = int.Parse(reader["Id"].ToString());
                    grade.Grades = reader["Grade"].ToString();
                    grades.Add(grade);
                }
                reader.Close();
            }
            connection.Close();
            return grades;



        }

        public int SaveResult(Results result)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Insert Into t_results (StudentId,CourseId,GradeId) Values('" + result.StudentId + "','" + result.CourseId + "','" + result.GradeId + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }
        public bool IsresultExist(Results result)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_results WHERE StudentId ='" + result.StudentId + "' AND CourseId ='" + result.CourseId + "'";
            SqlCommand Command = new SqlCommand(query, connection);
            connection.Open();
            SqlDataReader reader = Command.ExecuteReader();
            bool isexixt=reader.HasRows; 
            reader.Close();
            connection.Close();
            return isexixt;
        }
    }
}