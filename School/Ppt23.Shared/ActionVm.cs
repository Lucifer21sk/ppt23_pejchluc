using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppt23.Shared
{
    public class ActionVm
    {
        public Guid Id { get; set; }
        public string Code { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Description { get; set; } = string.Empty;
        public string WorkerName { get; set; } = string.Empty;

    }
}
