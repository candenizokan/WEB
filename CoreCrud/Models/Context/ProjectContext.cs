using CoreCrud.Models.Concrete;
using CoreCrud.Models.Mappings.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Models.Context
{
    public class ProjectContext:DbContext
    {
        public ProjectContext(DbContextOptions<ProjectContext> options):base(options)
        {

        }

        //ayağa kalkacak tablolarımı yazacağım
        public DbSet<Movie> Movies { get; set; }

        public DbSet<Director> Directors { get; set; }

        public DbSet<Actor> Actors { get; set; }

        public DbSet<MovieActor> MovieActors { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //konfigurasyonlarımıda söylüyorum
            modelBuilder.ApplyConfiguration(new DirectorMap());
            modelBuilder.ApplyConfiguration(new MovieActorMap());
            modelBuilder.ApplyConfiguration(new MovieMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
