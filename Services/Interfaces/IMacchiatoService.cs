using Models.Coffees;

namespace Services.Interfaces
{
    public interface IMacchiatoService
    {
        Task<IEnumerable<MacchiatoDetails>> GetAllMacchiatoCoffeesAsync();
        Task<MacchiatoDetails?> GetMacchiatoCoffeeAsync(Guid id);
    }
}
