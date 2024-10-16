namespace Divar.DAL
{
    public class EfAdvertisementRepository : IAdvertisementRepository
    {
        private readonly DivarDbContext _context;

        public EfAdvertisementRepository(DivarDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Advertisement>> GetAllAdvertisementsAsync(int pageNumber, int pageSize, string category = "", string searchTerm = "")
        {
            var query = _context.Advertisements.AsQueryable();

            // Apply filters
            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(ad => ad.Category == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(ad => ad.Title.Contains(searchTerm));
            }

            return await query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Advertisement> GetAdvertisementByIdAsync(int id)
        {
            return await _context.Advertisements
                .Include(a => a.User)
                .FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task AddAdvertisementAsync(Advertisement advertisement)
        {
            await _context.Advertisements.AddAsync(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAdvertisementAsync(Advertisement advertisement)
        {
            _context.Advertisements.Update(advertisement);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAdvertisementAsync(int id)
        {
            var advertisement = await _context.Advertisements.FindAsync(id);
            if (advertisement != null)
            {
                _context.Advertisements.Remove(advertisement);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<int> GetTotalAdvertisementsCountAsync(string category = "", string searchTerm = "")
        {
            var query = _context.Advertisements.AsQueryable();

            if (!string.IsNullOrWhiteSpace(category))
            {
                query = query.Where(ad => ad.Category == category);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                query = query.Where(ad => ad.Title.Contains(searchTerm));
            }

            return await query.CountAsync();
        }
    }
}
