using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Configuration;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.DAL
{
    public class RoomAndDayGateway
    {
        string connectionString = WebConfigurationManager.ConnectionStrings["UniversityDBConnectionString"].ConnectionString;
        public List<Room> GetAllRoom()
        {
            List<Room> rooms = new List<Room>();
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_room";
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Room room = new Room();

                    room.Id = Convert.ToInt32(reader["Id"].ToString());
                    room.Name = reader["Name"].ToString();
                    rooms.Add(room);
                }
                reader.Close();
            }
            aConnection.Close();
            return rooms;
        }

        public List<Day> GetAllDay()
        {
            List<Day> days = new List<Day>();
            SqlConnection aConnection = new SqlConnection(connectionString);
            string query = "SELECT * FROM t_day";
            SqlCommand command = new SqlCommand(query, aConnection);
            aConnection.Open();
            SqlDataReader reader = command.ExecuteReader();

            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    Day day = new Day();

                    day.Id = Convert.ToInt32(reader["Id"].ToString());
                    day.Name = reader["Name"].ToString();
                    days.Add(day);
                }
                reader.Close();
            }
            aConnection.Close();
            return days ;
        }
    }
}