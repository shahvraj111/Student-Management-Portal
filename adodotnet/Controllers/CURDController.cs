using adodotnet.Models;
using System.Collections.Generic;
using System.Web.Mvc;

namespace adodotnet.Controllers
{
    public class CURDController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            StudentCRUD obj = new StudentCRUD();
            List<StudentDB> emplist = obj.GetAllStudents();
            return View(emplist);
        }
        [HttpPost]
        public ActionResult Index(StudentDB emp)
        {
            StudentCRUD empobj = new StudentCRUD();
            int result = empobj.Add(emp);
            return View();
        }
        [HttpGet]
        public ActionResult Insert()
        {
            return View("Insert");
        }
        [HttpPost]
        public ActionResult Insert(StudentDB stu)
        {
            StudentCRUD stuobj = new StudentCRUD();
            int result = stuobj.Add(stu);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            StudentCRUD obj = new StudentCRUD();
            StudentDB stu = obj.GetStudentbyid(id);
            return View(stu);
        }
        [HttpPost]
        public ActionResult Edit(int id, StudentDB emp)
        {
            StudentCRUD empobj = new StudentCRUD();
            int result = empobj.UpdateEmployee(emp);
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            StudentCRUD stu = new StudentCRUD();
            int result = stu.DeleteData(id);
            return RedirectToAction("Index");
        }
    }
}






