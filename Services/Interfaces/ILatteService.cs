using Models.Coffees;

namespace Services.Interfaces
{
    public interface ILatteService
    {
        Task<IEnumerable<LatteDetails>> GetAllLatteCoffeesAsync();
        Task<LatteDetails?> GetLatteCoffeeAsync(Guid id);
    }
}
