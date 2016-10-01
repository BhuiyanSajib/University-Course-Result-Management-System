using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UniversityCoursesAndResultApp.DAL;
using UniversityCoursesAndResultApp.Models;
using UniversityCoursesAndResultApp.Models.ViewModel;

namespace UniversityCoursesAndResultApp.BLL
{
    public class AllocateRoomManager
    {
        AllocateRoomGateway allocateRoomGateway=new AllocateRoomGateway();
        public int SaveAllocateClassRoom(AllocateClassroom allocateClassroom)
        {
            return allocateRoomGateway.SaveAllocateClassRoom(allocateClassroom);
        }

        public bool IsRoomFree(AllocateClassroom allocateClassroom)
        {
            return allocateRoomGateway.IsRoomFree(allocateClassroom);
        }


        public List<ViewAllocateClassroom> GetAllViewAllocatedClassRoom(int departmentId)
        {
            return allocateRoomGateway.GetAllViewAllocatedClassRoom(departmentId);
        }

        public void UnallocateRoom()
        {
           allocateRoomGateway.UnallocateRoom();
        }


    }
}