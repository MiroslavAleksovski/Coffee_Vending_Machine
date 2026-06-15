using Models.Coffees;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CappuccinoService : ICappuccinoService
    {
        private readonly ICappuccinoRepository _cappuccinoRepository;

        public CappuccinoService(ICappuccinoRepository cappuccinoRepository)
        {
            _cappuccinoRepository = cappuccinoRepository;
        }

        public async Task<IEnumerable<CappuccinoDetails>> GetAllCappuccinoCoffeesAsync()
        {
            return await _cappuccinoRepository.GetAllCappuccinoCoffeesAsync();
        }

        public async Task<CappuccinoDetails?> GetCappuccinoCoffeeAsync(Guid id)
        {
            return await _cappuccinoRepository.GetCappuccinoCoffeeAsync(id);
        }
    }
}
