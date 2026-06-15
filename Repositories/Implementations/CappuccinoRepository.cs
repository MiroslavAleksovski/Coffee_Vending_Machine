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
    public class CappuccinoRepository : ICappuccinoRepository
    {
        private readonly string _connectionString;

        public CappuccinoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<CappuccinoDetails>> GetAllCappuccinoCoffeesAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var cappuccinoList = new List<CappuccinoDetails>();

            await connection.QueryAsync<CappuccinoDetails, Sugar, Milk, Water, Caramel, Amount, Amount, CappuccinoDetails>(
                CappuccinoSqlConstants.GetAll,
                (cappuccino, sugar, milk, water, caramel, milkAmount, sugarAmount) =>
                {
                    var existingCappuccino = cappuccinoList.FirstOrDefault(c => c.Id == cappuccino.Id);

                    if (existingCappuccino == null)
                    {
                        existingCappuccino = cappuccino;
                        existingCappuccino.Sugar = sugar;
                        existingCappuccino.Sugar.Amounts = new List<Amount>();
                        existingCappuccino.Milk = milk;
                        existingCappuccino.Milk.Amounts = new List<Amount>();
                        existingCappuccino.Water = water;
                        existingCappuccino.Caramel = caramel;
                        cappuccinoList.Add(existingCappuccino);
                    }

                    if (milkAmount != null &&
                        milkAmount.Id != Guid.Empty &&
                        !existingCappuccino.Milk.Amounts.Any(a => a.Id == milkAmount.Id))
                    {
                        existingCappuccino.Milk.Amounts.Add(milkAmount);
                    }

                    if (sugarAmount != null &&
                        sugarAmount.Id != Guid.Empty &&
                        !existingCappuccino.Sugar.Amounts.Any(a => a.Id == sugarAmount.Id))
                    {
                        existingCappuccino.Sugar.Amounts.Add(sugarAmount);
                    }

                    return existingCappuccino;
                },
                splitOn: "Id,Id,Id,Id,Id,Id");

            return cappuccinoList;
        }

        public async Task<CappuccinoDetails?> GetCappuccinoCoffeeAsync(Guid id)
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            CappuccinoDetails? cappuccino = null;

            await connection.QueryAsync<CappuccinoDetails, Sugar, Milk, Water, Caramel, Amount, Amount, CappuccinoDetails>(
                CappuccinoSqlConstants.GetById,
                (cap, sugar, milk, water, caramel, milkAmount, sugarAmount) =>
                {
                    if (cappuccino == null)
                    {
                        cappuccino = cap;
                        cappuccino.Sugar = sugar;
                        cappuccino.Sugar.Amounts = new List<Amount>();
                        cappuccino.Milk = milk;
                        cappuccino.Milk.Amounts = new List<Amount>();
                        cappuccino.Water = water;
                        cappuccino.Caramel = caramel;
                    }

                    if (milkAmount != null &&
                        milkAmount.Id != Guid.Empty &&
                        !cappuccino.Milk.Amounts.Any(a => a.Id == milkAmount.Id))
                    {
                        cappuccino.Milk.Amounts.Add(milkAmount);
                    }

                    if (sugarAmount != null &&
                        sugarAmount.Id != Guid.Empty &&
                        !cappuccino.Sugar.Amounts.Any(a => a.Id == sugarAmount.Id))
                    {
                        cappuccino.Sugar.Amounts.Add(sugarAmount);
                    }

                    return cappuccino;
                },
                new { Id = id },
                splitOn: "Id,Id,Id,Id,Id,Id");

            return cappuccino;
        }
    }
}
