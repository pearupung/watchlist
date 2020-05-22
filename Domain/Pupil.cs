using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class Pupil: IdentityUser<int>
    {
        
        public List<HabitLoop> HabitLoops { get; set; }
        public List<Action> HabitLoopActions { get; set; }
        public List<Feedback> HabitLoopFeedbacks { get; set; }
        public List<Trigger> HabitLoopTriggers { get; set; }
        public List<Session> Sessions { get; set; }
        public List<WatchList> WatchLists { get; set; }
    }
}