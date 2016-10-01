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
    public class AllocateRoomGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public int SaveAllocateClassRoom(AllocateClassroom allocateClassRoom)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            string query = "INSERT INTO t_allocateClassroom(DepartmentId,CourseId,RoomId,DayId,TimeFrom,TimeTo,Status) Values('" +
                    allocateClassRoom.DepartmentId + "','" + allocateClassRoom.CourseId + "','" +
                    allocateClassRoom.RoomId + "','" + allocateClassRoom.DayId + "','" +
                    allocateClassRoom.TimeFrom + "','" + allocateClassRoom.TimeTo + "','true')";
            SqlCommand command=new SqlCommand(query,connection);
            connection.Open();
            int rowAffected = command.ExecuteNonQuery();
            connection.Close();
            return rowAffected;
        }

        public bool IsRoomFree(AllocateClassroom allocateClassroom)
        {
            SqlConnection connection = new SqlConnection(connectionString);
            //Query = "select * from AllocateClassRoom  where  DateFrom between'"+dateTimeFrom+"' and '"+dateTimeTo+"' and Dateto between '"+dateTimeFrom+"' and '"+dateTimeTo+"' and DayId='"+dayId+"' and RoomId='"+roomId+"'";

            //Query = "select COUNT(*) from AllocateClassRoom as a where a.DateTo >='" + dateTimeFrom + "' and a.DateTo<='" + dateTimeTo + "' and a.DateFrom >='"+dateTimeFrom+"' and a.DateFrom<='"+dateTimeTo+"'  and DayId ='" + dayId + "' and RoomId= '" + roomId + "'";
            var allocateRoom="SELECT *FROM  t_allocateClassroom a WHERE (a.RoomId='"+allocateClassroom.RoomId+
            "' AND a.DayId='"+allocateClassroom.DayId+"') ";
            if (allocateRoom!=null)
            {
                var query = "SELECT *FROM t_allocateClassroom a WHERE (a.TimeTo>='" + allocateClassroom.TimeFrom +
                            "' AND a.TimeFrom <='" + allocateClassroom.TimeTo + "' AND Status='True')";
                SqlCommand command = new SqlCommand(query, connection);


                connection.Open();

                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return false;
                }
                reader.Close();
            }
         
           
            connection.Close();
            return true;

        }

        public List<ViewAllocateClassroom> GetAllViewAllocatedClassRoom(int departmentId)
        {
            SqlConnection connection=new SqlConnection(connectionString);
            string query = "SELECT * From ViewAllocateClassroom WHERE department_Id='"+departmentId+"'";
            SqlCommand command = new SqlCommand(query, connection);
            List<ViewAllocateClassroom> aViewAllocatedClassRooms = new List<ViewAllocateClassroom>();
            connection.Open();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                ViewAllocateClassroom viewAllocateClassroom=new ViewAllocateClassroom();
                viewAllocateClassroom.DepartmentId = (int)reader["Department_Id"];
                viewAllocateClassroom.CourseCode = reader["Course_Code"].ToString();
                viewAllocateClassroom.CourseName = reader["Course_Name"].ToString();
                viewAllocateClassroom.RoomName = reader["RoomName"].ToString();
                viewAllocateClassroom.Day = reader["DayName"].ToString();
                viewAllocateClassroom.TimeFrom = reader["TimeFrom"].ToString();
                viewAllocateClassroom.TimeTo = reader["TimeTo"].ToString();
                //string startTime;
                //string endTime;
                //if (reader["TimeFrom"] == DBNull.Value)
                //{
                //    startTime = "";

                //}
                //else
                //{
                //    startTime = Convert.ToDateTime(reader["TimeFrom"]).ToString("HH:mm  tt");

                //}
                //if (reader["TimeTo"] == DBNull.Value)
                //{
                //    endTime = "";
                //}
                //else
                //{
                //    DateTime EndTime = Convert.ToDateTime(reader["TimeTo"]).AddMinutes(+1);
                //    endTime = EndTime.ToString("HH:mm tt");

                //}
                //viewAllocateClassroom.TimeFrom = startTime;


                //viewAllocateClassroom.TimeTo = endTime;


                //aViewClassRoom.STartTime =(Reader["StartFrom"]).ToString();
                //aViewClassRoom.EndTime =  (Reader["Endto"]).ToString();
                aViewAllocatedClassRooms.Add(viewAllocateClassroom);
            }
            reader.Close();
            connection.Close();
            return aViewAllocatedClassRooms;


        }

        public void UnallocateRoom()
        {

            SqlConnection connection = new SqlConnection(connectionString);
            string query = "UPDATE t_allocateClassroom SET Status='0' Where Status='1'";
            SqlCommand command = new SqlCommand(query, connection);
            
            connection.Open();
            command.ExecuteNonQuery();
            connection.Close();
        } 
    }
}