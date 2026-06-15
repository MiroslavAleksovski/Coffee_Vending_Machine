using Models.Features.Base;

namespace Models.Features
{
    public class Milk : Feature
    {
        public Milk()
        {
            Amounts = new List<Amount>();
        }

        public List<Amount> Amounts { get; set; }
    }
}