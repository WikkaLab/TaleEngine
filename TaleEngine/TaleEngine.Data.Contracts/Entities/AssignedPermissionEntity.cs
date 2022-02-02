namespace TaleEngine.Data.Contracts.Entities
{
    public class AssignedPermissionEntity : BaseEntity
    {
        public int RoleId { get; set; }
        public RoleEntity Role { get; set; }

        public int PermissionId { get; set; }
        public PermissionEntity Permission { get; set; }

        public int PermissionValueId { get; set; }
        public PermissionValueEntity PermissionValue { get; set; }
    }
}
