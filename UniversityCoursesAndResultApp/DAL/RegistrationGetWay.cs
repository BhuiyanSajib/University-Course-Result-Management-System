using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.DAL
{
    public class RegistrationGetWay
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public int SaveStudent(RegisterStudent registerStudent)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "Insert Into t_Student (Student_Name,Email,Contact_No,Date,Address,Department_Id,Registration_No,Code) Values('" + registerStudent.Name + "','" + registerStudent.Email + "','" + registerStudent.ContactNo + "','" + registerStudent.Date + "','" + registerStudent.Address + "','" + registerStudent.DepartmentId + "','" + registerStudent.Registration_Number + "','" + registerStudent.Code + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowsAffected;
        }
        public int GetRowCount(string regno)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            String Query = "Select count(*) from t_Student where Registration_No  LIKE '%" + regno + "%'";
            SqlCommand Command = new SqlCommand(Query, connection);
            connection.Open();
            int rowAffected = (int)Command.ExecuteScalar();
            connection.Close();
            return rowAffected;
        }

        public List<RegisterStudent> GetAllStudent()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM t_Student";
            SqlCommand Command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            List<RegisterStudent> studentList = new List<RegisterStudent>();
            while (Reader.Read())
            {
                RegisterStudent aRegisterStudent = new RegisterStudent()
                {
                    Id = (int)Reader["Id"],
                    Name = Reader["Student_Name"].ToString(),
                    Email = Reader["Email"].ToString(),
                    Code = Reader["Code"].ToString(),
                    ContactNo = Reader["Contact_No"].ToString(),
                    DepartmentId = (int)Reader["Department_Id"],
                    Registration_Number = Reader["Registration_No"].ToString()

                };
                studentList.Add(aRegisterStudent);
            }
            Reader.Close();
            connection.Close();
            return studentList;
        }
        public RegisterStudent GetStudentByRegNo(string regNo)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM t_Student where Registration_No='" + regNo + "'";
            SqlCommand Command = new SqlCommand(Query, connection);
            RegisterStudent aRegisterStudent = new RegisterStudent();
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            if (Reader.HasRows)
            {
                while (Reader.Read())
                {
                    aRegisterStudent.Id = (int)Reader["Id"];
                    aRegisterStudent.Name = Reader["Student_Name"].ToString();
                    aRegisterStudent.Email = Reader["Email"].ToString();
                    aRegisterStudent.ContactNo = Reader["Contact_No"].ToString();
                    aRegisterStudent.DepartmentId = (int)Reader["Department_Id"];
                    aRegisterStudent.Registration_Number = Reader["Registration_No"].ToString();

                }
                Reader.Close();
            }

            connection.Close();
            return aRegisterStudent;

        }
        public bool IsEmailExist(string Email)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM t_Student Where Email='" + Email + "'";
            SqlCommand Command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            bool IsExist = Reader.HasRows;
            Reader.Close();
            connection.Close();
            return IsExist;
        }
    }
}