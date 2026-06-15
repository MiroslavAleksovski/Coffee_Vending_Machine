using Dapper.FluentMap.Mapping;
using Models.Features;

namespace Repositories.Mappers
{
    public class SugarMap : EntityMap<Sugar>
    {
        public SugarMap()
        {
            Map(s => s.Id).ToColumn("Id");
            Map(s => s.Name).ToColumn("Name");
            Map(s => s.Description).ToColumn("Description");
        }
    }
}
