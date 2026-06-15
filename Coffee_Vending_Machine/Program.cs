using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Coffees;
using Models.Coffees.Base;
using Repositories.Configuration;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;

// Build configuration
var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

var services = new ServiceCollection();

// Register Configuration
services.AddSingleton<IConfiguration>(configuration);

// Register Repository
services.AddScoped<IAmericanoRepository, AmericanoRepository>();
services.AddScoped<IEspressoRepository, EspressoRepository>();
services.AddScoped<ICappuccinoRepository, CappuccinoRepository>();
services.AddScoped<ILatteRepository, LatteRepository>();
services.AddScoped<IMacchiatoRepository, MacchiatoRepository>();
services.AddScoped<ICoffeeRepository, CoffeeRepository>();

// Register Service
services.AddScoped<IAmericanoService, AmericanoService>();
services.AddScoped<IEspressoService, EspressoService>();
services.AddScoped<ICappuccinoService, CappuccinoService>();
services.AddScoped<ILatteService, LatteService>();
services.AddScoped<IMacchiatoService, MacchiatoService>();
services.AddScoped<ICoffeeService, CoffeeService>();

var serviceProvider = services.BuildServiceProvider();

// Initialize FluentMapper
FluentMapperConfiguration.Initialize();


// Main Application flow
var coffeeService = serviceProvider.GetRequiredService<ICoffeeService>();
IEnumerable<CoffeeGrid> availableCoffees = await coffeeService.GetAllCoffeesAsync();

Console.WriteLine($"Please select your coffee, by entering the corresponding number:");
foreach (var availableCoffee in availableCoffees)
{
    Console.WriteLine($"{availableCoffee.SortOrder}: {availableCoffee.Name}");
}
var totalCoffeeSortNumbers = availableCoffees.Count();
var selectedCoffeeSortNumber = Console.ReadLine();
int selectedCoffeeSortNumberAsInt = -1;
while (!int.TryParse(selectedCoffeeSortNumber, out selectedCoffeeSortNumberAsInt)
    || selectedCoffeeSortNumberAsInt < 1
    || selectedCoffeeSortNumberAsInt > totalCoffeeSortNumbers)
{
    Console.WriteLine($"{selectedCoffeeSortNumber} is not a valid number. Please enter a valid number between 1 and {totalCoffeeSortNumbers}:");
    selectedCoffeeSortNumber = Console.ReadLine();
}

CoffeeGrid? selectedGridCoffee =
    availableCoffees.FirstOrDefault(c => c.SortOrder == selectedCoffeeSortNumberAsInt);

// Get coffee details based on the selected coffee type
CoffeeDetails? selectedCoffeeDetails = selectedGridCoffee switch
{
    AmericanoGrid => await serviceProvider.GetRequiredService<IAmericanoService>()
        .GetAmericanoCoffeeAsync(selectedGridCoffee.Id),
    EspressoGrid => await serviceProvider.GetRequiredService<IEspressoService>()
        .GetEspressoCoffeeAsync(selectedGridCoffee.Id),
    CappuccinoGrid => await serviceProvider.GetRequiredService<ICappuccinoService>()
        .GetCappuccinoCoffeeAsync(selectedGridCoffee.Id),
    LatteGrid => await serviceProvider.GetRequiredService<ILatteService>()
        .GetLatteCoffeeAsync(selectedGridCoffee.Id),
    MacchiatoGrid => await serviceProvider.GetRequiredService<IMacchiatoService>()
        .GetMacchiatoCoffeeAsync(selectedGridCoffee.Id),
    _ => null
};

if (selectedCoffeeDetails == null)
{
    Console.WriteLine("Error: Could not retrieve coffee details.");
    Console.WriteLine("Press any key to exit...");
    Console.ReadLine();
    return;
}

var featureAmounts = new Dictionary<string, Amount?>();
(string CoffeeName,
 Dictionary<string, Amount?> FeatureAmounts,
 (int Amount, string Measure, bool IsHot) Water) selectedCoffeeConfiguration =
    (selectedCoffeeDetails.Name,
    featureAmounts,
    (selectedCoffeeDetails.Water.Amount, selectedCoffeeDetails.Water.Measure, selectedCoffeeDetails.Water.IsHot));

switch (selectedCoffeeDetails)
{
    case AmericanoDetails americano:
        Console.WriteLine($"You selected {americano.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Milk"] = SelectionHelpers.SelectMilkAmount(americano.Milk);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectionHelpers.SelectSugarAmount(americano.Sugar);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Caramel"] = SelectionHelpers.SelectCaramelOption(americano.Caramel);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Creamer"] = SelectionHelpers.SelectCreamerOption(americano.Creamer);
        break;
    case EspressoDetails espresso:
        Console.WriteLine($"You selected {espresso.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectionHelpers.SelectSugarAmount(espresso.Sugar);
        break;
    case CappuccinoDetails cappuccino:
        Console.WriteLine($"You selected {cappuccino.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Milk"] = SelectionHelpers.SelectMilkAmount(cappuccino.Milk);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectionHelpers.SelectSugarAmount(cappuccino.Sugar);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Caramel"] = SelectionHelpers.SelectCaramelOption(cappuccino.Caramel);
        break;
    case LatteDetails latte:
        Console.WriteLine($"You selected {latte.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Milk"] = SelectionHelpers.SelectMilkAmount(latte.Milk);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectionHelpers.SelectSugarAmount(latte.Sugar);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Creamer"] = SelectionHelpers.SelectCreamerOption(latte.Creamer);
        break;
    case MacchiatoDetails macchiato:
        Console.WriteLine($"You selected {macchiato.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Milk"] = SelectionHelpers.SelectMilkAmount(macchiato.Milk);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectionHelpers.SelectSugarAmount(macchiato.Sugar);
        break;
    default:
        Console.WriteLine($"You selected {selectedCoffeeDetails.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectionHelpers.SelectSugarAmount(selectedCoffeeDetails.Sugar);
        break;
}

// Display final selection summary
Console.WriteLine();
Console.WriteLine("=== Your Coffee Order ===");
Console.WriteLine($"Coffee: {selectedCoffeeConfiguration.CoffeeName}");
Console.WriteLine($"Water: {selectedCoffeeConfiguration.Water.Amount} {selectedCoffeeConfiguration.Water.Measure} ({(selectedCoffeeConfiguration.Water.IsHot ? "Hot" : "Cold")})");
foreach (var selection in selectedCoffeeConfiguration.FeatureAmounts)
{
    if (selection.Value != null)
    {
        Console.WriteLine($"{selection.Key}: {selection.Value.Quantity} {selection.Value.Measure}");
    }
    else
    {
        Console.WriteLine($"{selection.Key}: None");
    }
}

Console.WriteLine();