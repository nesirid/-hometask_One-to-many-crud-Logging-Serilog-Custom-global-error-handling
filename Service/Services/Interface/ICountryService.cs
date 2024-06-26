using Service.DTOs.Admin.Countries;


namespace Service.Services.Interface
{
    public interface ICountryService
    {
        Task<IEnumerable<CountryDto>> GetAllAsync();
        Task EditAsync(int id, CountryEditDto model);
        Task CreateAsync(CountryCreateDto model);
        Task DeleteAsync(int id);
        Task<CountryDto> GetByIdAsync(int id);
    }
}
