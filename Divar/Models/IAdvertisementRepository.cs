﻿namespace Divar.Repositories
{
    public interface IAdvertisementRepository
    {
        Task<IEnumerable<Advertisement>> GetAllAdvertisementsAsync(int pageNumber, int pageSize, string category = "", string searchTerm = "");
        Task<Advertisement> GetAdvertisementByIdAsync(int id);
        Task AddAdvertisementAsync(Advertisement advertisement);
        Task UpdateAdvertisementAsync(Advertisement advertisement);
        Task DeleteAdvertisementAsync(int id);
        Task<int> GetTotalAdvertisementsCountAsync(string category = "", string searchTerm = "");
        Task<IEnumerable<Advertisement>> GetAdvertisementsByUserIdAsync(int userId, int pageNumber, int pageSize);
        Task<int> GetTotalAdvertisementsCountByUserIdAsync(int userId);
    }
}
