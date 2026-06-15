using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Models;
using Models.Coffees;
using Models.Coffees.Base;
using Models.Features;
using Repositories.Configuration;
using Repositories.Implementations;
using Repositories.Interfaces;
using Services.Implementations;
using Services.Interfaces;

#region Helper methods
Amount? SelectSugarAmount(Sugar sugar)
{
    Console.WriteLine($"Sugar: {sugar.Name}");
    if (sugar.Amounts.Count > 0)
    {
        var defaultAmount = sugar.Amounts.FirstOrDefault(a => a.IsDefault);

        Console.WriteLine("Available sugar amounts:");
        for (int i = 0; i < sugar.Amounts.Count; i++)
        {
            var amount = sugar.Amounts[i];
            var defaultIndicator = amount.IsDefault ? " (default)" : "";
            Console.WriteLine($"  {i + 1}: {amount.Quantity} {amount.Measure}{defaultIndicator}");
        }

        Console.WriteLine();
        Console.WriteLine("Please select your sugar amount (press Enter for default):");
        var selectedSugarAmountInput = Console.ReadLine();
        int selectedSugarAmountIndex = -1;

        // If user presses Enter and default exists, use default
        if (string.IsNullOrEmpty(selectedSugarAmountInput) && defaultAmount != null)
        {
            Console.WriteLine($"You selected: {defaultAmount.Quantity} {defaultAmount.Measure} of sugar (default)");
            return defaultAmount;
        }

        while (!int.TryParse(selectedSugarAmountInput, out selectedSugarAmountIndex)
            || selectedSugarAmountIndex < 1
            || selectedSugarAmountIndex > sugar.Amounts.Count)
        {
            Console.WriteLine($"{selectedSugarAmountInput} is not valid. Please enter a number between 1 and {sugar.Amounts.Count}:");
            selectedSugarAmountInput = Console.ReadLine();

            // Check again for Enter + default
            if (string.IsNullOrEmpty(selectedSugarAmountInput) && defaultAmount != null)
            {
                Console.WriteLine($"You selected: {defaultAmount.Quantity} {defaultAmount.Measure} of sugar (default)");
                return defaultAmount;
            }
        }

        var selectedSugarAmount = sugar.Amounts[selectedSugarAmountIndex - 1];
        Console.WriteLine($"You selected: {selectedSugarAmount.Quantity} {selectedSugarAmount.Measure} of sugar");
        return selectedSugarAmount;
    }
    else
    {
        Console.WriteLine("No sugar amounts available.");
        return null;
    }
}

Amount? SelectMilkAmount(Milk milk)
{
    Console.WriteLine($"Milk: {milk.Name}");
    if (milk.Amounts.Count > 0)
    {
        var defaultAmount = milk.Amounts.FirstOrDefault(a => a.IsDefault);

        Console.WriteLine("Available milk amounts:");
        for (int i = 0; i < milk.Amounts.Count; i++)
        {
            var amount = milk.Amounts[i];
            var defaultIndicator = amount.IsDefault ? " (default)" : "";
            Console.WriteLine($"  {i + 1}: {amount.Quantity} {amount.Measure}{defaultIndicator}");
        }

        Console.WriteLine();
        Console.WriteLine("Please select your milk amount (press Enter for default):");
        var selectedMilkAmountInput = Console.ReadLine();
        int selectedMilkAmountIndex = -1;

        // If user presses Enter and default exists, use default
        if (string.IsNullOrEmpty(selectedMilkAmountInput) && defaultAmount != null)
        {
            Console.WriteLine($"You selected: {defaultAmount.Quantity} {defaultAmount.Measure} of milk (default)");
            return defaultAmount;
        }

        while (!int.TryParse(selectedMilkAmountInput, out selectedMilkAmountIndex)
            || selectedMilkAmountIndex < 1
            || selectedMilkAmountIndex > milk.Amounts.Count)
        {
            Console.WriteLine($"{selectedMilkAmountInput} is not valid. Please enter a number between 1 and {milk.Amounts.Count}:");
            selectedMilkAmountInput = Console.ReadLine();

            // Check again for Enter + default
            if (string.IsNullOrEmpty(selectedMilkAmountInput) && defaultAmount != null)
            {
                Console.WriteLine($"You selected: {defaultAmount.Quantity} {defaultAmount.Measure} of milk (default)");
                return defaultAmount;
            }
        }

        var selectedMilkAmount = milk.Amounts[selectedMilkAmountIndex - 1];
        Console.WriteLine($"You selected: {selectedMilkAmount.Quantity} {selectedMilkAmount.Measure} of milk");
        return selectedMilkAmount;
    }
    else
    {
        Console.WriteLine("No milk amounts available.");
        return null;
    }
}

