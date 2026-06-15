using Models;
using Models.Coffees;
using Models.Coffees.Base;
using Models.Features;

namespace Coffee_Vending_Machine.Tests
{
    [TestFixture]
    public class CoffeeConfigurationTests
    {
        #region CoffeeGrid Tests

        [Test]
        public void CoffeeGrid_DefaultValues_AreSetCorrectly()
        {
            // Arrange & Act
            var coffeeGrid = new CoffeeGrid();

            // Assert
            Assert.That(coffeeGrid.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(coffeeGrid.Name, Is.EqualTo(string.Empty));
        }

        [Test]
        public void AmericanoGrid_InheritsFromCoffeeGrid()
        {
            // Arrange & Act
            var americanoGrid = new AmericanoGrid();

            // Assert
            Assert.That(americanoGrid, Is.InstanceOf<CoffeeGrid>());
        }

        [Test]
        public void EspressoGrid_InheritsFromCoffeeGrid()
        {
            // Arrange & Act
            var espressoGrid = new EspressoGrid();

            // Assert
            Assert.That(espressoGrid, Is.InstanceOf<CoffeeGrid>());
        }

        [Test]
        public void CappuccinoGrid_InheritsFromCoffeeGrid()
        {
            // Arrange & Act
            var cappuccinoGrid = new CappuccinoGrid();

            // Assert
            Assert.That(cappuccinoGrid, Is.InstanceOf<CoffeeGrid>());
        }

        [Test]
        public void LatteGrid_InheritsFromCoffeeGrid()
        {
            // Arrange & Act
            var latteGrid = new LatteGrid();

            // Assert
            Assert.That(latteGrid, Is.InstanceOf<CoffeeGrid>());
        }

        [Test]
        public void MacchiatoGrid_InheritsFromCoffeeGrid()
        {
            // Arrange & Act
            var macchiatoGrid = new MacchiatoGrid();

            // Assert
            Assert.That(macchiatoGrid, Is.InstanceOf<CoffeeGrid>());
        }

        #endregion

        #region CoffeeDetails Tests

        [Test]
        public void CoffeeDetails_DefaultValues_AreSetCorrectly()
        {
            // Arrange & Act
            var coffeeDetails = new CoffeeDetails();

            // Assert
            Assert.That(coffeeDetails.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(coffeeDetails.Name, Is.EqualTo(string.Empty));
            Assert.That(coffeeDetails.Water, Is.Not.Null);
            Assert.That(coffeeDetails.Sugar, Is.Not.Null);
        }

        [Test]
        public void AmericanoDetails_HasAllExpectedFeatures()
        {
            // Arrange & Act
            var americano = new AmericanoDetails();

            // Assert
            Assert.That(americano, Is.InstanceOf<CoffeeDetails>());
            Assert.That(americano.Milk, Is.Not.Null);
            Assert.That(americano.Caramel, Is.Not.Null);
            Assert.That(americano.Creamer, Is.Not.Null);
            Assert.That(americano.Sugar, Is.Not.Null);
            Assert.That(americano.Water, Is.Not.Null);
        }

        [Test]
        public void EspressoDetails_HasOnlyBaseFeatures()
        {
            // Arrange & Act
            var espresso = new EspressoDetails();

            // Assert
            Assert.That(espresso, Is.InstanceOf<CoffeeDetails>());
            Assert.That(espresso.Sugar, Is.Not.Null);
            Assert.That(espresso.Water, Is.Not.Null);
        }

        [Test]
        public void CappuccinoDetails_HasExpectedFeatures()
        {
            // Arrange & Act
            var cappuccino = new CappuccinoDetails();

            // Assert
            Assert.That(cappuccino, Is.InstanceOf<CoffeeDetails>());
            Assert.That(cappuccino.Milk, Is.Not.Null);
            Assert.That(cappuccino.Caramel, Is.Not.Null);
            Assert.That(cappuccino.Sugar, Is.Not.Null);
            Assert.That(cappuccino.Water, Is.Not.Null);
        }

        [Test]
        public void LatteDetails_HasExpectedFeatures()
        {
            // Arrange & Act
            var latte = new LatteDetails();

            // Assert
            Assert.That(latte, Is.InstanceOf<CoffeeDetails>());
            Assert.That(latte.Milk, Is.Not.Null);
            Assert.That(latte.Creamer, Is.Not.Null);
            Assert.That(latte.Sugar, Is.Not.Null);
            Assert.That(latte.Water, Is.Not.Null);
        }

        [Test]
        public void MacchiatoDetails_HasExpectedFeatures()
        {
            // Arrange & Act
            var macchiato = new MacchiatoDetails();

            // Assert
            Assert.That(macchiato, Is.InstanceOf<CoffeeDetails>());
            Assert.That(macchiato.Milk, Is.Not.Null);
            Assert.That(macchiato.Sugar, Is.Not.Null);
            Assert.That(macchiato.Water, Is.Not.Null);
        }

        #endregion

        #region SelectedCoffeeConfiguration Tests

        [Test]
        public void SelectedCoffeeConfiguration_CanBeCreatedWithAllProperties()
        {
            // Arrange
            var coffeeName = "Americano";
            var featureAmounts = new Dictionary<string, Amount?>
            {
                { "Milk", new Amount { Quantity = 100, Measure = "ml" } },
                { "Sugar", new Amount { Quantity = 2, Measure = "pack" } },
                { "Caramel", null },
                { "Creamer", new Amount { Quantity = 1, Measure = "splash" } }
            };
            var water = (Amount: 200, Measure: "ml", IsHot: true);

            // Act
            (string CoffeeName, Dictionary<string, Amount?> FeatureAmounts, (int Amount, string Measure, bool IsHot) Water) config =
                (coffeeName, featureAmounts, water);

            // Assert
            Assert.That(config.CoffeeName, Is.EqualTo("Americano"));
            Assert.That(config.FeatureAmounts.Count, Is.EqualTo(4));
            Assert.That(config.FeatureAmounts["Milk"]!.Quantity, Is.EqualTo(100));
            Assert.That(config.FeatureAmounts["Caramel"], Is.Null);
            Assert.That(config.Water.Amount, Is.EqualTo(200));
            Assert.That(config.Water.IsHot, Is.True);
        }

        [Test]
        public void SelectedCoffeeConfiguration_FeatureAmounts_CanBeModified()
        {
            // Arrange
            var featureAmounts = new Dictionary<string, Amount?>();
            (string CoffeeName, Dictionary<string, Amount?> FeatureAmounts, (int Amount, string Measure, bool IsHot) Water) config =
                ("Espresso", featureAmounts, (150, "ml", true));

            // Act
            config.FeatureAmounts["Sugar"] = new Amount { Quantity = 1, Measure = "pack" };

            // Assert
            Assert.That(config.FeatureAmounts.ContainsKey("Sugar"), Is.True);
            Assert.That(config.FeatureAmounts["Sugar"]!.Quantity, Is.EqualTo(1));
        }

        #endregion

        #region Water Configuration Tests

        [Test]
        public void Water_DefaultValues_AreSetCorrectly()
        {
            // Arrange & Act
            var water = new Water();

            // Assert
            Assert.That(water.Amount, Is.EqualTo(10));
            Assert.That(water.Measure, Is.EqualTo("ml"));
            Assert.That(water.IsHot, Is.True);
        }

        [Test]
        public void Water_CanBeConfiguredWithCustomValues()
        {
            // Arrange & Act
            var water = new Water
            {
                Amount = 200,
                Measure = "ml",
                IsHot = false
            };

            // Assert
            Assert.That(water.Amount, Is.EqualTo(200));
            Assert.That(water.Measure, Is.EqualTo("ml"));
            Assert.That(water.IsHot, Is.False);
        }

        #endregion

        #region Amount Tests

        [Test]
        public void Amount_DefaultValues_AreSetCorrectly()
        {
            // Arrange & Act
            var amount = new Amount();

            // Assert
            Assert.That(amount.Id, Is.Not.EqualTo(Guid.Empty));
            Assert.That(amount.Quantity, Is.EqualTo(1));
            Assert.That(amount.Measure, Is.EqualTo("pack"));
            Assert.That(amount.IsDefault, Is.False);
        }

        [Test]
        public void Amount_CanBeConfiguredWithCustomValues()
        {
            // Arrange & Act
            var amount = new Amount
            {
                Id = Guid.NewGuid(),
                Quantity = 5,
                Measure = "ml",
                IsDefault = true
            };

            // Assert
            Assert.That(amount.Quantity, Is.EqualTo(5));
            Assert.That(amount.Measure, Is.EqualTo("ml"));
            Assert.That(amount.IsDefault, Is.True);
        }

        #endregion
    }
}
