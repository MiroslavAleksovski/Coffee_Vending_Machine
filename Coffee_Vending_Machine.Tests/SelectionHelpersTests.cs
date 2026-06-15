using Infrastructure;
using Models;
using Models.Features;

namespace Coffee_Vending_Machine.Tests
{
    [TestFixture]
    public class SelectionHelpersTests
    {
        #region SelectSugarAmount Tests

        [Test]
        public void SelectSugarAmount_WithNoAmounts_ReturnsNull()
        {
            // Arrange
            var sugar = new Sugar
            {
                Name = "White Sugar",
                Amounts = new List<Amount>()
            };

            var consoleInput = new StringReader("");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectSugarAmount(sugar);

            // Assert
            Assert.That(result, Is.Null);
            Assert.That(consoleOutput.ToString(), Does.Contain("No sugar amounts available"));
        }

        [Test]
        public void SelectSugarAmount_WithValidSelection_ReturnsSelectedAmount()
        {
            // Arrange
            var expectedAmount = new Amount { Id = Guid.NewGuid(), Quantity = 2, Measure = "pack", IsDefault = false };
            var sugar = new Sugar
            {
                Name = "White Sugar",
                Amounts = new List<Amount>
                {
                    new Amount { Id = Guid.NewGuid(), Quantity = 1, Measure = "pack", IsDefault = false },
                    expectedAmount,
                    new Amount { Id = Guid.NewGuid(), Quantity = 3, Measure = "pack", IsDefault = false }
                }
            };

            var consoleInput = new StringReader("2");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectSugarAmount(sugar);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Quantity, Is.EqualTo(2));
            Assert.That(result.Measure, Is.EqualTo("pack"));
        }

