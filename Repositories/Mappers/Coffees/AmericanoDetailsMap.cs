using Dapper.FluentMap.Mapping;
using Models.Coffees;

namespace Repositories.Mappers.Coffees
{
    public class AmericanoDetailsMap : EntityMap<AmericanoDetails>
    {
        public AmericanoDetailsMap()
        {
            Map(a => a.Id).ToColumn("Id");
            Map(a => a.Name).ToColumn("Name");
            Map(a => a.Description).ToColumn("Description");
        }
    }
}
