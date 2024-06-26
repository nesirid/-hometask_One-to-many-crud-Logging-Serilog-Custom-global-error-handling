using Service.DTOs.Admin.Cities;


namespace Service.Services.Interface
{
    public interface ICityService
    {
        Task<IEnumerable<CityDto>> GetAllAsync();
        Task EditAsync(int id, CityEditDto model);
        Task CreateAsync(CityCreateDto model);
        Task DeleteAsync(int id);
        Task<CityDto> GetByIdAsync(int id);
        Task<CityDto> GetByNameAsync(string name);
    }
}
