namespace Models
{
    public class Water
    {
        public Guid Id { get; set; } = Guid.Empty;
        public int Amount { get; set; } = 10;
        public string Measure { get; set; } = "ml";
        public bool IsHot { get; set; } = true;
    }
}
