using System;
using System.Threading.Tasks;
using Employer.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Employer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<StudentDto>> Post(StudentDto studentDto)
        {
            try
            {
                return Ok(studentDto);
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível criar o usuário" });
            }
        }
    }
}