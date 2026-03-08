namespace TaleEngine.API.Contracts.Dtos.Requests
{
    /// <summary>
    /// Request to enroll in an activity
    /// </summary>
    public class ActivityEnrollmentRequest
    {
        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public int UserId { get; set; }
    }
}
