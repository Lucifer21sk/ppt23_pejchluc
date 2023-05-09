using System.ComponentModel.DataAnnotations;

namespace Ppt23.Api.Data
{
    public class Revision
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime DateTime { get; set; }

        public Guid EquipmentId { get; set; }

        public Equipment Equipment { get; set; } = null!;


    }

}
