using System.ComponentModel.DataAnnotations;
namespace Ppt23.Shared
{
    public class EquipmentVm
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Name is required")]
        [StringLength(12, MinimumLength = 5, ErrorMessage = "Name must be between 5 and 12 characters")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Bought date is required")]
        [DataType(DataType.Date, ErrorMessage = "Bought date is not a valid date")]
        public DateTime BoughtDate { get; set; }

        [Required(ErrorMessage = "Last revision date is required")]
        [DataType(DataType.Date, ErrorMessage = "Last revision date is not a valid date")]
        [CustomValidation(typeof(EquipmentVm), nameof(ValidateLastRevisionDate))]
        public DateTime? LastRevisionDate { get; set; }

        [Required(ErrorMessage = "Price is required")]
        [Range(0, 10000000, ErrorMessage = "Price must be between 0 and 10,000,000")]
        public int Price { get; set; }
        public string PriceFormatted => $"{Price:N0} kč";

        public bool IsRevisionNeeded => DateTime.Now - LastRevisionDate > TimeSpan.FromDays(365 * 2);

        public static List<EquipmentVm> RtnRndList(int count)
        {
            var rand = new Random();
            var list = new List<EquipmentVm>();

            for (int i = 1; i <= count; i++)
            {
                var name = "";
                var nameLength = rand.Next(5, 13);

                for (int j = 0; j < nameLength; j++)
                {
                    var randomChar = (char)rand.Next('a', 'z' + 1);
                    name += randomChar;
                }

                var boughtDateTime = new DateTime(2010, 1, 1).AddDays(rand.Next(1, (DateTime.Now - new DateTime(2010, 1, 1)).Days));

                var lastRevisionDays = rand.Next(1, (DateTime.Now - boughtDateTime).Days);
                var lastRevisionDateTime = boughtDateTime.AddDays(lastRevisionDays);

                var equipment = new EquipmentVm
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    BoughtDate = boughtDateTime,
                    LastRevisionDate = lastRevisionDateTime,
                    Price = rand.Next(0, 10000001)
                };

                list.Add(equipment);
            }

            return list;
        }

        public static List<EquipmentVm> RtnRndList()
        {
            var rand = new Random();
            var count = rand.Next(1, 20);
            return RtnRndList(count);
        }
        public EquipmentVm Copy()
        {
            EquipmentVm eq = new();
            eq.BoughtDate = BoughtDate;
            eq.LastRevisionDate = LastRevisionDate;
            eq.Name = Name;
            eq.Price = Price;
            return eq;
        }
        public void MapTo(EquipmentVm? eq)
        {
            if (eq == null) return;
            eq.BoughtDate = BoughtDate;
            eq.LastRevisionDate = LastRevisionDate;
            eq.Name = Name;
            eq.Price = Price;
        }
        public static ValidationResult ValidateLastRevisionDate(DateTime lastRevisionDateTime, ValidationContext validationContext)
        {
            var equipmentVm = (EquipmentVm)validationContext.ObjectInstance;

            if (lastRevisionDateTime < equipmentVm.BoughtDate)
            {
                return new ValidationResult("Last revision date must be equal to or after the bought date.");
            }

            return ValidationResult.Success;
        }

    }


}
