using CoreCrud.Infrastructure.Abstarct;
using CoreCrud.Models.Concrete;
using CoreCrud.Models.Context;

namespace CoreCrud.Infrastructure.Concrete
{
    public class MovieRepo : BaseRepo<Movie>
    {
        public MovieRepo(ProjectContext context) : base(context)
        {
        }
    }
}
