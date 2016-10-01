using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class UnallocateRoomController : Controller
    {
        //
        // GET: /UnallocateRoom/

        public ActionResult UnallocateClassRoom()
        {
            return View();
        }

        [HttpPost]

        public ActionResult UnallocateClassRoom(AllocateClassroom allocateClassroom)
        {
            return View();
        }

        public void UnallocateRoom()
        {
            AllocateRoomManager unAllocateRoomManager = new AllocateRoomManager();
            unAllocateRoomManager.UnallocateRoom();
        }

    }
}
