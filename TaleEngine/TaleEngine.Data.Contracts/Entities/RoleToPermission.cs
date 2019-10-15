namespace TaleEngine.Data.Contracts.Entities
{
    public class RoleToPermission : BaseEntity
    {
        public int RoleId { get; set; }
        public Role Role { get; set; }
        public int PermissionId { get; set; }
        public Permission Permission { get; set; }
    }
}
