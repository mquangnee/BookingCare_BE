using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookingCare.Infrastructure.SeedData
{
    public static class DoctorSeeder
    {
        public static void SeedDoctors(ModelBuilder builder)
        {
            var seedDataPath = Path.Combine(Directory.GetCurrentDirectory(), "Seeder", "doctors.json");
            if (File.Exists(seedDataPath))
            {
                var data = File.ReadAllText(seedDataPath);
                var list = JsonConvert.DeserializeObject<List<Doctor>>(data);

                if (list != null && list.Any())
                {
                    foreach (var item in list)
                    {
                        if (item.Id == Guid.Empty)
                        {
                            item.Id = Guid.NewGuid();
                        }

                        // Xử lý mặc định nếu SubSpecialties bị null trong JSON
                        if (item.SubSpecialties == null)
                        {
                            item.SubSpecialties = new List<string>();
                        }
                    }
                    builder.Entity<Doctor>().HasData(list);
                }
            }
        }
    }
}