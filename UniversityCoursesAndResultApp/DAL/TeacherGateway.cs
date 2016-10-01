using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.DAL
{
    public class TeacherGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public int SaveTeacher(Teacher teacher)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_teacher (TeacherName,Email,Address,ContactNo,DepartmentId,DesignationId,CreditTaken,RemainingCredit) VALUES ('" + teacher.Name + "','" +
                           teacher.Email + "','" + teacher.Address + "','" + teacher.ContactNo + "','" + teacher.Departmentid + "','" + teacher.DesignationId + "','" + teacher.CreditTaken + "','" + teacher.RemainingCredit + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffecetd = command.ExecuteNonQuery();
            return rowsAffecetd;
        }
        public bool IsEmailExists(Teacher teacher)
        {

            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT *FROM t_teacher WHERE Email='" + teacher.Email + "'";
                           
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool courseExists = reader.HasRows;
            reader.Close();
            aConnection.Close();
            return courseExists;
        }

        public List<Designation> GetAllDesignation()
        {
            List<Designation> designations = new List<Designation>();
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_designation";
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Designation designation = new Designation();

                    designation.Id = Convert.ToInt32(reader["DesignationId"].ToString());
                    designation.Name = reader["DesignationName"].ToString();
                    designations.Add(designation);
                }
                reader.Close();
            }
            aConnection.Close();
            return designations;
        }

        public List<Teacher> GetAllTeacher()
        {
            List<Teacher> teacherList = new List<Teacher>();
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_teacher";
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Teacher teacher = new Teacher();
                    teacher.Id = int.Parse(reader["TeacherId"].ToString());
                    teacher.Name = reader["TeacherName"].ToString();
                    teacher.Email = reader["Email"].ToString();
                    teacher.DesignationId = int.Parse(reader["DesignationId"].ToString());
                    teacher.Departmentid = int.Parse(reader["DepartmentId"].ToString());
                    teacher.CreditTaken = double.Parse(reader["CreditTaken"].ToString());
                    teacher.RemainingCredit = double.Parse(reader["RemainingCredit"].ToString());
                    teacherList.Add(teacher);
                }
                reader.Close();
            }
            aConnection.Close();
            return teacherList;
        }

        public int UpdateRemainingCreditInTeacher(Teacher teacher)
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE t_teacher set RemainingCredit = '" + teacher.RemainingCredit + "' Where TeacherId = '" + teacher.Id + "'";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowsAffecetd = command.ExecuteNonQuery();
            return rowsAffecetd;
        }

        public Teacher GetTeacherById(int? teacherId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT * FROM t_teacher WHERE TeacherId = '" + teacherId + "'";
            connection.Open();
            SqlCommand Command = new SqlCommand(Query, connection);
            Teacher teacher = new Teacher();
            SqlDataReader reader = Command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {

                    teacher.Id = int.Parse(reader["TeacherId"].ToString());
                    teacher.Name = reader["TeacherName"].ToString();
                    teacher.Email = reader["Email"].ToString();
                    teacher.DesignationId = int.Parse(reader["DesignationId"].ToString());
                    teacher.Departmentid = int.Parse(reader["DepartmentId"].ToString());
                    teacher.CreditTaken = double.Parse(reader["CreditTaken"].ToString());
                    teacher.RemainingCredit = double.Parse(reader["RemainingCredit"].ToString());

                }
                reader.Close();
            }
            connection.Close();
            return teacher;

        }

    }
}