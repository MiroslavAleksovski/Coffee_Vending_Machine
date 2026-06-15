using Models.Coffees;

namespace Services.Interfaces
{
    public interface ICappuccinoService
    {
        Task<IEnumerable<CappuccinoDetails>> GetAllCappuccinoCoffeesAsync();
        Task<CappuccinoDetails?> GetCappuccinoCoffeeAsync(Guid id);
    }
}
