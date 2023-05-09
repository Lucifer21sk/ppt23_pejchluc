using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppt23.Shared
{
    public class EquipmentWithRevisionsVm
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;
        public Guid RevisionId { get; set; }
        public List<RevisionVm> Revisions { get; set; }= new List<RevisionVm>();

    
    }
}
