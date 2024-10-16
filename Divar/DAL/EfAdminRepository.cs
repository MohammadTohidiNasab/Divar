namespace Divar.DAL
{
    public class EfAdminRepository : IAdminRepository
    {
        private readonly DivarDbContext _context;

        public EfAdminRepository(DivarDbContext context)
        {
            _context = context;
        }

        public IEnumerable<User> GetUsers()
        {
            return _context.Users.ToList();
        }

        public IEnumerable<Advertisement> GetAdvertisements()
        {
            return _context.Advertisements.ToList();
        }

        public IEnumerable<Comment> GetComments()
        {
            return _context.Comments.ToList();
        }
    }

}
