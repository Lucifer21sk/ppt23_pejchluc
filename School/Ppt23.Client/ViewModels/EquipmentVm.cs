namespace Ppt23.Client.ViewModels
{ 
    public class EquipmentVm
    {
        public string? Name { get; set; }
        public DateTime BoughtDateTime { get; set; }
        public DateTime LastRevisionDateTime { get; set; }
        public bool IsRevisionNeeded { get => (DateTime.Now - LastRevisionDateTime).TotalDays > 730; }
        public bool IsInEditMode { get; set; } 


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
                    Name = name,
                    BoughtDateTime = boughtDateTime,
                    LastRevisionDateTime = lastRevisionDateTime
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
    }


}
