using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.BLL
{
    public class RoomAndDayManager
    {
        RoomAndDayGateway roomAndDayGateway=new RoomAndDayGateway();
        public List<Room> GetAllRoom()
        {
            return roomAndDayGateway.GetAllRoom();
        }

        public List<Day> GetAllDays()
        {
            return roomAndDayGateway.GetAllDay();
        }

        
    }
}