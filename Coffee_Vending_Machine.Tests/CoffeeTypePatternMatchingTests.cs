using Models.Coffees;
using Models.Coffees.Base;

namespace Coffee_Vending_Machine.Tests
{
    [TestFixture]
    public class CoffeeTypePatternMatchingTests
    {
        #region Grid Type Pattern Matching Tests

        [Test]
        public void PatternMatching_AmericanoGrid_MatchesCorrectly()
        {
            // Arrange
            CoffeeGrid grid = new AmericanoGrid { Id = Guid.NewGuid(), Name = "Americano" };

            // Act
            var result = grid switch
            {
                AmericanoGrid => "Americano",
                EspressoGrid => "Espresso",
                CappuccinoGrid => "Cappuccino",
                LatteGrid => "Latte",
                MacchiatoGrid => "Macchiato",
                _ => "Unknown"
            };

            // Assert
            Assert.That(result, Is.EqualTo("Americano"));
        }

        [Test]
        public void PatternMatching_EspressoGrid_MatchesCorrectly()
        {
            // Arrange
            CoffeeGrid grid = new EspressoGrid { Id = Guid.NewGuid(), Name = "Espresso" };

            // Act
            var result = grid switch
            {
                AmericanoGrid => "Americano",
                EspressoGrid => "Espresso",
                CappuccinoGrid => "Cappuccino",
                LatteGrid => "Latte",
                MacchiatoGrid => "Macchiato",
                _ => "Unknown"
            };

            // Assert
            Assert.That(result, Is.EqualTo("Espresso"));
        }

        [Test]
        public void PatternMatching_CappuccinoGrid_MatchesCorrectly()
        {
            // Arrange
            CoffeeGrid grid = new CappuccinoGrid { Id = Guid.NewGuid(), Name = "Cappuccino" };

            // Act
            var result = grid switch
            {
                AmericanoGrid => "Americano",
                EspressoGrid => "Espresso",
                CappuccinoGrid => "Cappuccino",
                LatteGrid => "Latte",
                MacchiatoGrid => "Macchiato",
                _ => "Unknown"
            };

            // Assert
            Assert.That(result, Is.EqualTo("Cappuccino"));
        }

        [Test]
        public void PatternMatching_LatteGrid_MatchesCorrectly()
        {
            // Arrange
            CoffeeGrid grid = new LatteGrid { Id = Guid.NewGuid(), Name = "Latte" };

            // Act
            var result = grid switch
            {
                AmericanoGrid => "Americano",
                EspressoGrid => "Espresso",
                CappuccinoGrid => "Cappuccino",
                LatteGrid => "Latte",
                MacchiatoGrid => "Macchiato",
                _ => "Unknown"
            };

            // Assert
            Assert.That(result, Is.EqualTo("Latte"));
        }

        [Test]
        public void PatternMatching_MacchiatoGrid_MatchesCorrectly()
        {
            // Arrange
            CoffeeGrid grid = new MacchiatoGrid { Id = Guid.NewGuid(), Name = "Macchiato" };

            // Act
            var result = grid switch
            {
                AmericanoGrid => "Americano",
                EspressoGrid => "Espresso",
                CappuccinoGrid => "Cappuccino",
                LatteGrid => "Latte",
                MacchiatoGrid => "Macchiato",
                _ => "Unknown"
            };

            // Assert
            Assert.That(result, Is.EqualTo("Macchiato"));
        }

        [Test]
        public void PatternMatching_BaseCoffeeGrid_MatchesDefault()
        {
            // Arrange
            CoffeeGrid grid = new CoffeeGrid { Id = Guid.NewGuid(), Name = "Generic Coffee" };

            // Act
            var result = grid switch
            {
                AmericanoGrid => "Americano",
                EspressoGrid => "Espresso",
                CappuccinoGrid => "Cappuccino",
                LatteGrid => "Latte",
                MacchiatoGrid => "Macchiato",
                _ => "Unknown"
            };

            // Assert
            Assert.That(result, Is.EqualTo("Unknown"));
        }

        #endregion

        #region Details Type Pattern Matching Tests

        [Test]
        public void PatternMatching_AmericanoDetails_MatchesCorrectly()
        {
            // Arrange
            CoffeeDetails details = new AmericanoDetails { Name = "Americano" };

            // Act
            var featureCount = details switch
            {
                AmericanoDetails => 4, // Milk, Sugar, Caramel, Creamer
                EspressoDetails => 1,   // Sugar only
                CappuccinoDetails => 3, // Milk, Sugar, Caramel
                LatteDetails => 3,      // Milk, Sugar, Creamer
                MacchiatoDetails => 2,  // Milk, Sugar
                _ => 1                  // Sugar only (base)
            };

            // Assert
            Assert.That(featureCount, Is.EqualTo(4));
        }

