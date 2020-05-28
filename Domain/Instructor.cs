using System;

namespace Domain
{
    public class Instructor
    {
        public int InstructorId { get; set; }
        public string InstructorName { get; set; }
        public DateTime RegisterTime { get; set; }
        public string RegisterCode { get; set; }
        public bool Active { get; set; }

        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        
    }
}