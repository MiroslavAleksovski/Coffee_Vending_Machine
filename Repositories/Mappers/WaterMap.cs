using Dapper.FluentMap.Mapping;
using Models;

namespace Repositories.Mappers
{
    public class WaterMap : EntityMap<Water>
    {
        public WaterMap()
        {
            Map(w => w.Id).ToColumn("Id");
            Map(w => w.Amount).ToColumn("Amount");
            Map(w => w.Measure).ToColumn("Measure");
            Map(w => w.IsHot).ToColumn("IsHot");
        }
    }
}
