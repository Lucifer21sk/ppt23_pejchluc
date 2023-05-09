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
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime DateTime { get; set; }

        public static List<RevisionVm> GenerateRandomRevisions(int count)
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

                var equipment = new RevisionVm
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