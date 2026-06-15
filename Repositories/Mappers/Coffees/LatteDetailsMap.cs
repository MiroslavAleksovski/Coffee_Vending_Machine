using Dapper.FluentMap.Mapping;
using Models.Coffees;

namespace Repositories.Mappers.Coffees
{
    public class LatteDetailsMap : EntityMap<LatteDetails>
    {
        public LatteDetailsMap()
        {
            Map(l => l.Id).ToColumn("Id");
            Map(l => l.Name).ToColumn("Name");
            Map(l => l.Description).ToColumn("Description");
        }
    }
}
