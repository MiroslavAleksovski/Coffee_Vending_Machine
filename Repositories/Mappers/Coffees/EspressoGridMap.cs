using Dapper.FluentMap.Mapping;
using Models.Coffees;

namespace Repositories.Mappers.Coffees
{
    public class EspressoGridMap : EntityMap<EspressoGrid>
    {
        public EspressoGridMap()
        {
            Map(e => e.Id).ToColumn("Id");
            Map(e => e.Name).ToColumn("Name");
        }
    }
}
