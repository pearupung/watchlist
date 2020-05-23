namespace Domain
{
    public class Trigger
    {
        public int TriggerId { get; set; }

        public string TriggerName { get; set; }

        public int HabitLoopId { get; set; }
        public HabitLoop HabitLoop { get; set; }
        
        
    }
}