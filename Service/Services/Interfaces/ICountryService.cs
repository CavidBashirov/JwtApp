using Service.DTOs.Countries;

namespace Service.Services.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task<CountryDto> GetByIdAsync(int id);
        Task CreateAsync(CountryCreateDto model);
        Task<IEnumerable<CountryByCitiesDto>> GetAllWithCitiesAsync();
        Task DeleteAsync(int id);
        Task EditAsync(int id, CountryEditDto model);
        Task<CountryByCitiesDto> GetCountryByNameWithCities(string name);

    }
}
