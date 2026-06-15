using Models;
using Models.Features;

namespace Infrastructure
{
    public static class SelectionHelpers
    {
        public static Amount? SelectSugarAmount(Sugar sugar)
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

        public static Amount? SelectMilkAmount(Milk milk)
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

        public static Amount? SelectCaramelOption(Caramel caramel)
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

        public static Amount? SelectCreamerOption(Creamer creamer)
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
    }
}
