using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace UniversityCoursesAndResultApp.DAL
{
    public class UnassignCourseGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public void UnassignCourse()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE t_EnrollStudent SET Status='0' Where Status='1'";
            string aCquery = "UPDATE t_AssignCourse SET Status='0' Where Status='1'";

            SqlCommand command = new SqlCommand(query, connection);
            SqlCommand tcommand = new SqlCommand(aCquery, connection);
            connection.Open();
            command.ExecuteNonQuery();
            tcommand.ExecuteNonQuery();
            connection.Close();
        }
    }
}