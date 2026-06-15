using Models.Coffees.Base;
using Models.Features;

namespace Models.Coffees
{
    public class MacchiatoDetails : CoffeeDetails
    {
        public MacchiatoDetails()
        {
            Milk = new Milk();
        }

        public Milk Milk { get; set; }
    }
}
