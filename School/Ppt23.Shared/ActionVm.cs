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
        public string Name { get; set; } = "";
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public Guid EquipmentID { get; set; }
    }
}
