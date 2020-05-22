using System;
using System.Collections.Generic;

namespace Domain
{
    public class HabitLoop
    {
        public int HabitLoopId { get; set; }

        
        public List<WatchListHabiLoop> WatchListHabitLoop { get; set; }

        public List<Trigger> HabitLoopTriggers { get; set; }
        public List<Action> HabitLoopActions { get; set; }

        public Dictionary<Tuple<Trigger, Action>, Feedback> Feedbacks { get; set; }
    }
}