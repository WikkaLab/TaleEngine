namespace TaleEngine.API.Contracts.Dtos
{
    /// <summary>
    /// Assigned Permission Dto
    /// </summary>
    public class AssignedPermissionDto
    {
        /// <summary>
        /// Gets or sets the identifier.
        /// </summary>
        /// <value>
        /// The identifier.
        /// </value>
        public int Id { get; set; }

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

        /// <summary>
        /// Gets or sets the permission.
        /// </summary>
        /// <value>
        /// The permission.
        /// </value>
        public PermissionDto Permission { get; set; }

        /// <summary>
        /// Gets or sets the permission value.
        /// </summary>
        /// <value>
        /// The permission value.
        /// </value>
        public PermissionValueDto PermissionValue { get; set; }
    }
}
