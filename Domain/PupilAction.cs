namespace Domain
{
    public class PupilAction
    {
        public int PupilActionId { get; set; }

        public string ActionName { get; set; }
        
        public int HabitLoopId { get; set; }
        public HabitLoop HabitLoop { get; set; }

    }
}