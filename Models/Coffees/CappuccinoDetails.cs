using Models.Coffees.Base;
using Models.Features;

namespace Models.Coffees
{
    public class CappuccinoDetails : CoffeeDetails
    {
        public CappuccinoDetails()
        {
            Milk = new Milk();
            Caramel = new Caramel();
        }

        public Milk Milk { get; set; }
        public Caramel Caramel { get; set; }
    }
}