        [Test]
        public void SelectSugarAmount_WithEnterAndDefault_ReturnsDefaultAmount()
        {
            // Arrange
            var defaultAmount = new Amount { Id = Guid.NewGuid(), Quantity = 2, Measure = "pack", IsDefault = true };
            var sugar = new Sugar
            {
                Name = "White Sugar",
                Amounts = new List<Amount>
                {
                    new Amount { Id = Guid.NewGuid(), Quantity = 1, Measure = "pack", IsDefault = false },
                    defaultAmount,
                    new Amount { Id = Guid.NewGuid(), Quantity = 3, Measure = "pack", IsDefault = false }
                }
            };

            var consoleInput = new StringReader("");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectSugarAmount(sugar);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.IsDefault, Is.True);
            Assert.That(result.Quantity, Is.EqualTo(2));
            Assert.That(consoleOutput.ToString(), Does.Contain("(default)"));
        }

        [Test]
        public void SelectSugarAmount_WithFirstOption_ReturnsFirstAmount()
        {
            // Arrange
            var firstAmount = new Amount { Id = Guid.NewGuid(), Quantity = 1, Measure = "pack", IsDefault = false };
            var sugar = new Sugar
            {
                Name = "White Sugar",
                Amounts = new List<Amount>
                {
                    firstAmount,
                    new Amount { Id = Guid.NewGuid(), Quantity = 2, Measure = "pack", IsDefault = true }
                }
            };

            var consoleInput = new StringReader("1");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectSugarAmount(sugar);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Quantity, Is.EqualTo(1));
        }

        #endregion

        #region SelectMilkAmount Tests

        [Test]
        public void SelectMilkAmount_WithNoAmounts_ReturnsNull()
        {
            // Arrange
            var milk = new Milk
            {
                Name = "Whole Milk",
                Amounts = new List<Amount>()
            };

            var consoleInput = new StringReader("");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectMilkAmount(milk);

            // Assert
            Assert.That(result, Is.Null);
            Assert.That(consoleOutput.ToString(), Does.Contain("No milk amounts available"));
        }

        [Test]
        public void SelectMilkAmount_WithValidSelection_ReturnsSelectedAmount()
        {
            // Arrange
            var expectedAmount = new Amount { Id = Guid.NewGuid(), Quantity = 100, Measure = "ml", IsDefault = false };
            var milk = new Milk
            {
                Name = "Whole Milk",
                Amounts = new List<Amount>
                {
                    new Amount { Id = Guid.NewGuid(), Quantity = 50, Measure = "ml", IsDefault = false },
                    expectedAmount,
                    new Amount { Id = Guid.NewGuid(), Quantity = 150, Measure = "ml", IsDefault = false }
                }
            };

            var consoleInput = new StringReader("2");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectMilkAmount(milk);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Quantity, Is.EqualTo(100));
            Assert.That(result.Measure, Is.EqualTo("ml"));
        }

        [Test]
        public void SelectMilkAmount_WithEnterAndDefault_ReturnsDefaultAmount()
        {
            // Arrange
            var defaultAmount = new Amount { Id = Guid.NewGuid(), Quantity = 100, Measure = "ml", IsDefault = true };
            var milk = new Milk
            {
                Name = "Whole Milk",
                Amounts = new List<Amount>
                {
                    new Amount { Id = Guid.NewGuid(), Quantity = 50, Measure = "ml", IsDefault = false },
                    defaultAmount
                }
            };

            var consoleInput = new StringReader("");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectMilkAmount(milk);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.IsDefault, Is.True);
            Assert.That(result.Quantity, Is.EqualTo(100));
        }

        #endregion

        #region SelectCaramelOption Tests

        [Test]
        public void SelectCaramelOption_WithYesSelection_ReturnsAmount()
        {
            // Arrange
            var caramel = new Caramel
            {
                Name = "Caramel Syrup",
                UseCaramel = false
            };

            var consoleInput = new StringReader("1");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectCaramelOption(caramel);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Quantity, Is.EqualTo(1));
            Assert.That(result.Measure, Is.EqualTo("pump"));
            Assert.That(consoleOutput.ToString(), Does.Contain("Caramel added"));
        }

        [Test]
        public void SelectCaramelOption_WithNoSelection_ReturnsNull()
        {
            // Arrange
            var caramel = new Caramel
            {
                Name = "Caramel Syrup",
                UseCaramel = true
            };

            var consoleInput = new StringReader("2");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectCaramelOption(caramel);

            // Assert
            Assert.That(result, Is.Null);
            Assert.That(consoleOutput.ToString(), Does.Contain("No caramel"));
        }

        [Test]
        public void SelectCaramelOption_WithEnterAndUseCaramelTrue_ReturnsAmount()
        {
            // Arrange
            var caramel = new Caramel
            {
                Name = "Caramel Syrup",
                UseCaramel = true
            };

            var consoleInput = new StringReader("");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectCaramelOption(caramel);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Quantity, Is.EqualTo(1));
            Assert.That(result.Measure, Is.EqualTo("pump"));
            Assert.That(consoleOutput.ToString(), Does.Contain("(default)"));
        }

        [Test]
        public void SelectCaramelOption_WithEnterAndUseCaramelFalse_ReturnsNull()
        {
            // Arrange
            var caramel = new Caramel
            {
                Name = "Caramel Syrup",
                UseCaramel = false
            };

            var consoleInput = new StringReader("");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectCaramelOption(caramel);

            // Assert
            Assert.That(result, Is.Null);
            Assert.That(consoleOutput.ToString(), Does.Contain("(default)"));
        }

        #endregion

        #region SelectCreamerOption Tests

        [Test]
        public void SelectCreamerOption_WithYesSelection_ReturnsAmount()
        {
            // Arrange
            var creamer = new Creamer
            {
                Name = "Vanilla Creamer",
                UseCreamer = false
            };

            var consoleInput = new StringReader("1");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectCreamerOption(creamer);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Quantity, Is.EqualTo(1));
            Assert.That(result.Measure, Is.EqualTo("splash"));
            Assert.That(consoleOutput.ToString(), Does.Contain("Creamer added"));
        }

        [Test]
        public void SelectCreamerOption_WithNoSelection_ReturnsNull()
        {
            // Arrange
            var creamer = new Creamer
            {
                Name = "Vanilla Creamer",
                UseCreamer = true
            };

            var consoleInput = new StringReader("2");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectCreamerOption(creamer);

            // Assert
            Assert.That(result, Is.Null);
            Assert.That(consoleOutput.ToString(), Does.Contain("No creamer"));
        }

        [Test]
        public void SelectCreamerOption_WithEnterAndUseCreamerTrue_ReturnsAmount()
        {
            // Arrange
            var creamer = new Creamer
            {
                Name = "Vanilla Creamer",
                UseCreamer = true
            };

            var consoleInput = new StringReader("");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectCreamerOption(creamer);

            // Assert
            Assert.That(result, Is.Not.Null);
            Assert.That(result!.Quantity, Is.EqualTo(1));
            Assert.That(result.Measure, Is.EqualTo("splash"));
            Assert.That(consoleOutput.ToString(), Does.Contain("(default)"));
        }

        [Test]
        public void SelectCreamerOption_WithEnterAndUseCreamerFalse_ReturnsNull()
        {
            // Arrange
            var creamer = new Creamer
            {
                Name = "Vanilla Creamer",
                UseCreamer = false
            };

            var consoleInput = new StringReader("");
            var consoleOutput = new StringWriter();
            Console.SetIn(consoleInput);
            Console.SetOut(consoleOutput);

            // Act
            var result = SelectionHelpers.SelectCreamerOption(creamer);

            // Assert
            Assert.That(result, Is.Null);
            Assert.That(consoleOutput.ToString(), Does.Contain("(default)"));
        }

        #endregion

        [TearDown]
        public void TearDown()
        {
            // Reset console streams
            Console.SetIn(new StreamReader(Console.OpenStandardInput()));
            Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = true });
        }
    }
}
