using Models.Coffees;

namespace Repositories.Interfaces
{
    public interface IEspressoRepository
    {
        Task<IEnumerable<EspressoDetails>> GetAllEspressoCoffeesAsync();
        Task<EspressoDetails?> GetEspressoCoffeeAsync(Guid id);
    }
}
