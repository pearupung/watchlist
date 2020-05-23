namespace Domain
{
    public class WatchListHabitLoop
    {
        public int WatchListHabitLoopId { get; set; }

        public int HabitLoopId { get; set; }
        public HabitLoop HabitLoop { get; set; }

        public int WatchListId { get; set; }
        public WatchList WatchList { get; set; }
    }
}