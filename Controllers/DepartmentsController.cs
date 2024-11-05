using API_CF_Demo1.Models;
using API_CF_Demo1.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_CF_Demo1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentsController : ControllerBase
    {
        private readonly IDepartmentService _service;
        public DepartmentsController(IDepartmentService service)
        {
            _service=service;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            List<Department> departments = _service.GetAllDepartments();
            return Ok(departments);
        }

        [HttpGet("{id}")]
        public IActionResult GetDepartmentById(int id)
        {
            Department department = _service.GetDepartmentById(id);
            return Ok(department);
        }

        [HttpPost]
        public IActionResult Post(Department department)
        {
            int Result =_service.AddNewDepartment(department);
            return Ok(Result);
        }

        [HttpPut]
        public IActionResult Put(Department department)
        {
            string result=_service.UpdateDepartment(department);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            string result=_service.DeleteDepartment(id);
            return Ok(result);
        }
    }
}
