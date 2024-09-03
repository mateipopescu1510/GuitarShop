using GuitarShop.Models;
using GuitarShop.Models.DTOs;
using GuitarShop.Repositories.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GuitarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;
        public EmployeeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //GET api/Employees
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetEmployees()
        {
            var employees = (await _unitOfWork.Employees.GetAll()).Select(employee => new EmployeeDTO(employee)).ToList();
            return employees;
        }

        //GET api/Employees/firstName/{firstName}/lastName/{lastName}
        [HttpGet("firstName/{firstName}/lastName/{lastName}")]
        public async Task<ActionResult<EmployeeDTO>> GetEmployee(string firstName, string lastName)
        {
            var employee = await _unitOfWork.Employees.GetEmployeeByName(firstName, lastName);
            if (employee == null)
            {
                return NotFound("Employee not found");
            }
            return new EmployeeDTO(employee);
        }


        //PUT api/Employees/firstName/{firstName}/lastName/{lastName}
        [HttpPut("firstName/{firstName}/lastName/{lastName}")]
        public async Task<IActionResult> PutEmployee(string firstName, string lastName, EmployeeDTO employee)
        {
            var employeeInDb = await _unitOfWork.Employees.GetEmployeeByName(firstName, lastName);
            if (employeeInDb == null)
            {
                return NotFound("Employee not found");
            }
            employeeInDb.FirstName = employee.FirstName;
            employeeInDb.LastName = employee.LastName;
            employeeInDb.Age = employee.Age;
            employeeInDb.Email = employee.Email;
            employeeInDb.JobId = employee.JobId;

            await _unitOfWork.Employees.Update(employeeInDb);
            _unitOfWork.Save();
            return Ok();
        }

        //POST api/Employees
        [HttpPost]
        public async Task<ActionResult<EmployeeDTO>> PostEmployee(EmployeeDTO employee)
        {
            var employeeToAdd = new Employee(employee);
            await _unitOfWork.Employees.Create(employeeToAdd);
            _unitOfWork.Save();
            return Ok();
        }

        //DELETE api/Employees
        [HttpDelete]
        public async Task<IActionResult> DeleteEmployee(string firstName, string lastName)
        {
            var employeeInDb = await _unitOfWork.Employees.GetEmployeeByName(firstName, lastName);
            if (employeeInDb == null)
            {
                return NotFound("Employee not found");
            }
            await _unitOfWork.Employees.Delete(employeeInDb);
            _unitOfWork.Save();
            return Ok();
        }







    }
}
