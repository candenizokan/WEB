using CoreCrud.Models.Concrete;
using CoreCrud.Models.Mappings.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCrud.Models.Mappings.Concrete
{
    public class DirectorMap:BaseMap<Director>
    {
        public override void Configure(EntityTypeBuilder<Director> builder)
        {
            base.Configure(builder);
        }
    }
}
