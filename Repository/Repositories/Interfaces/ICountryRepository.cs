﻿using Domain.Entities;

namespace Repository.Repositories.Interfaces
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task<IEnumerable<Country>> GetAllWithCities();
    }
}