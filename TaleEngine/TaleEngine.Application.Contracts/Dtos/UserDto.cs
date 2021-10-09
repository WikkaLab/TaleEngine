using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaleEngine.Application.Contracts.Dtos
{
    /// <summary>
    /// 
    /// </summary>
    public class UserDto
    {
        public string Username { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Website { get; set; }
        public string Blog { get; set; }
    }
}
