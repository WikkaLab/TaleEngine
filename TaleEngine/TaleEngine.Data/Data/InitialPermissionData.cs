using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialPermissionData
    {
        public static List<PermissionEntity> GetPermissionData()
        {
            return new List<PermissionEntity>
            {
                new PermissionEntity { Id = 1, Name = "See activities", Abbr = "SEE" },
                new PermissionEntity { Id = 2, Name = "Request join", Abbr = "REQJOIN" },
                new PermissionEntity { Id = 3, Name = "Mark as favourite", Abbr = "MARKFAV" },
                new PermissionEntity { Id = 4, Name = "Abandon activity", Abbr = "ABANACT" },
                new PermissionEntity { Id = 5, Name = "Propose activity", Abbr = "PROPACT" },
                new PermissionEntity { Id = 6, Name = "Edit proposed activity", Abbr = "EDITACT" },
                new PermissionEntity { Id = 7, Name = "Delete proposed activity", Abbr = "DELACT" },
                new PermissionEntity { Id = 8, Name = "See participants", Abbr = "SEEPART" },
                new PermissionEntity { Id = 9, Name = "Accept activity edit", Abbr = "ACCACTEDIT" },
                new PermissionEntity { Id = 10, Name = "Accept activity deletion", Abbr = "ACCACTDEL" },
                new PermissionEntity { Id = 11, Name = "Mark proposal for revision", Abbr = "MARKREV" },
                new PermissionEntity { Id = 12, Name = "Create user", Abbr = "CRTU" },
                new PermissionEntity { Id = 13, Name = "Delete user", Abbr = "DELU" },
                new PermissionEntity { Id = 14, Name = "Ban user", Abbr = "BANU" },
                new PermissionEntity { Id = 15, Name = "Accept activity proposal", Abbr = "ACCACTPROP" },
                new PermissionEntity { Id = 16, Name = "Delete activity proposal", Abbr = "DELACTPROP" },
                new PermissionEntity { Id = 17, Name = "Edit user", Abbr = "EDITU" },
            };
        }
    }
}
