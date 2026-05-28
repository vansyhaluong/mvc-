using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using mvc2.Models;

namespace mvc2.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService=new EmployeeService();
        public IActionResult Index()
        {
            var item=_employeeService.GetAllEmployees();
            return View(item);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            var item=_employeeService.GetAllEmployees().Any(x=>x.Id==employee.Id);
            if (item)
            {
                ModelState.AddModelError("Id", "Employee with this Id already exists.");
            }
            var item2=_employeeService.GetAllEmployees().Any(x=>x.Name==employee.Name);
            if (item2)
            {
                ModelState.AddModelError("Name", "Employee with this Name already exists.");
            }
            if (!ModelState.IsValid)
            {
                return View(employee);
            }
                _employeeService.addEmployee(employee);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            _employeeService.removeEmployee(id);
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var item=_employeeService.GetEmployeeById(id);
            if(item==null)
            {
                return NotFound();
            }
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(Employee e)
        {
            if(!ModelState.IsValid)
            {
                return View(e);
            }
            _employeeService.updateEmployee(e);
            return RedirectToAction("Index");
        }
    }
}
