

namespace Ppt23.Api.Data
{
    public class SeedingData
    {
        private readonly PptDbContext _db;

        public SeedingData(PptDbContext db)
        {
            _db = db;
        }

        public async Task SeedData()
        {
            if (!_db.Equipment.Any())
            {
                var equipmentList = Equipment.RndEquipmentList(10);
                _db.Equipment.AddRange(equipmentList);
            }

            await _db.SaveChangesAsync();
        }

    }

}