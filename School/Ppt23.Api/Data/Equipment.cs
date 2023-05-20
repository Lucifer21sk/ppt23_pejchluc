using System.ComponentModel.DataAnnotations;

namespace Ppt23.Api.Data
{
    public class Equipment
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = "";

        public int Price { get; set; }

        public DateTime BoughtDate { get; set; }

        public List<Revision> Revisions { get; set; } = new();
        public List<Action> Actions { get; set; } = new();


        public static List<Equipment> RndEquipmentList(int count)
        {
            var rand = new Random();
            var equipmentList = new List<Equipment>();

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

                var equipment = new Equipment
                {
                    Id = Guid.NewGuid(),
                    Name = name,
                    BoughtDate = boughtDateTime,
                    Price = rand.Next(1, 1000001)
                };

                // Generate a random number of revisions (up to 5) for this equipment
                var numRevisions = rand.Next(0, 6);
                for (int j = 0; j < numRevisions; j++)
                {
                    var revisionDateTime = equipment.BoughtDate.AddDays(rand.Next(1, (DateTime.Now - equipment.BoughtDate).Days));
                    var revision = new Revision
                    {
                        Id = Guid.NewGuid(),
                        Name = $"{equipment.Name} Revision",
                        DateTime = revisionDateTime,
                        EquipmentId = equipment.Id,
                        Equipment = equipment
                    };
                    equipment.Revisions.Add(revision);
                }

                // Generate a random number of actions (1-4) for this equipment
                var numActions = rand.Next(1, 5);
                for (int j = 0; j < numActions; j++)
                {
                    var action = new Action
                    {
                        Id = Guid.NewGuid(),
                        Name = $"{equipment.Name} Action {j + 1}",
                        DateTime = DateTime.Now,
                        Description = $"Action {j + 1} was performed on {equipment.Name}",
                        EquipmentID = equipment.Id,
                        Equipment = equipment
                    };
                    equipment.Actions.Add(action);
                }

                equipmentList.Add(equipment);
            }

            return equipmentList;
        }

    }

}

