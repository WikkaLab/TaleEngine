using System.Collections.Generic;
using TaleEngine.Data.Contracts.Entities;

namespace TaleEngine.Data.Data
{
    public static class InitialPermissionData
    {
        public static List<Permission> GetPermissionData()
        {
            return new List<Permission>
            {
                new Permission { Id = 1, Name = "See activities", Abbr = "SEE" },
                new Permission { Id = 2, Name = "Request join", Abbr = "REQJOIN" },
                new Permission { Id = 3, Name = "Mark as favourite", Abbr = "MARKFAV" },
                new Permission { Id = 4, Name = "Abandon activity", Abbr = "ABANACT" },
                new Permission { Id = 5, Name = "Propose activity", Abbr = "PROPACT" },
                new Permission { Id = 6, Name = "Edit proposed activity", Abbr = "EDITACT" },
                new Permission { Id = 7, Name = "Delete proposed activity", Abbr = "DELACT" },
                new Permission { Id = 8, Name = "See participants", Abbr = "SEEPART" },
                new Permission { Id = 9, Name = "Accept activity edit", Abbr = "ACCACTEDIT" },
                new Permission { Id = 10, Name = "Accept activity deletion", Abbr = "ACCACTDEL" },
                new Permission { Id = 11, Name = "Mark proposal for revision", Abbr = "MARKREV" },
                new Permission { Id = 12, Name = "Create user", Abbr = "CRTU" },
                new Permission { Id = 13, Name = "Delete user", Abbr = "DELU" },
                new Permission { Id = 14, Name = "Ban user", Abbr = "BANU" },
                new Permission { Id = 15, Name = "Accept activity proposal", Abbr = "ACCACTPROP" },
                new Permission { Id = 16, Name = "Delete activity proposal", Abbr = "DELACTPROP" },
                new Permission { Id = 17, Name = "Edit user", Abbr = "EDITU" },
            };
        }
    }
}
