using Arangodbtest.model;
using Arangodbtest.Repository.Irepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Arangodbtest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IemployeeRepository _repository;
        public EmployeeController(IemployeeRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Getemployees()
        {
            var emp = _repository.GetEmployees();
            return Ok(emp);
        }

        [HttpPost]
        public IActionResult addemployee(Employee employee)
        {
           _repository.addemployee(employee);
            return Ok(employee);
        }
        [HttpPut]
        public IActionResult editemployee([FromBody]Employee employee)
        {
           _repository.updateemployee(employee);
            return Ok(employee);
        }

        [HttpDelete]
        public IActionResult deleteemployee(string _key) 
        {
            _repository.deleteemployee(_key);
            return Ok("data delete successfully");
        }
        [HttpGet("_key")]
        public IActionResult getemploye(string _key)
        {
            var emp= _repository.getemploye(_key);
            return Ok(emp);
        }
    }
}
