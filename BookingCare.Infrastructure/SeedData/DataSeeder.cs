using BookingCare.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Text.Json;

namespace BookingCare.Infrastructure.SeedData
{
    public static class DataSeeder
    {
        public static async Task SeedNotificationTemplatesAsync(IServiceProvider serviceProvider)
        {
            using var scope = serviceProvider.CreateScope();
            var context = scope.ServiceProvider.GetRequiredService<DataContext>();

            if (!await context.NotificationTypes.AnyAsync())
            {
                var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Seeder", "notificationType.json");

                if (File.Exists(filePath))
                {
                    var jsonData = await File.ReadAllTextAsync(filePath);
                    var options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true
                    };
                    options.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
                    var templates = JsonSerializer.Deserialize<List<NotificationType>>(jsonData, options);
                    if (templates != null && templates.Any())
                    {
                        await context.NotificationTypes.AddRangeAsync(templates);
                        await context.SaveChangesAsync();
                        Console.WriteLine("Đã seed dữ liệu Notification Templates thành công!");
                    }
                }
                else
                {
                    Console.WriteLine($"Không tìm thấy file JSON tại: {filePath}");
                }
            }
        }
    }
}
