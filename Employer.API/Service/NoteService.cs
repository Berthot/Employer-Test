
using System;
using System.Collections.Generic;
using System.Linq;
using Employer.Domain.DTO;
using Employer.Domain.Entities;
using Employer.Domain.IRepository;
using Employer.Domain.ValueObjects;
using Employer.Infra.Data;
using Employer.Infra.Repository;

namespace Employer.API.Service
{
    public class NoteService
    {
        private readonly IStudentSubjectMapRepository _repo = new StudentSubjectMapRepository(new Context());

        public List<string> ValidateEmptyField(NoteDto note)
        {
            var badRequest = new List<string>();
            if (note.StudentCpf.Length == 0)
                badRequest.Add("Cpf do estudante esta vazio");
            if (note.Description.Length == 0)
                badRequest.Add("Descricao esta vazia");
            if (note.Note.Length == 0)
                badRequest.Add("Nota esta vazia");
            return badRequest;
        }

        public StudentSubjectMap BuildStudentNote(NoteDto note)
        {
            var student = GetStudentByCpf(note.StudentCpf);
            var subject = GetSubjectByDescription(note.Description.ToLower());
            var noteObj = new Note(note.Note);
            return new StudentSubjectMap(student, subject, noteObj);
        }
        public List<string> ValidateCreateNote(StudentSubjectMap note)
        {

            var badRequest = new List<string>();
            if (note.Student == default)
                badRequest.Add("Estudante não encontrado no sistema");
            if (note.Subject == default)
                badRequest.Add("Materia não encontrada no sistema");
            if (note.Note.NotValid())
                badRequest.Add("valor da nota invalido deve ser inteiro entre [ 0 - 100 ]");
            return badRequest;

        }
        public List<string> ValidateDeleteNote(StudentSubjectMap note)
        {

            var badRequest = new List<string>();
            if (note.Student == default)
                badRequest.Add("Estudante não encontrado no sistema");
            if (note.Subject == default)
                badRequest.Add("Materia não encontrada no sistema");
            return badRequest;

        }


        
        public Student GetStudentByCpf(string cpfCode)
        {
            return _repo.GetStudentByCpf(cpfCode);
        }
        
        private Subject GetSubjectByDescription(string descriptionName)
        {
            return _repo.GetSubjectByDescription(descriptionName);
        }

        public NoteDto NoteToDto(StudentSubjectMap noteModel)
        {
            return new NoteDto(noteModel);
        }

        public void Create(StudentSubjectMap noteModel)
        {
            var send = new StudentSubjectMap()
            {
                StudentId = noteModel.Student.Id,
                SubjectId = noteModel.Subject.Id,
                Note = new Note(noteModel.Note.Value),
                UpdateAt = DateTime.Now
            };
            _repo.CreateCreateStudentSubjectMap(send);

        }

        public StudentSubjectMap GetToDelete(StudentSubjectMap noteModel)
        {
            return GetStudentByCpf(noteModel.Student.Cpf.Code)
                .StudentSubjectMaps
                .FirstOrDefault(map =>
                    map.Note.Value == noteModel.Note.Value && 
                    map.Subject.Id == noteModel.Subject.Id
                );
        }

        public void DeleteNote(StudentSubjectMap toDelete)
        {
            _repo.DeleteStudentSubjectMap(toDelete);
        }
    }
}