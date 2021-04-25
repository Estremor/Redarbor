using BL;
using BL.Dto;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Redarbor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RedarborController : ControllerBase
    {
        #region Fields
        private readonly IEmployeeService _employeeService;
        #endregion

        #region C'tor
        public RedarborController(IEmployeeService employeeService) => _employeeService = employeeService;
        #endregion

        // GET: api/<RedarborController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_employeeService.ListEmployees());
        }

        // GET api/<RedarborController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                return Ok(_employeeService.GetEmployeeById(id));
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        // POST api/<RedarborController>
        [HttpPost]
        public IActionResult Post(EmployeeDto employee)
        {
            try
            {
                var result = _employeeService.CreateEmployee(employee);
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        // PUT api/<RedarborController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] EmployeeDto employee)
        {
            try
            {
                _employeeService.UpdateEmployee(id, employee);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }

        // DELETE api/<RedarborController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _employeeService.DeleteEmployee(id);
                return StatusCode(200);
            }
            catch (Exception e)
            {
                return StatusCode(400, e.Message);
            }
        }
    }
}
