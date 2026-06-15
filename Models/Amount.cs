namespace Models
{
    public class Amount
    {
        public Amount()
        {
            Id = Guid.NewGuid();
            Quantity = 1;
            IsDefault = false;
            Measure = "pack";
        }

        public Guid Id { get; set; }
        public int Quantity { get; set; }
        public string Measure { get; set; }
        public bool IsDefault { get; set; }
    }
}
