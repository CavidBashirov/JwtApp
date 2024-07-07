using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Helpers;
using Repository.Repositories.Interfaces;

namespace Repository.Repositories
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(AppDbContext context) : base(context)
        {
           
        }

        public async Task<IEnumerable<Country>> GetAllWithCities()
        {
            return await _entities.IncludeMultiple<Country>(m => m.Cities).ToListAsync();
        }
    }
}
