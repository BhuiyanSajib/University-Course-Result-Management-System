using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.DAL
{
    public class CourseGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public int SaveCourse(Course course)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_courses (Course_Code,Course_Name,Credit,Description,Semester_Id,Department_Id) VALUES ('" + course.Code + "','" +
                           course.Name + "','" + course.Credit + "','" + course.Description + "','" + course.SemesterId + "','" + course.DepartmentId + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffecetd = command.ExecuteNonQuery();
            return rowsAffecetd;
        }

        public List<Semester> GetAllSemester()
        {
            List<Semester> semesters = new List<Semester>();
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_semester";
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Semester semester = new Semester();

                    semester.Id = Convert.ToInt32(reader["Semester_Id"].ToString());
                    semester.Name = reader["Semester_Name"].ToString();
                    semesters.Add(semester);
                }
                reader.Close();
            }
            aConnection.Close();
            return semesters;
        }

        public string GetDepartmentNameById(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "SELECT Department_Name FROM t_department WHERE Department_Id='" + departmentId + "'";
            SqlCommand command = new SqlCommand(query, connection);
            string DepartmentName = null;
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    DepartmentName = reader["Department_Name"].ToString();
                }
                reader.Close();
            }
            connection.Close();
            return DepartmentName;
        }

        public bool IsCourseExists(Course course)
        {

            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT Course_Code,Course_Name FROM t_courses WHERE Course_Name='" + course.Name + " ' OR Course_Code='" +
                           course.Code + " '";
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool courseExists = reader.HasRows;
            reader.Close();
            aConnection.Close();
            return courseExists;
        }

        public List<Course> GetAllCourses()
        {
            List<Course> courses = new List<Course>();
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_courses";
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Course course = new Course();

                    course.Id = Convert.ToInt32(reader["Course_Id"]);
                    course.Name = reader["Course_Name"].ToString();
                    course.Code = reader["Course_Code"].ToString();
                    course.Description = reader["Description"].ToString();
                    course.Credit = Convert.ToDouble(reader["Credit"]);
                    course.SemesterId = Convert.ToInt32(reader["Semester_Id"]);
                    course.DepartmentId = Convert.ToInt32(reader["Department_Id"]);


                    courses.Add(course);
                }
                reader.Close();
            }
            aConnection.Close();
            return courses;
        }

        public Course GetAllCourseById(int? courseId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM t_courses WHERE Course_Id = '" + courseId + "'";
            connection.Open();
            SqlCommand Command = new SqlCommand(Query, connection);
            Course aCourse = new Course();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    aCourse.DepartmentId = (int)Reader["Course_Id"];
                    aCourse.Code = Reader["Course_Code"].ToString();
                    aCourse.Name = Reader["Course_Name"].ToString();
                    aCourse.Credit = Convert.ToDouble(Reader["Credit"]);
                    aCourse.Description = Reader["Description"].ToString();
                    aCourse.SemesterId = (int)Reader["Semester_Id"];
                    aCourse.DepartmentId = (int)Reader["Department_Id"];
                    string a = Reader["Teacher_Id"].ToString();
                    if (a == "")
                    {
                        aCourse.TeacherId = 0;
                    }
                    else
                        aCourse.TeacherId = (int)Reader["Teacher_Id"];
                }
                Reader.Close();
            }
            connection.Close();
            return aCourse;

        }
    }
}