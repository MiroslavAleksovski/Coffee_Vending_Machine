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
    public class LatteRepository : ILatteRepository
    {
        private readonly string _connectionString;

        public LatteRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<LatteDetails>> GetAllLatteCoffeesAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var latteList = new List<LatteDetails>();

            await connection.QueryAsync<LatteDetails, Sugar, Milk, Water, Creamer, Amount, Amount, LatteDetails>(
                LatteSqlConstants.GetAll,
                (latte, sugar, milk, water, creamer, milkAmount, sugarAmount) =>
                {
                    var existingLatte = latteList.FirstOrDefault(l => l.Id == latte.Id);

                    if (existingLatte == null)
                    {
                        existingLatte = latte;
                        existingLatte.Sugar = sugar;
                        existingLatte.Sugar.Amounts = new List<Amount>();
                        existingLatte.Milk = milk;
                        existingLatte.Milk.Amounts = new List<Amount>();
                        existingLatte.Water = water;
                        existingLatte.Creamer = creamer;
                        latteList.Add(existingLatte);
                    }

                    if (milkAmount != null &&
                        milkAmount.Id != Guid.Empty &&
                        !existingLatte.Milk.Amounts.Any(a => a.Id == milkAmount.Id))
                    {
                        existingLatte.Milk.Amounts.Add(milkAmount);
                    }

                    if (sugarAmount != null &&
                        sugarAmount.Id != Guid.Empty &&
                        !existingLatte.Sugar.Amounts.Any(a => a.Id == sugarAmount.Id))
                    {
                        existingLatte.Sugar.Amounts.Add(sugarAmount);
                    }

                    return existingLatte;
                },
                splitOn: "Id,Id,Id,Id,Id,Id");

            return latteList;
        }

        public async Task<LatteDetails?> GetLatteCoffeeAsync(Guid id)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            LatteDetails? latte = null;

            await connection.QueryAsync<LatteDetails, Sugar, Milk, Water, Creamer, Amount, Amount, LatteDetails>(
                LatteSqlConstants.GetById,
                (lat, sugar, milk, water, creamer, milkAmount, sugarAmount) =>
                {
                    if (latte == null)
                    {
                        latte = lat;
                        latte.Sugar = sugar;
                        latte.Sugar.Amounts = new List<Amount>();
                        latte.Milk = milk;
                        latte.Milk.Amounts = new List<Amount>();
                        latte.Water = water;
                        latte.Creamer = creamer;
                    }

                    if (milkAmount != null &&
                        milkAmount.Id != Guid.Empty &&
                        !latte.Milk.Amounts.Any(a => a.Id == milkAmount.Id))
                    {
                        latte.Milk.Amounts.Add(milkAmount);
                    }

                    if (sugarAmount != null &&
                        sugarAmount.Id != Guid.Empty &&
                        !latte.Sugar.Amounts.Any(a => a.Id == sugarAmount.Id))
                    {
                        latte.Sugar.Amounts.Add(sugarAmount);
                    }

                    return latte;
                },
                new { Id = id },
                splitOn: "Id,Id,Id,Id,Id,Id");

            return latte;
        }
    }
}
