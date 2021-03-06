﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.Models;
using UniversityCoursesAndResultApp.Models.ViewModel;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class AllocateClassroomController : Controller
    {
        DepartmentManager departmentManager = new DepartmentManager();
        CourseManager courseManager = new CourseManager();
        RoomAndDayManager roomAndDayManager = new RoomAndDayManager();
        AllocateRoomManager allocateRoomManager=new AllocateRoomManager();

        //
        // GET: /AllocateRoom/

        public ActionResult AllocateClassroom()
        {
            ViewBag.departments = departmentManager.ViewDepartment();
            ViewBag.courses = courseManager.GetAllCourses();
            ViewBag.rooms = roomAndDayManager.GetAllRoom();
            ViewBag.days = roomAndDayManager.GetAllDays();
            return View();
        }

        [HttpPost]
        public ActionResult AllocateClassroom(AllocateClassroom allocateClassroom)
        {
            ViewBag.departments = departmentManager.ViewDepartment();
            ViewBag.courses = courseManager.GetAllCourses();
            ViewBag.rooms = roomAndDayManager.GetAllRoom();
            ViewBag.days = roomAndDayManager.GetAllDays();
            
            if (allocateRoomManager.IsRoomFree(allocateClassroom))
            {
                int rowsAffected = allocateRoomManager.SaveAllocateClassRoom(allocateClassroom);
                if (rowsAffected > 0)
                {
                    ViewBag.SuccessMessage = "Room is allocated";
                }
                else
                {
                    ViewBag.ErrorMessage = "Room allocation is not successful";
                }
                
            }
            else
            {
                ViewBag.ErrorMessage = "Room is not free";
            }
            return View();
        }

        public ActionResult ViewAllocatedClass()
        {
            List<Department> aDepartments = departmentManager.ViewDepartment();
            ViewBag.departments = aDepartments;
            return View();
        }

       
        public JsonResult GetCourseBydeptId(int departmentId)
        {
            var course = courseManager.GetAllCourses();
            var acourseList = course.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(acourseList, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAllocatedRoomViewByDepartmentId(int departmentId)
        {
            var aViewAllocatedClassRooms =
                allocateRoomManager.GetAllViewAllocatedClassRoom(departmentId);
            var seletedViewAllocatedClassRooms = aViewAllocatedClassRooms.Where(a => a.DepartmentId == departmentId).ToList();
            return Json(seletedViewAllocatedClassRooms, JsonRequestBehavior.AllowGet);
        }
    }
}

