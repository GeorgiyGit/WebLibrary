using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Domain.Entities.Shared
{
    public class Monitoring : IMonitoring
    {
        public DateTime DataCreationTime { get; set; } = DateTime.UtcNow;
        public DateTime? DataLastDeleteTime { get; set; }
        public DateTime? DataLastEditTime { get; set; }

        public bool IsDeleted { get; set; }
        public bool IsEdited { get; set; }
    }
}
