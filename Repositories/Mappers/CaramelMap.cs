using Dapper.FluentMap.Mapping;
using Models.Features;

namespace Repositories.Mappers
{
    public class CaramelMap : EntityMap<Caramel>
    {
        public CaramelMap()
        {
            Map(c => c.Id).ToColumn("Id");
            Map(c => c.Name).ToColumn("Name");
            Map(c => c.Description).ToColumn("Description");
            Map(c => c.UseCaramel).ToColumn("UseCaramel");
        }
    }
}
