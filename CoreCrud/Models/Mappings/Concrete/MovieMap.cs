using CoreCrud.Models.Concrete;
using CoreCrud.Models.Mappings.Abstract;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCrud.Models.Mappings.Concrete
{
    public class MovieMap:BaseMap<Movie>
    {
        public override void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.HasOne(a => a.Director).WithMany(a=>a.Movies).HasForeignKey(a=>a.DirectorId);
            base.Configure(builder);
        }
    }
}
