using System;

namespace Domain
{
    public class Session
    {
        public int SessionId { get; set; }
        
        public int PupilId { get; set; }
        public Pupil Pupil { get; set; }

        public int InstructorId { get; set; }
        public Instructor Instructor { get; set; }

        public int WatchListId { get; set; }
        public WatchList WatchList { get; set; }

        public DateTime StartTime { get; set; }
        public TimeSpan SetDuration { get; set; }
        public DateTime EndTime { get; set; }
        
        
    }
}