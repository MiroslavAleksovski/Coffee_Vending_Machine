using Models.Coffees;

namespace Repositories.Interfaces
{
    public interface IAmericanoRepository
    {
        Task<IEnumerable<AmericanoDetails>> GetAllAmericanoCoffeesAsync();
        Task<AmericanoDetails?> GetAmericanoCoffeeAsync(Guid id);
    }
}
