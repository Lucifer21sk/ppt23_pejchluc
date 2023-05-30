namespace Ppt23.Api.Data
{
    public class Worker
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string JobTitle { get; set; } = string.Empty;
        public List<Action> Actions { get; set; } = new();

        public static string GenerateRandomName()
        {
            string[] names = { "John", "Alice", "David", "Emily", "Michael", "Olivia", "Jacob", "Sophia" };
            Random random = new Random();
            return names[random.Next(names.Length)];
        }

        public static string GenerateRandomJobTitle()
        {
            string[] jobTitles = { "Engineer", "Manager", "Developer", "Designer", "Analyst", "Coordinator" };
            Random random = new Random();
            return jobTitles[random.Next(jobTitles.Length)];
        }
    }
}
