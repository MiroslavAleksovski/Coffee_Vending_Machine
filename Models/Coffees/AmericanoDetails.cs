using Models.Coffees.Base;
using Models.Features;

namespace Models.Coffees
{
    public class AmericanoDetails : CoffeeDetails
    {
        public AmericanoDetails()
        {
            Milk = new Milk();
            Caramel = new Caramel();
            Creamer = new Creamer();
        }

        public Milk Milk { get; set; }
        public Caramel Caramel { get; set; }
        public Creamer Creamer { get; set; }
    }
}
