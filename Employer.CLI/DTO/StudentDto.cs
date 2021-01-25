using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Employer.CLI.DTO
{
    public class StudentDto
    {
        public StudentDto(string name, string surname, string birthDate, string cpf, string course)
        {
            Name = name;
            Surname = surname;
            BirthDate = birthDate;
            Cpf = cpf;
            Course = course;
        }

        public StudentDto()
        {
        }

        [JsonPropertyName("id")]
        public int Id { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }    
        
        [JsonPropertyName("surname")]
        public string Surname { get; set; }
        
        [JsonPropertyName("birthDate")]
        public string BirthDate { get; set; }
        
        [JsonPropertyName("cpf")]
        public string Cpf { get; set; }
        
        [JsonPropertyName("course")]
        public string Course { get; set; }
        
        [JsonPropertyName("creatAt")]
        public DateTime CreatAt { get; set; }

        public Dictionary<string, string> GetDict()
        {
            var dic = new Dictionary<String, String>();
            dic["Name"] = Name;
            dic["Surname"] = Surname;
            dic["BirthDate"] = BirthDate;
            dic["Cpf"] = Cpf;
            dic["Course"] = Course;
            return dic;
        }

    }
}