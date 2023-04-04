using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ppt23.Shared
{
    using System;
    using System.Collections.Generic;

    public class RevisionVm
    {
        public string Id { get; set; }
        public string Name { get; set; }

        public static List<RevisionVm> RtnRndListRevisions(int count)
        {
            var rand = new Random();
            var list = new List<RevisionVm>();

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
                };

                list.Add(equipment);
            }

            return list;
        }
    }

}