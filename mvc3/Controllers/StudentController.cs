using Microsoft.AspNetCore.Mvc;
using mvc3.Models;

namespace mvc3.Controllers
{
    public class StudentController : Controller
    {
        private StudentService _service=new StudentService();
        public StudentController(StudentService service)
        {
            _service=service;
        }
        public IActionResult Index()
        {
            var students=_service.GetAllStudents();
            return View(students);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Student st)
        {
            var valid=_service.GetAllStudents().Any(x=>x.Id==st.Id);
            if (valid)
            {
                ModelState.AddModelError("Id", "Trùng ID");
                return View(st);
            }
            _service.addStudent(st);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
           
            _service.removeStudent(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item=_service.GetStudentById(id);
            if(item==null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Student st)
        {
                       _service.updateStudent(st);
            return RedirectToAction("Index");
        }
    }
}
