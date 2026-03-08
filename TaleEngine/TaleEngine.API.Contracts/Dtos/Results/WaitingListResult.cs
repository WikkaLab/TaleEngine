using System.Collections.Generic;

namespace TaleEngine.API.Contracts.Dtos.Results
{
    /// <summary>
    /// Waiting list for an activity
    /// </summary>
    public class WaitingListResult
    {
        /// <summary>
        /// Gets or sets the activity identifier.
        /// </summary>
        public int ActivityId { get; set; }

        /// <summary>
        /// Gets or sets the activity title.
        /// </summary>
        public string ActivityTitle { get; set; }

        /// <summary>
        /// Gets or sets the total number of users in waiting list.
        /// </summary>
        public int TotalWaiting { get; set; }

        /// <summary>
        /// Gets or sets the list of users in waiting list.
        /// </summary>
        public List<WaitingListUserDto> UsersInWaitingList { get; set; }
    }

    /// <summary>
    /// User in waiting list
    /// </summary>
    public class WaitingListUserDto
    {
        /// <summary>
        /// Gets or sets the user identifier.
        /// </summary>
        public int UserId { get; set; }

        /// <summary>
        /// Gets or sets the username.
        /// </summary>
        public string Username { get; set; }

        /// <summary>
        /// Gets or sets the position in waiting list.
        /// </summary>
        public int Position { get; set; }
    }
}
