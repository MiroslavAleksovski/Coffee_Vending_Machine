namespace Models.Features.Base
{
    public class Feature
    {
        public Feature() {

            Id = Guid.NewGuid();
            Name = string.Empty;
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
    }
}
