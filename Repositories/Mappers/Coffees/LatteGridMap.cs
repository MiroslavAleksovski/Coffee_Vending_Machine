using Dapper.FluentMap.Mapping;
using Models.Coffees;

namespace Repositories.Mappers.Coffees
{
    public class LatteGridMap : EntityMap<LatteGrid>
    {
        public LatteGridMap()
        {
            Map(l => l.Id).ToColumn("Id");
            Map(l => l.Name).ToColumn("Name");
        }
    }
}
