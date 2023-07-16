using CoreCrud.Models.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCrud.Models.Mappings.Concrete
{
    public class MovieActorMap : IEntityTypeConfiguration<MovieActor>
    {
        //ara tablo bu. ayrı ayrı map yapmaktansa MovieActorMap üzerinden konuşturabilirim. MovieActorMap Base MapTen kalıtım almadığından IEntityTypeConfiguration den implemente edecek. bir sınıf IEntityTypeConfiguration dan kalıtım aldığında sql tarafında nasıl ayağa kaldıracağımı konfigure ediyorum. MovieActorMap bu ara tablo normaldede basemap'ten kalıtım almıyor. 
        public void Configure(EntityTypeBuilder<MovieActor> builder)
        {
            builder.HasKey(a => new { a.ActorId, a.MovieId });//ikiside primary key
            builder.HasOne(a => a.Movie).WithMany(a=>a.MovieActors).HasForeignKey(a=>a.MovieId);
            builder.HasOne(a => a.Actor).WithMany(a=>a.MovieActors).HasForeignKey(a=>a.ActorId);
            throw new System.NotImplementedException();
        }
    }
}
