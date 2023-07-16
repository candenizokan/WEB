using CoreCrud.Infrastructure.Abstarct;
using CoreCrud.Infrastructure.Interfaces.Concrete;
using CoreCrud.Models.Concrete;
using CoreCrud.Models.Context;

namespace CoreCrud.Infrastructure.Concrete
{
    public class DirectorRepo : BaseRepo<Director>, IDirector
    {
        public DirectorRepo(ProjectContext context) : base(context)
        {
        }
    }
}
