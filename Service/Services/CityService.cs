using AutoMapper;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Helpers.Exceptions;
using Repository.Repositories.Interfaces;
using Service.DTOs.Cities;
using Service.Services.Interfaces;

namespace Service.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepo;
        private readonly ICountryRepository _countryRepo;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepo,
                           IMapper mapper,
                           ICountryRepository countryRepo)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
            _countryRepo = countryRepo;

        }

        public async Task CreateAsync(CityCreateDto model)
        {
            var existCountry = await _countryRepo.GetByIdAsync(model.CountryId);
            if (existCountry == null) throw new NotFoundException($"{model.CountryId} - Country notfound");
            var data = _mapper.Map<City>(model);
            await _cityRepo.CreateAsync(data);

        }

        public async Task DeleteAsync(int id)
        {
            var data = await _cityRepo.GetByIdAsync(id);
            if (data is null) throw new NotFoundException($"{id} - Data notfound");
            await _cityRepo.DeleteAsync(data);
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CityDto>>(await _cityRepo.FindAllWithIncludes(m=>m.Country).ToListAsync());
        }

        public async Task<CityDto> GetByIdAsync(int id)
        {
            return _mapper.Map<CityDto>(await _cityRepo.FindBy(m=>m.Id == id,m=>m.Country).FirstOrDefaultAsync());
        }
    }
}
