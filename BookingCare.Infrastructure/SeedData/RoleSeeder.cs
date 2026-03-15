using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace BookingCare.Infrastructure.SeedData
{
    public static class RoleSeeder
    {
        public static void SeedRoles(ModelBuilder builder)
        {
            var seedDataPath = Path.Combine(Directory.GetCurrentDirectory(), "Seeder", "roles.json");
            if (File.Exists(seedDataPath))
            {
                var roleData = File.ReadAllText(seedDataPath);
                var rolesList = JsonConvert.DeserializeObject<List<IdentityRole<Guid>>>(roleData);

                if (rolesList != null && rolesList.Any())
                {
                    foreach (var role in rolesList)
                    {
                        role.NormalizedName = role.Name?.ToUpper();
                        if (role.Id == Guid.Empty)
                        {
                            role.Id = Guid.NewGuid(); 
                        }
                    }
                    builder.Entity<IdentityRole<Guid>>().HasData(rolesList);
                }
            }
        }
    }
}
