using Microsoft.EntityFrameworkCore;

namespace Ppt23.Api.Data
{
    public class PptDbContext : DbContext
    {
        public PptDbContext(DbContextOptions<PptDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            Guid id1 = new Guid("cd93f294-e926-4f04-bf3e-d06091f82ccc");
            Guid id2 = new Guid("9ab77602-8aac-40ed-b042-d2d4b4e04b31");
            Guid id3 = new Guid("0a7959e7-d736-414f-8834-c73c00e12afb");

            modelBuilder.Entity<Equipment>().HasData(
                new Equipment() { Id = id1, Name = "Injection", Price = 78323, BoughtDate = new DateTime(2010,12,21)},
                new Equipment() { Id = id2, Name = "Microscope", Price = 679104, BoughtDate = new DateTime(2016, 03, 24)},
                new Equipment() { Id = id3, Name= "X-Ray", Price= 452610, BoughtDate = new DateTime(2019, 09, 01)}
                );
            modelBuilder.Entity<Revision>().HasData(
                new Revision() { Id= new Guid("b106ddc7-c8c6-4370-a663-e28827862a78"), Name= "First", DateTime= new DateTime(2019,04,18), EquipmentId= id1},
                new Revision() { Id= new Guid("adb6a0a6-80b6-4637-8008-2e7ce2fc7e8e"), Name= "Second", DateTime= new DateTime(2020,04,18), EquipmentId= id1},
                new Revision() { Id= new Guid("1465be46-5dbf-4c9f-b397-df4c91176eb9"), Name= "First", DateTime= new DateTime(2019,04,18), EquipmentId= id2}
                );
            modelBuilder.Entity<Action>().HasData(
                new Action () { Id= new Guid("c406ddc7-c8c6-4370-a663-e28827863b78"), Name= "Injection Action", DateTime= DateTime.Now, Description= "Injection was performed", EquipmentID= id1}
                );

        }

        public DbSet<Equipment> Equipment => Set<Equipment>();
        public DbSet<Revision> Revisions => Set<Revision>();
        public DbSet<Action> Actions => Set<Action>();
    }
}