using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookingCare.Infrastructure.SeedData
{
    public static class ServiceSeeder
    {
        public static void SeedServices(ModelBuilder builder)
        {
            var seedDataPath = Path.Combine(Directory.GetCurrentDirectory(), "Seeder", "services.json");
            if (File.Exists(seedDataPath))
            {
                var data = File.ReadAllText(seedDataPath);
                var list = JsonConvert.DeserializeObject<List<Service>>(data);

                if (list != null && list.Any())
                {
                    foreach (var item in list)
                    {
                        if (item.Id == Guid.Empty)
                        {
                            item.Id = Guid.NewGuid();
                        }
                    }
                    builder.Entity<Service>().HasData(list);
                }
            }
        }
    }
}