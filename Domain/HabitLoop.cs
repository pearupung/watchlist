using System;
using System.Collections.Generic;

namespace Domain
{
    public class HabitLoop
    {
        public int HabitLoopId { get; set; }

        public int PupilId { get; set; }
        public Pupil Pupil { get; set; }
        
        public List<WatchListHabitLoop> WatchListHabitLoop { get; set; }

        public List<Trigger> HabitLoopTriggers { get; set; }
        public List<PupilAction> HabitLoopActions { get; set; }

        public List<Feedback> Feedbacks { get; set; }
    }
}