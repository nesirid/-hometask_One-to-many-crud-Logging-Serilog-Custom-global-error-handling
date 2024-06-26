using Domain.Entities;


namespace Repository.Repositories.Interfaces
{
    public interface ICityRepository : IBaseRepository<City>
    {
        Task<City> GetByNameAsync(string name);
    }
}
