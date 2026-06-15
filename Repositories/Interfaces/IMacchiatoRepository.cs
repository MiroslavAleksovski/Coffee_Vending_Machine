using Models.Coffees;

namespace Repositories.Interfaces
{
    public interface IMacchiatoRepository
    {
        Task<IEnumerable<MacchiatoDetails>> GetAllMacchiatoCoffeesAsync();
        Task<MacchiatoDetails?> GetMacchiatoCoffeeAsync(Guid id);
    }
}
