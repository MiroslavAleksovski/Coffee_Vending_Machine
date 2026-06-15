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
    public class EspressoRepository : IEspressoRepository
    {
        private readonly string _connectionString;

        public EspressoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<EspressoDetails>> GetAllEspressoCoffeesAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var espressoList = new List<EspressoDetails>();

            await connection.QueryAsync<EspressoDetails, Sugar, Water, Amount, EspressoDetails>(
                EspressoSqlConstants.GetAll,
                (espresso, sugar, water, sugarAmount) =>
                {
                    var existingEspresso = espressoList.FirstOrDefault(e => e.Id == espresso.Id);

                    if (existingEspresso == null)
                    {
                        existingEspresso = espresso;
                        existingEspresso.Sugar = sugar;
                        existingEspresso.Sugar.Amounts = new List<Amount>();
                        existingEspresso.Water = water;
                        espressoList.Add(existingEspresso);
                    }

                    if (sugarAmount != null &&
                        sugarAmount.Id != Guid.Empty &&
                        !existingEspresso.Sugar.Amounts.Any(a => a.Id == sugarAmount.Id))
                    {
                        existingEspresso.Sugar.Amounts.Add(sugarAmount);
                    }

                    return existingEspresso;
                },
                splitOn: "Id,Id,Id");

            return espressoList;
        }

        public async Task<EspressoDetails?> GetEspressoCoffeeAsync(Guid id)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            EspressoDetails? espresso = null;

            await connection.QueryAsync<EspressoDetails, Sugar, Water, Amount, EspressoDetails>(
                EspressoSqlConstants.GetById,
                (esp, sugar, water, sugarAmount) =>
                {
                    if (espresso == null)
                    {
                        espresso = esp;
                        espresso.Sugar = sugar;
                        espresso.Sugar.Amounts = new List<Amount>();
                        espresso.Water = water;
                    }

                    if (sugarAmount != null &&
                        sugarAmount.Id != Guid.Empty &&
                        !espresso.Sugar.Amounts.Any(a => a.Id == sugarAmount.Id))
                    {
                        espresso.Sugar.Amounts.Add(sugarAmount);
                    }

                    return espresso;
                },
                new { Id = id },
                splitOn: "Id,Id,Id");

            return espresso;
        }
    }
}
