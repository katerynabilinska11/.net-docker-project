using PlatformService.Models;

namespace PlatformService.Data
{
    public class PlatformRepository : IPlatformRepository
    {
        private AppDbContext _context;

        public PlatformRepository(AppDbContext context) 
        {
            _context = context;
        }

        public void CreatePlatform(Platform platform)
        {
            if (platform == null)
                throw new ArgumentNullException(nameof(platform));

            _context.Add(platform);
            SaveChanges();
        }

        public IEnumerable<Platform> GetAllPlarforms()
        {
            return _context.Platforms.ToList();
        }

        public Platform GetPlatformById(int id)
        {
            return _context.Platforms.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges() => _context.SaveChanges() >= 0;
    }
}
