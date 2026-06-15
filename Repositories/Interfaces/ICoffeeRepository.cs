using Models.Coffees.Base;

namespace Repositories.Interfaces
{
    public interface ICoffeeRepository
    {
        Task<IEnumerable<CoffeeGrid>> GetAllCoffeesAsync();
    }
}
