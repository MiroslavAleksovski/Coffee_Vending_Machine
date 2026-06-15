using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models.Coffees;
using Models.Coffees.Base;
using Repositories.Constants;
using Repositories.Interfaces;
using Dapper;

namespace Repositories.Implementations
{
    public class CoffeeRepository : ICoffeeRepository
    {
        private readonly string _connectionString;

        public CoffeeRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<CoffeeGrid>> GetAllCoffeesAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            await using var transaction = await connection.BeginTransactionAsync();

            var americanos = await connection.QueryAsync<AmericanoGrid>(CoffeeSqlConstants.GetAllAmericanos, transaction: transaction);
            var espressos = await connection.QueryAsync<EspressoGrid>(CoffeeSqlConstants.GetAllEspressos, transaction: transaction);
            var cappuccinos = await connection.QueryAsync<CappuccinoGrid>(CoffeeSqlConstants.GetAllCappuccinos, transaction: transaction);
            var lattes = await connection.QueryAsync<LatteGrid>(CoffeeSqlConstants.GetAllLattes, transaction: transaction);
            var macchiatos = await connection.QueryAsync<MacchiatoGrid>(CoffeeSqlConstants.GetAllMacchiatos, transaction: transaction);

            await transaction.CommitAsync();

            var result = new List<CoffeeGrid>();
            result.AddRange(americanos);
            result.AddRange(espressos);
            result.AddRange(cappuccinos);
            result.AddRange(lattes);
            result.AddRange(macchiatos);

            result = result.Select((coffee, index) =>
            {
                coffee.SortOrder = index + 1;
                return coffee;
            }).ToList();
                
            return result;
        }
    }
}
