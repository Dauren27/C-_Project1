using Microsoft.AspNetCore.Mvc;
using BLL.Services;
namespace C__Project1.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeManager)
        {
            _employeeService = employeeManager;
        }

        // Действие для отображения списка сотрудников
        public IActionResult Index()
        {
            var employees = _employeeManager.GetEmployees();
            return View(employees);
        }

        // Действие для создания нового сотрудника (GET)
        public IActionResult Create()
        {
            return View();
        }

        // Действие для создания нового сотрудника (POST)
        [HttpPost]
        public IActionResult Create(Employee employee)
        {
            if (ModelState.IsValid)
            {
                _employeeService.CreateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Действие для отображения деталей сотрудника
        public IActionResult Details(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // Действие для редактирования сотрудника (GET)
        public IActionResult Edit(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // Действие для редактирования сотрудника (POST)
        [HttpPost]
        public IActionResult Edit(Guid id, Employee employee)
        {
            if (id != employee.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _employeeService.UpdateEmployee(employee);
                return RedirectToAction("Index");
            }
            return View(employee);
        }

        // Действие для удаления сотрудника (GET)
        public IActionResult Delete(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound();
            }
            return View(employee);
        }

        // Действие для удаления сотрудника (POST)
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(Guid id)
        {
            _employeeService.DeleteEmployee(id);
            return RedirectToAction("Index");
        }
    }
}
