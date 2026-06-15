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
    public class AmericanoRepository : IAmericanoRepository
    {
        private readonly string _connectionString;

        public AmericanoRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task<IEnumerable<AmericanoDetails>> GetAllAmericanoCoffeesAsync()
        {
            await using var connection = new SqlConnection(_connectionString);
            await connection.OpenAsync();

            var americanoList = new List<AmericanoDetails>();

            var types = new[] { typeof(AmericanoDetails), typeof(Sugar), typeof(Milk), typeof(Water), typeof(Caramel), typeof(Creamer), typeof(Amount), typeof(Amount) };

            await connection.QueryAsync(
                AmericanoSqlConstants.GetAll,
                types,
                objects =>
                {
                    var americano = (AmericanoDetails)objects[0];
                    var sugar = (Sugar)objects[1];
                    var milk = (Milk)objects[2];
                    var water = (Water)objects[3];
                    var caramel = (Caramel)objects[4];
                    var creamer = (Creamer)objects[5];
                    var milkAmount = (Amount)objects[6];
                    var sugarAmount = (Amount)objects[7];

                    var existingAmericano = americanoList.FirstOrDefault(a => a.Id == americano.Id);

                    if (existingAmericano == null)
                    {
                        existingAmericano = americano;
                        existingAmericano.Sugar = sugar;
                        existingAmericano.Sugar.Amounts = new List<Amount>();
                        existingAmericano.Milk = milk;
                        existingAmericano.Milk.Amounts = new List<Amount>();
                        existingAmericano.Water = water;
                        existingAmericano.Caramel = caramel;
                        existingAmericano.Creamer = creamer;
                        americanoList.Add(existingAmericano);
                    }

                    if (milkAmount != null &&
                        milkAmount.Id != Guid.Empty &&
                        !existingAmericano.Milk.Amounts.Any(a => a.Id == milkAmount.Id))
                    {
                        existingAmericano.Milk.Amounts.Add(milkAmount);
                    }

                    if (sugarAmount != null &&
                        sugarAmount.Id != Guid.Empty &&
                        !existingAmericano.Sugar.Amounts.Any(a => a.Id == sugarAmount.Id))
                    {
                        existingAmericano.Sugar.Amounts.Add(sugarAmount);
                    }

                    return existingAmericano;
                },
                splitOn: "Id,Id,Id,Id,Id,Id,Id");

                            return americanoList;
                        }

                        public async Task<AmericanoDetails?> GetAmericanoCoffeeAsync(Guid id)
                        {
                            await using var connection = new SqlConnection(_connectionString);
                            await connection.OpenAsync();

                            AmericanoDetails? americano = null;

                            var types = new[] { typeof(AmericanoDetails), typeof(Sugar), typeof(Milk), typeof(Water), typeof(Caramel), typeof(Creamer), typeof(Amount), typeof(Amount) };

                            await connection.QueryAsync(
                                AmericanoSqlConstants.GetById,
                                types,
                                objects =>
                                {
                                    var amp = (AmericanoDetails)objects[0];
                                    var sugar = (Sugar)objects[1];
                                    var milk = (Milk)objects[2];
                                    var water = (Water)objects[3];
                                    var caramel = (Caramel)objects[4];
                                    var creamer = (Creamer)objects[5];
                                    var milkAmount = (Amount)objects[6];
                                    var sugarAmount = (Amount)objects[7];

                                    if (americano == null)
                                    {
                                        americano = amp;
                                        americano.Sugar = sugar;
                                        americano.Sugar.Amounts = new List<Amount>();
                                        americano.Milk = milk;
                                        americano.Milk.Amounts = new List<Amount>();
                                        americano.Water = water;
                                        americano.Caramel = caramel;
                                        americano.Creamer = creamer;
                                    }

                                    if (milkAmount != null &&
                                        milkAmount.Id != Guid.Empty &&
                                        !americano.Milk.Amounts.Any(a => a.Id == milkAmount.Id))
                                    {
                                        americano.Milk.Amounts.Add(milkAmount);
                                    }

                                    if (sugarAmount != null &&
                                        sugarAmount.Id != Guid.Empty &&
                                        !americano.Sugar.Amounts.Any(a => a.Id == sugarAmount.Id))
                                    {
                                        americano.Sugar.Amounts.Add(sugarAmount);
                                    }

                                    return americano;
                                },
                                new { Id = id },
                                splitOn: "Id,Id,Id,Id,Id,Id,Id");

                            return americano;
                        }
                    }
                }
