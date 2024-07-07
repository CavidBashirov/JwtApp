using Service.DTOs.Cities;

namespace Service.Services.Interfaces
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task<CityDto> GetByIdAsync(int id);
        Task CreateAsync(CityCreateDto model);
        Task DeleteAsync(int id);
    }
}
