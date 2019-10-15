namespace TaleEngine.Data.Contracts.Entities
{
    public class UserToActivityOperation
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public int ActivityId { get; set; }
        public Activity Activity { get; set; }
    }
}
