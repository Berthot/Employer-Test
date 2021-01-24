using System;

namespace Employer.Domain.ValueObjects
{
    public class Note
    {
        public Note()
        {
        }

        public Note(string value)
        {
            Value = CastToInt(value);
        }

        public Note(int value)
        {
            Value = value;
        }

        public int Value { get; set; }

        public void ValidateNoteValou()
        {
            // regex para validar a nota
        }
        
        private int CastToInt(string value)
        {
            try
            {
                return (int) long.Parse(value);
            }
            catch (Exception)
            {
                return -10;
            }
        }

        public bool NotValid()
        {
            return Value > 101 && Value < -1;
        }
    }
}