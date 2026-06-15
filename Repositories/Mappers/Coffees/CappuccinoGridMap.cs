using Dapper.FluentMap.Mapping;
using Models.Coffees;

namespace Repositories.Mappers.Coffees
{
    public class CappuccinoGridMap : EntityMap<CappuccinoGrid>
    {
        public CappuccinoGridMap()
        {
            Map(c => c.Id).ToColumn("Id");
            Map(c => c.Name).ToColumn("Name");
        }
    }
}
