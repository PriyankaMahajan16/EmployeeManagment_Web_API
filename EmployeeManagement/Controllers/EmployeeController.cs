using EmployeeManagement.Models;
using EmployeeManagement.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeServices employeeServices;

        public EmployeeController(IEmployeeServices employeeServices)
        {
            this.employeeServices = employeeServices;
        }

        [HttpGet]
        public ActionResult<List<Employee>> Get()
        {
            return employeeServices.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {
            var employee = employeeServices.Get(id);

            if (employee == null)
            {
                return NotFound($"Student with Id = {id} not found");
            }

            return employee;
        }

        [HttpPost]
        public ActionResult<Employee> Post([FromBody] Employee employee)
        {
            employeeServices.Create(employee);

            return CreatedAtAction(nameof(Get), new { id = employee.Id }, employee);
        }

        [HttpPut("{id}")]
        public ActionResult Put(string id, [FromBody] Employee employee)
        {
            var existingEmployee = employeeServices.Get(id);

            if (existingEmployee == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            employeeServices.Update(id, employee);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var employee = employeeServices.Get(id);

            if (employee == null)
            {
                return NotFound($"Employee with Id = {id} not found");
            }

            employeeServices.Remove(employee.Id);

            return Ok($"Employee with Id = {id} deleted");
        }
    }
}

