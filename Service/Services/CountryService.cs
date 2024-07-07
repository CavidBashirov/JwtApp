using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Repositories.Interfaces;
using Service.DTOs.Countries;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;

        public CountryService(ICountryRepository countryRepo, IMapper mapper)
        {
            _countryRepo = countryRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CountryCreateDto model)
        {
            await _countryRepo.CreateAsync(_mapper.Map<Country>(model));
        }

        public async Task DeleteAsync(int id)
        {
            await _countryRepo.DeleteAsync(await _countryRepo.GetByIdAsync(id));
        }

        public async Task EditAsync(int id, CountryEditDto model)
        {
            var country = await _countryRepo.GetByIdAsync(id);
            _mapper.Map(model, country);
            await _countryRepo.UpdateAsync(country);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.GetAllAsync());
        }

        public async Task<IEnumerable<CountryByCitiesDto>> GetAllWithCitiesAsync()
        {
            return _mapper.Map<IEnumerable<CountryByCitiesDto>>(await _countryRepo.GetAllWithCities());
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CountryDto>(await _countryRepo.GetByIdAsync(id));
        }

        public async Task<CountryByCitiesDto> GetCountryByNameWithCities(string name)
        {
            var existCountry = await _countryRepo.FindBy(m => m.Name == name, m => m.Cities).FirstOrDefaultAsync();
            return _mapper.Map<CountryByCitiesDto>(existCountry);
        }
    }
}
