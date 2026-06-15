using Models.Coffees;
using Repositories.Interfaces;
using Services.Interfaces;

namespace Services.Implementations
{
    public class MacchiatoService : IMacchiatoService
    {
        private readonly IMacchiatoRepository _macchiatoRepository;

        public MacchiatoService(IMacchiatoRepository macchiatoRepository)
        {
            _macchiatoRepository = macchiatoRepository;
        }

        public async Task<IEnumerable<MacchiatoDetails>> GetAllMacchiatoCoffeesAsync()
        {
            return await _macchiatoRepository.GetAllMacchiatoCoffeesAsync();
        }

        public async Task<MacchiatoDetails?> GetMacchiatoCoffeeAsync(Guid id)
        {
            return await _macchiatoRepository.GetMacchiatoCoffeeAsync(id);
        }
    }
}
