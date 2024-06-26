using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Countries;
using Service.Services.Interface;


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
            if (model == null) throw new ArgumentNullException(nameof(model));
            await _countryRepo.CreateAsync(_mapper.Map<Country>(model));
        }

        public async Task EditAsync(int id, CountryEditDto model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var existingCountry = await _countryRepo.GetById(id);
            if (existingCountry == null) throw new KeyNotFoundException("Country not found");

            _mapper.Map(model, existingCountry);
            await _countryRepo.EditAsync(id, existingCountry);
        }

        public async Task DeleteAsync(int id)
        {
            var country = await _countryRepo.GetById(id);
            if (country == null) throw new KeyNotFoundException("Country not found");
            await _countryRepo.DeleteAsync(country);
        }

        public async Task<IEnumerable<CountryDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CountryDto>>(await _countryRepo.GetAllAsync());
        }

        public async Task<CountryDto> GetByIdAsync(int id)
        {
            var country = await _countryRepo.GetById(id);
            if (country == null) throw new KeyNotFoundException("Country not found");
            return _mapper.Map<CountryDto>(country);
        }
    }
}
