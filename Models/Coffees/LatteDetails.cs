using Models.Coffees.Base;
using Models.Features;

namespace Models.Coffees
{
    public class LatteDetails : CoffeeDetails
    {
        public LatteDetails()
        {
            Milk = new Milk();
            Creamer = new Creamer();
        }

        public Milk Milk { get; set; }
        public Creamer Creamer { get; set; }
    }
}
