using System;
using System.Collections.Generic;
using Employer.API.Service;
using Employer.Domain.DTO;
using Microsoft.AspNetCore.Mvc;

namespace Employer.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class NoteController : ControllerBase
    {
        private readonly NoteService _service = new NoteService();

        [HttpPost]
        [Route("")]
        public ActionResult<NoteDto> Post([FromBody] NoteDto note)
        {
            try
            {
                var fields = _service.ValidateEmptyField(note);
                if (fields.Count != 0)
                    return BadRequest(fields);
                var noteModel = _service.BuildStudentNote(note);
                var validate = _service.ValidateCreateNote(noteModel);
                if (validate.Count != 0)
                    return BadRequest(validate);
                _service.Create(noteModel);
                return Ok(_service.NoteToDto(noteModel));
            }
            catch (Exception)
            {
                return BadRequest(new List<string> {$"Não foi possivel cadastrar a nota do estudante [ {note.Student} ]"});
            }
        }


        [HttpDelete]
        [Route("")]
        public ActionResult<NoteDto> Delete(
            [FromBody] NoteDto note)
        {
            try
            {
                var fields = _service.ValidateEmptyField(note);
                if (fields.Count != 0)
                    return BadRequest(fields);
                var noteModel = _service.BuildStudentNote(note);
                var validate = _service.ValidateDeleteNote(noteModel);
                if (validate.Count != 0)
                    return BadRequest(validate);
                var toDelete = _service.GetToDelete(noteModel);
                if(toDelete == default)
                    return BadRequest(new List<string> {"Não foi encontrar a nota para deletar"});
                _service.DeleteNote(toDelete);
                return Ok(new List<string>(){"Nota deletada"});

            }
            catch (Exception)
            {
                return BadRequest(new List<string> {"Não foi possivel deletar a nota"});
            }
        }
    }
}