namespace TaleEngine.API.Contracts.Dtos.Results
{
    /// <summary>
    /// Result of an activity enrollment operation
    /// </summary>
    public class ActivityEnrollmentResult
    {
        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets whether the user was enrolled directly or added to waiting list.
        /// </summary>
        public bool IsWaitingList { get; set; }

        /// <summary>
        /// Gets or sets the position in waiting list (null if enrolled directly).
        /// </summary>
        public int? PositionInWaitingList { get; set; }

        /// <summary>
        /// Gets or sets the number of available places.
        /// </summary>
        public int AvailablePlaces { get; set; }

        /// <summary>
        /// Gets or sets the total places for the activity.
        /// </summary>
        public int TotalPlaces { get; set; }

        /// <summary>
        /// Gets or sets the success message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// Gets or sets whether the operation was successful.
        /// </summary>
        public bool Success { get; set; }
    }
}