        [Test]
        public void PatternMatching_EspressoDetails_MatchesCorrectly()
        {
            // Arrange
            CoffeeDetails details = new EspressoDetails { Name = "Espresso" };

            // Act
            var featureCount = details switch
            {
                AmericanoDetails => 4,
                EspressoDetails => 1,
                CappuccinoDetails => 3,
                LatteDetails => 3,
                MacchiatoDetails => 2,
                _ => 1
            };

            // Assert
            Assert.That(featureCount, Is.EqualTo(1));
        }

        [Test]
        public void PatternMatching_CappuccinoDetails_MatchesCorrectly()
        {
            // Arrange
            CoffeeDetails details = new CappuccinoDetails { Name = "Cappuccino" };

            // Act
            var featureCount = details switch
            {
                AmericanoDetails => 4,
                EspressoDetails => 1,
                CappuccinoDetails => 3,
                LatteDetails => 3,
                MacchiatoDetails => 2,
                _ => 1
            };

            // Assert
            Assert.That(featureCount, Is.EqualTo(3));
        }

        [Test]
        public void PatternMatching_LatteDetails_MatchesCorrectly()
        {
            // Arrange
            CoffeeDetails details = new LatteDetails { Name = "Latte" };

            // Act
            var featureCount = details switch
            {
                AmericanoDetails => 4,
                EspressoDetails => 1,
                CappuccinoDetails => 3,
                LatteDetails => 3,
                MacchiatoDetails => 2,
                _ => 1
            };

            // Assert
            Assert.That(featureCount, Is.EqualTo(3));
        }

        [Test]
        public void PatternMatching_MacchiatoDetails_MatchesCorrectly()
        {
            // Arrange
            CoffeeDetails details = new MacchiatoDetails { Name = "Macchiato" };

            // Act
            var featureCount = details switch
            {
                AmericanoDetails => 4,
                EspressoDetails => 1,
                CappuccinoDetails => 3,
                LatteDetails => 3,
                MacchiatoDetails => 2,
                _ => 1
            };

            // Assert
            Assert.That(featureCount, Is.EqualTo(2));
        }

        [Test]
        public void PatternMatching_BaseCoffeeDetails_MatchesDefault()
        {
            // Arrange
            CoffeeDetails details = new CoffeeDetails { Name = "Generic Coffee" };

            // Act
            var featureCount = details switch
            {
                AmericanoDetails => 4,
                EspressoDetails => 1,
                CappuccinoDetails => 3,
                LatteDetails => 3,
                MacchiatoDetails => 2,
                _ => 1
            };

            // Assert
            Assert.That(featureCount, Is.EqualTo(1));
        }

        #endregion

        #region Coffee Selection Logic Tests

        [Test]
        public void CoffeeSelection_FirstOrDefault_FindsBySortOrder()
        {
            // Arrange
            var coffees = new List<CoffeeGrid>
            {
                new AmericanoGrid { Id = Guid.NewGuid(), Name = "Americano", SortOrder = 1 },
                new EspressoGrid { Id = Guid.NewGuid(), Name = "Espresso", SortOrder = 2 },
                new CappuccinoGrid { Id = Guid.NewGuid(), Name = "Cappuccino", SortOrder = 3 }
            };

            // Act
            var selectedCoffee = coffees.FirstOrDefault(c => c.SortOrder == 2);

            // Assert
            Assert.That(selectedCoffee, Is.Not.Null);
            Assert.That(selectedCoffee, Is.InstanceOf<EspressoGrid>());
            Assert.That(selectedCoffee!.Name, Is.EqualTo("Espresso"));
        }

        [Test]
        public void CoffeeSelection_FirstOrDefault_ReturnsNullForInvalidSortOrder()
        {
            // Arrange
            var coffees = new List<CoffeeGrid>
            {
                new AmericanoGrid { Id = Guid.NewGuid(), Name = "Americano", SortOrder = 1 },
                new EspressoGrid { Id = Guid.NewGuid(), Name = "Espresso", SortOrder = 2 }
            };

            // Act
            var selectedCoffee = coffees.FirstOrDefault(c => c.SortOrder == 99);

            // Assert
            Assert.That(selectedCoffee, Is.Null);
        }

        [Test]
        public void CoffeeSelection_Count_ReturnsCorrectTotal()
        {
            // Arrange
            var coffees = new List<CoffeeGrid>
            {
                new AmericanoGrid { SortOrder = 1 },
                new EspressoGrid { SortOrder = 2 },
                new CappuccinoGrid { SortOrder = 3 },
                new LatteGrid { SortOrder = 4 },
                new MacchiatoGrid { SortOrder = 5 }
            };

            // Act
            var count = coffees.Count();

            // Assert
            Assert.That(count, Is.EqualTo(5));
        }

        #endregion
    }
}
