namespace TaleEngine.Application.Contracts.Dtos
{
    /// <summary>
    /// Activity DTO
    /// </summary>
    public class ActivityDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the title.
        /// </summary>
        /// <value>
        /// The title.
        /// </value>
        public string Title { get; set; }
        /// <summary>
        /// Gets or sets the description.
        /// </summary>
        /// <value>
        /// The description.
        /// </value>
        public string Description { get; set; }
        /// <summary>
        /// Gets or sets the places.
        /// </summary>
        /// <value>
        /// The places.
        /// </value>
        public int Places { get; set; }
        /// <summary>
        /// Gets or sets the image.
        /// </summary>
        /// <value>
        /// The image.
        /// </value>
        public string Image { get; set; }

        /// <summary>
        /// Gets or sets the time slot identifier.
        /// </summary>
        /// <value>
        /// The time slot identifier.
        /// </value>
        public int TimeSlotId { get; set; }

        /// <summary>
        /// Gets or sets the activity start.
        /// </summary>
        /// <value>
        /// The activity start.
        /// </value>
        public string ActivityStart { get; set; }
        /// <summary>
        /// Gets or sets the activity end.
        /// </summary>
        /// <value>
        /// The activity end.
        /// </value>
        public string ActivityEnd { get; set; }

        /// <summary>
        /// Gets or sets the type identifier.
        /// </summary>
        /// <value>
        /// The type identifier.
        /// </value>
        public int TypeId { get; set; }
        /// <summary>
        /// Gets or sets the status identifier.
        /// </summary>
        /// <value>
        /// The status identifier.
        /// </value>
        public int StatusId { get; set; }

    }
}
