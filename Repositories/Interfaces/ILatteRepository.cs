using Models.Coffees;

namespace Repositories.Interfaces
{
    public interface ILatteRepository
    {
        Task<IEnumerable<LatteDetails>> GetAllLatteCoffeesAsync();
        Task<LatteDetails?> GetLatteCoffeeAsync(Guid id);
    }
}
