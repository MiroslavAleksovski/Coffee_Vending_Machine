using Dapper.FluentMap.Mapping;
using Models.Features;

namespace Repositories.Mappers
{
    public class MilkMap : EntityMap<Milk>
    {
        public MilkMap()
        {
            Map(m => m.Id).ToColumn("Id");
            Map(m => m.Name).ToColumn("Name");
            Map(m => m.Description).ToColumn("Description");
        }
    }
}
