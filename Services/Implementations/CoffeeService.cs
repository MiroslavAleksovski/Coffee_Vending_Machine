using Models.Coffees.Base;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class CoffeeService : ICoffeeService
    {
        private readonly ICoffeeRepository _coffeeRepository;

        public CoffeeService(ICoffeeRepository coffeeRepository)
        {
            _coffeeRepository = coffeeRepository;
        }

        public async Task<IEnumerable<CoffeeGrid>> GetAllCoffeesAsync()
        {
            return await _coffeeRepository.GetAllCoffeesAsync();
        }
    }
}
