using PlatformService.Models;

namespace PlatformService.Data
{
    public static class PrepDB
    {
        public static void Populate(IApplicationBuilder app)
        {
            using(var serviceScope = app.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<AppDbContext>();
                SeedData(context);
            }
        }

        private static void SeedData(AppDbContext context) 
        {
            if (!context.Platforms.Any())
            {
                Console.WriteLine("Seeding data");
                context.Platforms.AddRange(
                    new Platform() { Name = ".NET", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "SQL Server", Publisher = "Microsoft", Cost = "Free" },
                    new Platform() { Name = "Docker", Publisher = "Docker Inc", Cost = "Free" }
                );
                context.SaveChanges();
            }
            else
                Console.WriteLine("There is already data in the system");
        }
    }
}
