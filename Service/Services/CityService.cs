using AutoMapper;
using Domain.Entities;
using Repository.Repositories.Interfaces;
using Service.DTOs.Admin.Cities;
using Service.Services.Interface;


namespace Service.Services
{
    public class CityService : ICityService
    {
        private readonly ICityRepository _cityRepo;
        private readonly IMapper _mapper;

        public CityService(ICityRepository cityRepo, IMapper mapper)
        {
            _cityRepo = cityRepo;
            _mapper = mapper;
        }

        public async Task CreateAsync(CityCreateDto model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));
            await _cityRepo.CreateAsync(_mapper.Map<City>(model));
        }

        public async Task EditAsync(int id, CityEditDto model)
        {
            if (model == null) throw new ArgumentNullException(nameof(model));

            var existingCity = await _cityRepo.GetById(id);
            if (existingCity == null) throw new KeyNotFoundException("City not found");

            _mapper.Map(model, existingCity);
            await _cityRepo.EditAsync(id, existingCity);
        }

        public async Task DeleteAsync(int id)
        {
            var city = await _cityRepo.GetById(id);
            if (city == null) throw new KeyNotFoundException("City not found");
            await _cityRepo.DeleteAsync(city);
        }

        public async Task<IEnumerable<CityDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<CityDto>>(await _cityRepo.GetAllAsync());
        }

        public async Task<CityDto> GetByIdAsync(int id)
        {
            var city = await _cityRepo.GetById(id);
            if (city == null) throw new KeyNotFoundException("City not found");
            return _mapper.Map<CityDto>(city);
        }
        public async Task<CityDto> GetByNameAsync(string name)
        {
            var city = await _cityRepo.GetByNameAsync(name);
            if (city == null) throw new KeyNotFoundException("City not found");
            return _mapper.Map<CityDto>(city);
        }
    }
}
