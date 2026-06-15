using Models.Coffees;

namespace Services.Interfaces
{
    public interface IEspressoService
    {
        Task<IEnumerable<EspressoDetails>> GetAllEspressoCoffeesAsync();
        Task<EspressoDetails?> GetEspressoCoffeeAsync(Guid id);
    }
}
