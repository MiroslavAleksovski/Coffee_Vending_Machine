using Models.Coffees;

namespace Repositories.Interfaces
{
    public interface ICappuccinoRepository
    {
        Task<IEnumerable<CappuccinoDetails>> GetAllCappuccinoCoffeesAsync();
        Task<CappuccinoDetails?> GetCappuccinoCoffeeAsync(Guid id);
    }
}
