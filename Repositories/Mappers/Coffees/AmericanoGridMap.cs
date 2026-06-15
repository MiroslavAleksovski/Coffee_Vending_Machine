using Dapper.FluentMap.Mapping;
using Models.Coffees;

namespace Repositories.Mappers.Coffees
{
    public class AmericanoGridMap : EntityMap<AmericanoGrid>
    {
        public AmericanoGridMap()
        {
            Map(a => a.Id).ToColumn("Id");
            Map(a => a.Name).ToColumn("Name");
        }
    }
}
