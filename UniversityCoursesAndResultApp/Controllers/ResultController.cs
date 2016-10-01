using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using UniversityCoursesAndResultApp.BLL;
using UniversityCoursesAndResultApp.Models;

namespace UniversityCoursesAndResultApp.Controllers
{
    public class ResultController : Controller
    {
        //
        // GET: /Result/

        DepartmentManager departmentManager = new DepartmentManager();
        RegistrationManager registrationManager = new RegistrationManager();
        CourseManager courseManager = new CourseManager();
        ResultManager resultManager = new ResultManager();
        EnrollStudentManager enrollStudentManager = new EnrollStudentManager();
        ViewResultManager viewResultManager = new ViewResultManager();
        List<ViewResult> resultList = new List<ViewResult>();

        public ActionResult SaveResult()
        {
            ViewBag.StudentList = registrationManager.GetAllStudent();
            ViewBag.DepartmentList = departmentManager.ViewDepartment();
            ViewBag.CourseList = courseManager.GetAllCourses();
            ViewBag.grades = resultManager.GetAllGrades();
            return View();
        }
        [HttpPost]
        public ActionResult SaveResult(Results result)
        {
            
            if (resultManager.IsresultExist(result))
            {
                ViewBag.message = "Results Already Inserted";
            }
            else
            {
                int rowsAffected = resultManager.SaveResult(result);
                if (rowsAffected > 0)
                {
                    ViewBag.message = "Save Successfully";
                }
                else
                {
                    ViewBag.message = "Save Failed";
                }
            }
            ViewBag.StudentList = registrationManager.GetAllStudent();
            ViewBag.DepartmentList = departmentManager.ViewDepartment();
            ViewBag.CourseList = courseManager.GetAllCourses();
            ViewBag.grades = resultManager.GetAllGrades();
            return View();
        }
        public JsonResult GetStudentInfoByStudentId(int studentId)
        {
            var student = registrationManager.GetAllStudent();
            var StudentList = student.Where(m => m.Id == studentId).ToList();

            return Json(StudentList.Select(c => new
            {
                name = c.Name,
                email = c.Email,
                department = departmentManager.ViewDepartment().Where(x => x.Id == c.DepartmentId).Select(x => x.Name).Single()
            }), JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetCoursesByStudentId(int studentId)
        {
            var aViewResults = enrollStudentManager.GetAllEnrollCourse();
            var selectedCourse = aViewResults.Where(a => a.StudentId == studentId).ToList();
            return Json(selectedCourse, JsonRequestBehavior.AllowGet);
        }

        public ActionResult ViewResult()
        {
            ViewBag.StudentList = registrationManager.GetAllStudent();
            ViewBag.DepartmentList = departmentManager.ViewDepartment();
            return View();
        }

        [HttpPost]
        public ActionResult ViewResult(int? studentId)
        {
            ViewBag.StudentId = registrationManager.GetAllStudent();
            ViewBag.DepartmentList = departmentManager.ViewDepartment();

            if (studentId != null)
            {
                var getStudentById = registrationManager.GetAllStudent().FindAll(s => s.Id == studentId).SingleOrDefault();

                ////Pdf part start
                //// Create a Document object
                //var document = new Document(PageSize.A4, 50, 50, 25, 25);

                //// Create a new PdfWriter object, specifying the output stream
                //var output = new MemoryStream();
                //var writer = PdfWriter.GetInstance(document, output);
                //document.Open();


                //var titleFont = FontFactory.GetFont("Arial", 18, Font.BOLD);
                //var subTitleFont = FontFactory.GetFont("Arial", 14, Font.BOLD);
                //var boldTableFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                //var endingMessageFont = FontFactory.GetFont("Arial", 10, Font.ITALIC);
                //var bodyFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);

                //document.Add(new Paragraph("UCRMS Result Creator", titleFont));
                //document.Add(new Paragraph("Thank you for using our app for result creating.", bodyFont));
                //document.Add(new Paragraph("Student Results are below", bodyFont));

                //document.Add(Chunk.NEWLINE);

                //document.Add(new Paragraph("Student Information: ", subTitleFont));

                //var studentInfoTable = new PdfPTable(2);
                //studentInfoTable.HorizontalAlignment = 0;
                //studentInfoTable.SpacingBefore = 10;
                //studentInfoTable.SpacingAfter = 10;
                //studentInfoTable.DefaultCell.Border = 0;
                //studentInfoTable.SetWidths(new int[] { 1, 4 });

                //studentInfoTable.AddCell(new Phrase("Student Reg. No.:", boldTableFont));
                //studentInfoTable.AddCell(getStudentById.Registration_Number);
                //studentInfoTable.AddCell(new Phrase("Name :", boldTableFont));
                //studentInfoTable.AddCell(getStudentById.Name);
                //studentInfoTable.AddCell(new Phrase("Email :", boldTableFont));
                //studentInfoTable.AddCell(getStudentById.Email);
                //studentInfoTable.AddCell(new Phrase("Department :", boldTableFont));
                //studentInfoTable.AddCell(departmentManager.ViewDepartment().Where(c => c.Id == getStudentById.DepartmentId).Select(x => x.Name).Single());

                //document.Add(studentInfoTable);

                //document.Add(Chunk.NEWLINE);

                //document.Add(new Paragraph("Result Informatiion: ", subTitleFont));

                //var resultTable = new PdfPTable(3);
                //resultTable.HorizontalAlignment = 1;
                //resultTable.SpacingBefore = 10;
                //resultTable.SpacingAfter = 10;
                //resultTable.TotalWidth = 9f;

                //resultTable.AddCell(new Phrase("Course Code", boldTableFont));
                //resultTable.AddCell(new Phrase("Name", boldTableFont));
                //resultTable.AddCell(new Phrase("Grade", boldTableFont));

                //var Course = viewResultManager.GetAllViewCourse();
                //var courseInfo = Course.Where(m => m.StudentId == studentId).ToList();

                //Models.ViewResult viewResult = new Models.ViewResult();
                //resultTable.AddCell(viewResult.CourseCode);
                //resultTable.AddCell(viewResult.CourseName);
                //resultTable.AddCell(viewResult.Grade);
                //courseInfo.Add(viewResult);

                ////result asbe

                ////resultTable.AddCell();
                //document.Add(resultTable);


                //DateTime dateTime = DateTime.Now;

                //PdfContentByte cb = writer.DirectContent;
                //BaseFont bf = BaseFont.CreateFont(BaseFont.TIMES_ITALIC, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                //cb.SetFontAndSize(bf, 10);
                //cb.BeginText();
                //cb.SetTextMatrix(50, 5);
                //cb.ShowText(dateTime.ToString());
                //cb.EndText();
                //document.Close();

                //Response.ContentType = "application/pdf";
                //Response.AddHeader("Content-Disposition",
                //    string.Format("attachment;filename=Receipt-{0}.pdf", getStudentById.Registration_Number));
                //Response.BinaryWrite(output.ToArray());
                //ViewBag.message = dateTime.ToString();
                //////pdf ends here
            }
            else
            {
                ViewBag.message = "Fill all field properly";
            }


            return View();
        }

        public JsonResult GetCourseInfoById(int studentId)
        {
            var Course = viewResultManager.GetAllViewCourse();
            var courseInfo = Course.Where(m => m.StudentId == studentId).ToList();
            return Json(courseInfo, JsonRequestBehavior.AllowGet);

        }

    }
}
