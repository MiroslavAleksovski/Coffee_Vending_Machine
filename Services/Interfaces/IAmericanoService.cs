using Models.Coffees;

namespace Services.Interfaces
{
    public interface IAmericanoService
    {
        Task<IEnumerable<AmericanoDetails>> GetAllAmericanoCoffeesAsync();
        Task<AmericanoDetails?> GetAmericanoCoffeeAsync(Guid id);
    }
}
