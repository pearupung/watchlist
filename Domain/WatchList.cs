using System.Collections.Generic;

namespace Domain
{
    public class WatchList
    {
        public int WatchListId { get; set; }

        public string WatchListName { get; set; }

        public int PupilId { get; set; }
        public Pupil Pupil { get; set; }

        public List<WatchListHabitLoop> WatchListHabiLoops { get; set; }        
    }
}