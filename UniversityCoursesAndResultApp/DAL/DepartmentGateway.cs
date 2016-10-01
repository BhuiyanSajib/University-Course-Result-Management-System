using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.DAL
{
    public class DepartmentGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;

        public int SaveDepartment(Department aDepartment)
        {


            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_Department (Department_Code,Department_Name) VALUES ('" + aDepartment.Code + "','" +
                           aDepartment.Name + "')";
            SqlCommand command = new SqlCommand(query, connection);
            connection.Open();
            int rowAffecetd = command.ExecuteNonQuery();
            return rowAffecetd;
        }

        public bool IsDepartmentExists(Department aDepartment)
        {

            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT Department_Code,Department_Name FROM t_Department WHERE Department_Name='" + aDepartment.Name + " ' OR Department_Code='" +
                           aDepartment.Code + " '";
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader reader = command.ExecuteReader();
            bool departmentExists = reader.HasRows;
            reader.Close();
            aConnection.Close();
            return departmentExists;
        }


        public List<Department> ViewDepartment()
        {
            List<Department> departmentList = new List<Department>();
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_Department";
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Department aDepartment = new Department();
                    aDepartment.Id = Convert.ToInt32(reader["Department_Id"].ToString());
                    aDepartment.Code = reader["Department_Code"].ToString();
                    aDepartment.Name = reader["Department_Name"].ToString();
                    departmentList.Add(aDepartment);
                }
                reader.Close();
            }
            aConnection.Close();
            return departmentList;
        }

        public string GetDepartmentCodeById(int departmentId)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT  Department_Code FROM t_Department WHERE Department_Id = '" + departmentId + "'  ";
            SqlCommand Command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            string code = null;
            while (Reader.Read())
            {
                code = Reader["Department_Code"].ToString();
            }
            Reader.Close();
            connection.Close();
            return code;
        }

        public int GetDepatmentIdByCode(string deptcode)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string Query = "SELECT  Department_Id FROM t_Department WHERE Department_Code = '" + deptcode + "'  ";
            SqlCommand Command = new SqlCommand(Query, connection);
            connection.Open();
            SqlDataReader Reader = Command.ExecuteReader();
            int deptId = 0;
            while (Reader.Read())
            {
                deptId = Convert.ToInt32(Reader["Deartment_Id"]);
            }
            Reader.Close();
            connection.Close();
            return deptId;

        }
    }
}