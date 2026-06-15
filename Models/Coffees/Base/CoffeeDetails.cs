using Models.Features;

namespace Models.Coffees.Base
{
    public class CoffeeDetails
    {
        public CoffeeDetails()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;

            Water = new Water();
            Sugar = new Sugar();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }

        public Water Water { get; set; }

        public Sugar Sugar { get; set; }
    }
}
