using Dapper.FluentMap;
using Repositories.Mappers;
using Repositories.Mappers.Coffees;

namespace Repositories.Configuration
{
    public static class FluentMapperConfiguration
    {
        public static void Initialize()
        {
            FluentMapper.Initialize(config =>
            {
                // Details mappers
                config.AddMap(new AmericanoDetailsMap());
                config.AddMap(new EspressoDetailsMap());
                config.AddMap(new CappuccinoDetailsMap());
                config.AddMap(new LatteDetailsMap());
                config.AddMap(new MacchiatoDetailsMap());

                // Grid mappers
                config.AddMap(new AmericanoGridMap());
                config.AddMap(new EspressoGridMap());
                config.AddMap(new CappuccinoGridMap());
                config.AddMap(new LatteGridMap());
                config.AddMap(new MacchiatoGridMap());

                // Feature mappers
                config.AddMap(new SugarMap());
                config.AddMap(new MilkMap());
                config.AddMap(new WaterMap());
                config.AddMap(new CaramelMap());
                config.AddMap(new CreamerMap());
            });

        }
    }
}
