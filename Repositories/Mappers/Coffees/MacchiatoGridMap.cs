using Dapper.FluentMap.Mapping;
using Models.Coffees;

namespace Repositories.Mappers.Coffees
{
    public class MacchiatoGridMap : EntityMap<MacchiatoGrid>
    {
        public MacchiatoGridMap()
        {
            Map(m => m.Id).ToColumn("Id");
            Map(m => m.Name).ToColumn("Name");
        }
    }
}
