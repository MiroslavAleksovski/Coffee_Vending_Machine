using Models.Coffees;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class LatteService : ILatteService
    {
        private readonly ILatteRepository _latteRepository;

        public LatteService(ILatteRepository latteRepository)
        {
            _latteRepository = latteRepository;
        }

        public async Task<IEnumerable<LatteDetails>> GetAllLatteCoffeesAsync()
        {
            return await _latteRepository.GetAllLatteCoffeesAsync();
        }

        public async Task<LatteDetails?> GetLatteCoffeeAsync(Guid id)
        {
            return await _latteRepository.GetLatteCoffeeAsync(id);
        }
    }
}
