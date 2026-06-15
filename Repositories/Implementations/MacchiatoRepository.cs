using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Models;
using Models.Coffees;
using Models.Features;
using Repositories.Constants;
using Repositories.Interfaces;
using Dapper;

namespace Repositories.Implementations
{
    public class MacchiatoRepository : IMacchiatoRepository
    {
        private readonly string _connectionString;

        public MacchiatoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<MacchiatoDetails>> GetAllMacchiatoCoffeesAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var macchiatoList = new List<MacchiatoDetails>();

            await connection.QueryAsync<MacchiatoDetails, Sugar, Milk, Water, Amount, Amount, MacchiatoDetails>(
                MacchiatoSqlConstants.GetAll,
                (macchiato, sugar, milk, water, milkAmount, sugarAmount) =>
                {
                    var existingMacchiato = macchiatoList.FirstOrDefault(m => m.Id == macchiato.Id);

                    if (existingMacchiato == null)
                    {
                        existingMacchiato = macchiato;
                        existingMacchiato.Sugar = sugar;
                        existingMacchiato.Sugar.Amounts = new List<Amount>();
                        existingMacchiato.Milk = milk;
                        existingMacchiato.Milk.Amounts = new List<Amount>();
                        existingMacchiato.Water = water;
                        macchiatoList.Add(existingMacchiato);
                    }

                    if (milkAmount != null &&
                        milkAmount.Id != Guid.Empty &&
                        !existingMacchiato.Milk.Amounts.Any(a => a.Id == milkAmount.Id))
                    {
                        existingMacchiato.Milk.Amounts.Add(milkAmount);
                    }

                    if (sugarAmount != null &&
                        sugarAmount.Id != Guid.Empty &&
                        !existingMacchiato.Sugar.Amounts.Any(a => a.Id == sugarAmount.Id))
                    {
                        existingMacchiato.Sugar.Amounts.Add(sugarAmount);
                    }

                    return existingMacchiato;
                },
                splitOn: "Id,Id,Id,Id,Id");

            return macchiatoList;
        }

        public async Task<MacchiatoDetails?> GetMacchiatoCoffeeAsync(Guid id)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            MacchiatoDetails? macchiato = null;

            await connection.QueryAsync<MacchiatoDetails, Sugar, Milk, Water, Amount, Amount, MacchiatoDetails>(
                MacchiatoSqlConstants.GetById,
                (mac, sugar, milk, water, milkAmount, sugarAmount) =>
                {
                    if (macchiato == null)
                    {
                        macchiato = mac;
                        macchiato.Sugar = sugar;
                        macchiato.Sugar.Amounts = new List<Amount>();
                        macchiato.Milk = milk;
                        macchiato.Milk.Amounts = new List<Amount>();
                        macchiato.Water = water;
                    }

                    if (milkAmount != null &&
                        milkAmount.Id != Guid.Empty &&
                        !macchiato.Milk.Amounts.Any(a => a.Id == milkAmount.Id))
                    {
                        macchiato.Milk.Amounts.Add(milkAmount);
                    }

                    if (sugarAmount != null &&
                        sugarAmount.Id != Guid.Empty &&
                        !macchiato.Sugar.Amounts.Any(a => a.Id == sugarAmount.Id))
                    {
                        macchiato.Sugar.Amounts.Add(sugarAmount);
                    }

                    return macchiato;
                },
                new { Id = id },
                splitOn: "Id,Id,Id,Id,Id");

            return macchiato;
        }
    }
}
