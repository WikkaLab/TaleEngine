using System;
using System.Collections.Generic;
using System.Text;

namespace TaleEngine.Bussiness.Contracts.Models
{
    public class EditionModel
    {
        public int Id { get; set; }
        public DateTime DateInit { get; set; }
        public DateTime DateEnd { get; set; }

        public int EventId { get; set; }
    }
}
