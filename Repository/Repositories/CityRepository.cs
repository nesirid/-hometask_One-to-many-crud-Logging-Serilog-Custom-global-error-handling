using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Data;
using Repository.Repositories.Interfaces;


namespace Repository.Repositories
{
    public class CityRepository : BaseRepository<City>, ICityRepository
    {
        public CityRepository(AppDbContext context) : base(context)
        {


        }
        public async Task<City> GetByNameAsync(string name)
        {
            return await _context.Cities.FirstOrDefaultAsync(c => c.Name == name);
        }
    }
}
