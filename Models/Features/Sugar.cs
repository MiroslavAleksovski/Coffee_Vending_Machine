using Models.Features.Base;

namespace Models.Features
{
    public class Sugar : Feature
    {
        public Sugar()
        {
            Amounts = new List<Amount>();
        }

        public List<Amount> Amounts { get; set; }
    }
}