Amount? SelectCaramelOption(Caramel caramel)
{
    Console.WriteLine($"Caramel: {caramel.Name}");
    Console.WriteLine("Would you like caramel?");
    Console.WriteLine($"  1: Yes{(caramel.UseCaramel ? " (default)" : "")}");
    Console.WriteLine($"  2: No{(!caramel.UseCaramel ? " (default)" : "")}");

    Console.WriteLine();
    Console.WriteLine("Please select your caramel option (press Enter for default):");
    var selectedCaramelInput = Console.ReadLine();
    int selectedCaramelOption = -1;

    // If user presses Enter, use default
    if (string.IsNullOrEmpty(selectedCaramelInput))
    {
        if (caramel.UseCaramel)
        {
            Console.WriteLine("You selected: Caramel added (default)");
            return new Amount
            {
                Id = Guid.NewGuid(),
                Quantity = 1,
                IsDefault = true,
                Measure = "pump"
            };
        }
        else
        {
            Console.WriteLine("You selected: No caramel (default)");
            return null;
        }
    }

    while (!int.TryParse(selectedCaramelInput, out selectedCaramelOption)
        || selectedCaramelOption < 1
        || selectedCaramelOption > 2)
    {
        Console.WriteLine($"{selectedCaramelInput} is not valid. Please enter 1 for Yes or 2 for No:");
        selectedCaramelInput = Console.ReadLine();

        // Check again for Enter
        if (string.IsNullOrEmpty(selectedCaramelInput))
        {
            if (caramel.UseCaramel)
            {
                Console.WriteLine("You selected: Caramel added (default)");
                return new Amount
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    IsDefault = true,
                    Measure = "pump"
                };
            }
            else
            {
                Console.WriteLine("You selected: No caramel (default)");
                return null;
            }
        }
    }

    if (selectedCaramelOption == 1)
    {
        Console.WriteLine("You selected: Caramel added");
        return new Amount
        {
            Id = Guid.NewGuid(),
            Quantity = 1,
            IsDefault = true,
            Measure = "pump"
        };
    }
    else
    {
        Console.WriteLine("You selected: No caramel");
        return null;
    }
}

Amount? SelectCreamerOption(Creamer creamer)
{
    Console.WriteLine($"Creamer: {creamer.Name}");
    Console.WriteLine("Would you like creamer?");
    Console.WriteLine($"  1: Yes{(creamer.UseCreamer ? " (default)" : "")}");
    Console.WriteLine($"  2: No{(!creamer.UseCreamer ? " (default)" : "")}");

    Console.WriteLine();
    Console.WriteLine("Please select your creamer option (press Enter for default):");
    var selectedCreamerInput = Console.ReadLine();
    int selectedCreamerOption = -1;

    // If user presses Enter, use default
    if (string.IsNullOrEmpty(selectedCreamerInput))
    {
        if (creamer.UseCreamer)
        {
            Console.WriteLine("You selected: Creamer added (default)");
            return new Amount
            {
                Id = Guid.NewGuid(),
                Quantity = 1,
                IsDefault = true,
                Measure = "splash"
            };
        }
        else
        {
            Console.WriteLine("You selected: No creamer (default)");
            return null;
        }
    }

    while (!int.TryParse(selectedCreamerInput, out selectedCreamerOption)
        || selectedCreamerOption < 1
        || selectedCreamerOption > 2)
    {
        Console.WriteLine($"{selectedCreamerInput} is not valid. Please enter 1 for Yes or 2 for No:");
        selectedCreamerInput = Console.ReadLine();

        // Check again for Enter
        if (string.IsNullOrEmpty(selectedCreamerInput))
        {
            if (creamer.UseCreamer)
            {
                Console.WriteLine("You selected: Creamer added (default)");
                return new Amount
                {
                    Id = Guid.NewGuid(),
                    Quantity = 1,
                    IsDefault = true,
                    Measure = "splash"
                };
            }
            else
            {
                Console.WriteLine("You selected: No creamer (default)");
                return null;
            }
        }
    }

    if (selectedCreamerOption == 1)
    {
        Console.WriteLine("You selected: Creamer added");
        return new Amount
        {
            Id = Guid.NewGuid(),
            Quantity = 1,
            IsDefault = true,
            Measure = "splash"
        };
    }
    else
    {
        Console.WriteLine("You selected: No creamer");
        return null;
    }
}
#endregion

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
        selectedCoffeeConfiguration.FeatureAmounts["Milk"] = SelectMilkAmount(americano.Milk);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectSugarAmount(americano.Sugar);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Caramel"] = SelectCaramelOption(americano.Caramel);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Creamer"] = SelectCreamerOption(americano.Creamer);
        break;
    case EspressoDetails espresso:
        Console.WriteLine($"You selected {espresso.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectSugarAmount(espresso.Sugar);
        break;
    case CappuccinoDetails cappuccino:
        Console.WriteLine($"You selected {cappuccino.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Milk"] = SelectMilkAmount(cappuccino.Milk);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectSugarAmount(cappuccino.Sugar);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Caramel"] = SelectCaramelOption(cappuccino.Caramel);
        break;
    case LatteDetails latte:
        Console.WriteLine($"You selected {latte.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Milk"] = SelectMilkAmount(latte.Milk);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectSugarAmount(latte.Sugar);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Creamer"] = SelectCreamerOption(latte.Creamer);
        break;
    case MacchiatoDetails macchiato:
        Console.WriteLine($"You selected {macchiato.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Milk"] = SelectMilkAmount(macchiato.Milk);
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectSugarAmount(macchiato.Sugar);
        break;
    default:
        Console.WriteLine($"You selected {selectedCoffeeDetails.Name}.");
        Console.WriteLine();
        selectedCoffeeConfiguration.FeatureAmounts["Sugar"] = SelectSugarAmount(selectedCoffeeDetails.Sugar);
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