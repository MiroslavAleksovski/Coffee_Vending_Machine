using Models.Coffees;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class AmericanoService : IAmericanoService
    {
        private readonly IAmericanoRepository _americanoRepository;

        public AmericanoService(IAmericanoRepository americanoRepository)
        {
            _americanoRepository = americanoRepository;
        }

        public async Task<IEnumerable<AmericanoDetails>> GetAllAmericanoCoffeesAsync()
        {
            return await _americanoRepository.GetAllAmericanoCoffeesAsync();
        }

        public async Task<AmericanoDetails?> GetAmericanoCoffeeAsync(Guid id)
        {
            return await _americanoRepository.GetAmericanoCoffeeAsync(id);
        }
    }
}
