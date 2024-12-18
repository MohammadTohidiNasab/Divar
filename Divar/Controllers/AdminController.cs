﻿public class AdminController : Controller
{
    private readonly IAdminRepository _adminRepository;

    public AdminController(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    //نمایش محصولات و کاربران
    public async Task<IActionResult> Index()
    {
        var users = await _adminRepository.GetUsersAsync();
        var advertisements = await _adminRepository.GetAdvertisementsAsync();
        var comments = await _adminRepository.GetCommentsAsync();

        var viewModel = new AdminPanel
        {
            Users = users,
            Advertisements = advertisements,
            Comments = comments
        };

        return View(viewModel);
    }

    //حذف کاربران
    public async Task<IActionResult> DeleteUser(int id)
    {
        var user = await _adminRepository.GetUserByIdAsync(id);
        if (user == null)
        {
            return NotFound();
        }

        return View(user);
    }

    // Delete Confirm
    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        await _adminRepository.DeleteUserAsync(id, HttpContext);  
        return RedirectToAction(nameof(Index));
    }
}
