using Dapper.FluentMap.Mapping;
using Models.Features;

namespace Repositories.Mappers
{
    public class CreamerMap : EntityMap<Creamer>
    {
        public CreamerMap()
        {
            Map(c => c.Id).ToColumn("Id");
            Map(c => c.Name).ToColumn("Name");
            Map(c => c.Description).ToColumn("Description");
            Map(c => c.UseCreamer).ToColumn("UseCreamer");
        }
    }
}
