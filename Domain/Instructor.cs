using System;

namespace Domain
{
    public class Instructor
    {
        public int InstructorId { get; set; }

        public DateTime RegisterTime { get; set; }
        public string RegisterCode { get; set; }
        public bool Active { get; set; }
        
    }
}