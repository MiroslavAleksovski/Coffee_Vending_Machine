using Dapper.FluentMap.Mapping;
using Models.Coffees;

namespace Repositories.Mappers.Coffees
{
    public class CappuccinoDetailsMap : EntityMap<CappuccinoDetails>
    {
        public CappuccinoDetailsMap()
        {
            Map(c => c.Id).ToColumn("Id");
            Map(c => c.Name).ToColumn("Name");
            Map(c => c.Description).ToColumn("Description");
        }
    }
}
