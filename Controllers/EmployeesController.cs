using JWTAuthentication.Data;
using JWTAuthentication.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JWTAuthentication.DTOs.Employee;
using Mapster;

namespace JWTAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    //[Authorize]
    public class EmployeesController : ControllerBase
    {
        private readonly ILogger<EmployeesController> _logger;
        private readonly DataContext _context;
        public EmployeesController(ILogger<EmployeesController> logger, DataContext dataContext)
        {
            _logger = logger;
            _context = dataContext;
        }
        [HttpGet]
        [Route("GetAll")]
        //[Route("Show")]
        public async Task<IEnumerable<Employee>> Get()
        {
            IEnumerable<Employee> employee = await _context.Employees.ToListAsync();

            return employee;
        }


        [HttpGet]
        [Route("Get")]
        public async Task<IActionResult> GetEmployeeAsync(int id)
        {
            try
            {
                Employee employee = await _context.Employees.Where(x => x.EmployeeID == id).FirstOrDefaultAsync();
                return Ok(employee);

            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
          
        }


        [HttpPost]
        [Route("Add")]
        public async Task<IActionResult> Post(EmployeeDTO employeeDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Employee employee = employeeDTO.Adapt<Employee>();
                    await _context.Employees.AddAsync(employee);
                    int action = await _context.SaveChangesAsync();

                    if (action > 0)
                    {
                        return Ok("Added Successfully");
                    }
                }
                catch (Exception ex)
                {

                    return BadRequest(ex.Message);
                }
          
                return BadRequest("please try again..");
            }
            return BadRequest(ModelState);
        }

        [HttpPut]
        [Route("Edit")]
        public  IActionResult Put(int id, EmployeeDTO employee)
        {
            try
            {
                if (id > 0 )
                {
                    Employee model =  _context.Employees.Where(x => x.EmployeeID == id).FirstOrDefault();
                    if (model != null)
                    {
                        model.FirstName = employee.FirstName;
                        model.LastName = employee.LastName;
                        model.Department = employee.Department;
                        model.Salary = employee.Salary;

                        _context.Employees.Update(model);
                        int action =  _context.SaveChanges();

                        if (action > 0)
                        {
                            return Ok("Update Successfully");
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }

            return BadRequest("please try again..");
        }

    }
}