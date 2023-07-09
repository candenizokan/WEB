using CoreCrud.Models.Abstract;
using Microsoft.EntityFrameworkCore;

namespace CoreCrud.Models.Mappings.Abstract
{
    public class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
    }
}
