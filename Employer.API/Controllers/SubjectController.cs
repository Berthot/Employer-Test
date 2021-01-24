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
    public class SubjectController : ControllerBase
    {

        private readonly SubjectService _service = new SubjectService();

        private readonly ISubjectRepository _repo = new SubjectRepository(new Context());



        [HttpPost]
        [Route("")]
        public ActionResult<SubjectDto> Post(
            [FromBody] SubjectDto subjectDto)
        {
            try
            {
                var subjectModel = _service.BuildSubject(subjectDto);
                var validate = _service.ValidateCreateSubject(subjectModel);
                if (validate.Count != 0)
                    return BadRequest(validate);
                _repo.CreateSubject(subjectModel);
                
                return Ok(_service.SubjectToDtoSubject(subjectModel));
            }
            catch (Exception)
            {
                return BadRequest(new List<string> {"Não foi possivel cadastrar a materia"});
            }
        }


        [HttpDelete]
        [Route("")]
        public ActionResult<SubjectDto> Delete(
            [FromBody] SubjectDto subjectDto)
        {
            try
            {
                var subjectModel = _service.GetSubjectToDelete(subjectDto);
                if (subjectModel == default)
                    return BadRequest(new List<string>{"Materia não cadastrada no sistema"});
                _repo.DeleteSubject(subjectModel);
                
                return Ok($"A materia: [ {subjectModel.Description.Name} ] foi excomungada");

            }
            catch (Exception)
            {
                return BadRequest(new List<string> {"Não foi possivel deletar o estudante"});
            }
        }
    }
}