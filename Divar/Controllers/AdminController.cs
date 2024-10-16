public class AdminController : Controller
{
    private readonly IAdminRepository _adminRepository;

    public AdminController(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    // نمایش محصولات و کاربران
    public IActionResult Index()
    {
        var users = _adminRepository.GetUsers();
        var advertisements = _adminRepository.GetAdvertisements();
        var comments = _adminRepository.GetComments();

        var viewModel = new AdminPanel
        {
            Users = users.ToList(),
            Advertisements = advertisements.ToList(),
            Comments = comments.ToList()
        };

        return View(viewModel);
    }
}
