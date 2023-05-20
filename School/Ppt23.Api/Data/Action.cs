namespace Ppt23.Api.Data
{
    public class Action
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = "";
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public Guid EquipmentID { get; set; }
        public Equipment Equipment { get; set; } = null!;
    }
}
