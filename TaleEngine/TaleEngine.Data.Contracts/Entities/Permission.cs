﻿using System.Collections.Generic;

namespace TaleEngine.Data.Contracts.Entities
{
    public class Permission : BaseEntity
    {
        public string Name { get; set; }
        public string Abbr { get; set; }
        public string Description { get; set; }

        public List<Role> Roles { get; set; }
    }
}
