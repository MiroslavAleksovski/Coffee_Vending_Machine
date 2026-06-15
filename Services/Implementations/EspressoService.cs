using Models.Coffees;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class EspressoService : IEspressoService
    {
        private readonly IEspressoRepository _espressoRepository;

        public EspressoService(IEspressoRepository espressoRepository)
        {
            _espressoRepository = espressoRepository;
        }

        public async Task<IEnumerable<EspressoDetails>> GetAllEspressoCoffeesAsync()
        {
            return await _espressoRepository.GetAllEspressoCoffeesAsync();
        }

        public async Task<EspressoDetails?> GetEspressoCoffeeAsync(Guid id)
        {
            return await _espressoRepository.GetEspressoCoffeeAsync(id);
        }
    }
}
