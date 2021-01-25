using System.Collections.Generic;
using System.Runtime.Intrinsics.X86;
using Employer.Domain.Entities;
using Employer.Domain.ValueObjects;

namespace Employer.Domain.DTO
{
    public class StudentNotesDto
    {
        public StudentNotesDto(string descriptionName, Note note)
        {
            Description = descriptionName;
            Note = note.Value.ToString();
        }

        public StudentNotesDto()
        {
        }

        public string Description { get; set; }
        
        public string Note { get; set; }
    }
}