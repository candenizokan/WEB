using CoreCrud.Models.Concrete;
using CoreCrud.Models.Mappings.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCrud.Models.Mappings.Concrete
{
    public class DirectorMap:BaseMap<Director>
    {
        public override void Configure(EntityTypeBuilder<Director> builder)
        {

            //builder.Property(a=>a.FirstName).IsRequired().HasMaxLength(30).HasColumnName("AD");
            builder.Property(a => a.FirstName).IsRequired();
            builder.Property(a => a.LastName).IsRequired();
            builder.Property(a => a.BirthDate).IsRequired(true);

            base.Configure(builder);
        }
    }
}
