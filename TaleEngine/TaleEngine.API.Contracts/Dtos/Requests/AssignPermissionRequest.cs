namespace TaleEngine.API.Contracts.Dtos.Requests
{
    /// <summary>
    /// Request to assign a permission to a role
    /// </summary>
    public class AssignPermissionRequest
    {
        /// <summary>
        /// Gets or sets the role identifier.
        /// </summary>
        /// <value>
        /// The role identifier.
        /// </value>
        public int RoleId { get; set; }

        /// <summary>
        /// Gets or sets the permission identifier.
        /// </summary>
        /// <value>
        /// The permission identifier.
        /// </value>
        public int PermissionId { get; set; }

        /// <summary>
        /// Gets or sets the permission value identifier.
        /// </summary>
        /// <value>
        /// The permission value identifier.
        /// </value>
        public int PermissionValueId { get; set; }
    }
}
