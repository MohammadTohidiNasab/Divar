namespace Divar.Models
{
    public interface IAdminRepository
    {
        IEnumerable<User> GetUsers();
        IEnumerable<Advertisement> GetAdvertisements();
        IEnumerable<Comment> GetComments();
    }

}
