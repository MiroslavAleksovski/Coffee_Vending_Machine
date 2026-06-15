namespace Models.Coffees.Base
{
    public class CoffeeGrid
    {
        public CoffeeGrid()
        {
            Id = Guid.NewGuid();
            Name = string.Empty;
            SortOrder = 1;
        }

        public Guid Id { get; set; }
        public int SortOrder { get; set; }
        public string Name { get; set; }
    }
}
