namespace TaleEngine.Data.Contracts.Entities
{
    public class AssignedPermission : BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }

        public int PermissionId { get; set; }
        public Permission Permission { get; set; }

        public int PermissionValueId { get; set; }
        public PermissionValue PermissionValue { get; set; }
    }
}
