using System;
using System.Collections.Generic;
using Employer.API.Service;
using Employer.Domain.DTO;
using Employer.Domain.IRepository;
using Employer.Infra.Data;
using Employer.Infra.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Employer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StudentController : ControllerBase
    {

        private readonly StudentService _service = new StudentService();

        [HttpPost]
        [Route("")]
        public ActionResult<StudentDto> Post(
            [FromBody] StudentDto student)
        {
            try
            {
                var studentModel = _service.BuildStudent(student);
                var validate = _service.ValidateCreateStudent(studentModel);
                if (validate.Count != 0)
                    return BadRequest(validate);
                _service.CreateStudent(studentModel);
            
                return Ok(_service.StudentToDtoStudent(studentModel));
            }
            catch (Exception)
            {
                return BadRequest(new List<string>{"Não foi possivel cadastrar o estudante"});
            }
        }
        
                
        [HttpDelete]
        [Route("")]
        public ActionResult<StudentDto> Delete(
            [FromBody] StudentDto student)
        {
            try
            {
                var studentModel = _service.GetStudentToDelete(student);
                if (studentModel == default)
                    return BadRequest(new List<string>{"Estudante não cadastrado no sistema"});
                _service.DeleteStudent(studentModel);
                return Ok(new List<string>{$"Estudante portador do cpf [ {studentModel.Cpf.Code} ] foi excomungado"});
            }
            catch (Exception)
            {
                return BadRequest(new List<string>{"Não foi possivel deletar o estudante"});
            }
        }
        
                        
        [HttpGet]
        [Route("{cpf}")]
        public ActionResult<List<StudentNotesDto>> GetByCpf(string cpf)
        {
            try
            {
                var students = _service.GetAllStudentNotes(cpf);
                if(students == default)
                    return BadRequest(new List<string>{"Estudante não cadastrado no sistema"});
                return Ok(students);
            }
            catch (Exception)
            {
                return BadRequest(new List<string>{"Não foi possivel captar informações dos estudantes"});
            }
        }

        
        
    }
}