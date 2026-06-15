using Models.Coffees.Base;

namespace Services.Interfaces
{
    public interface ICoffeeService
    {
        Task<IEnumerable<CoffeeGrid>> GetAllCoffeesAsync();
    }
}
