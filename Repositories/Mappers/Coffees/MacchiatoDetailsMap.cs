using Dapper.FluentMap.Mapping;
using Models.Coffees;

namespace Repositories.Mappers.Coffees
{
    public class MacchiatoDetailsMap : EntityMap<MacchiatoDetails>
    {
        public MacchiatoDetailsMap()
        {
            Map(m => m.Id).ToColumn("Id");
            Map(m => m.Name).ToColumn("Name");
            Map(m => m.Description).ToColumn("Description");
        }
    }
}
