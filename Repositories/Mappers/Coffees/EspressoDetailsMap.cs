using Dapper.FluentMap.Mapping;
using Models.Coffees;

namespace Repositories.Mappers.Coffees
{
    public class EspressoDetailsMap : EntityMap<EspressoDetails>
    {
        public EspressoDetailsMap()
        {
            Map(e => e.Id).ToColumn("Id");
            Map(e => e.Name).ToColumn("Name");
            Map(e => e.Description).ToColumn("Description");
        }
    }
}
