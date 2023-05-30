namespace Ppt23.Api.Data
{
    public class Action
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateTime { get; set; }
        public string Description { get; set; }
        public Guid EquipmentID { get; set; }
        public Guid WorkerID { get; set; }
        public Worker Worker { get; set; } = null!;
        public Equipment Equipment { get; set; } = null!;

        public static string GenerateRandomName()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int length = random.Next(1, 11);
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public static string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            return new string(Enumerable.Repeat(chars, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static string GenerateRandomDescription()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            Random random = new Random();
            int length = random.Next(10, 20);
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        public static DateTime GenerateRandomDateTime()
        {
            Random random = new Random();
            int days = random.Next(0, 101); // Random number of days between 0 and 100
            DateTime currentDate = DateTime.Now.Date;
            return currentDate.AddDays(-days);
        }
    }
}
