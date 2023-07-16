using CoreCrud.Infrastructure.Abstarct;
using CoreCrud.Infrastructure.Interfaces.Concrete;
using CoreCrud.Models.Concrete;
using CoreCrud.Models.Context;

namespace CoreCrud.Infrastructure.Concrete
{
    public class MovieRepo : BaseRepo<Movie>,IMovieRepo
    {
        public MovieRepo(ProjectContext context) : base(context)
        {
        }
    }
}
