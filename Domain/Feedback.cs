namespace Domain
{
    public class Feedback
    {
        public int FeedbackId { get; set; }

        // TODO: Configure these as composite keys
        public int TriggerId { get; set; }
        public Trigger Trigger { get; set; }

        public int PupilActionId { get; set; }
        public PupilAction PupilAction { get; set; }
        
        public string FeedbackName { get; set; }
    }
}