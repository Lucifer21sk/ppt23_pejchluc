using System.ComponentModel.DataAnnotations;

namespace Ppt23.Api.Data
{
    public class Equipment
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public int Price { get; set; }

        public DateTime BoughtDate { get; set; }

        public DateTime LastRevisionDate { get; set; }
    }
}
