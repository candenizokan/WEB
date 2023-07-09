using CoreCrud.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCrud.Models.Mappings.Abstract
{
    // kalıtım vereceğim için abstract yaptım. doğrudan doğruya kullanılmasın kalıtım versin
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        public void Configure(EntityTypeBuilder<T> builder)
        {
            throw new System.NotImplementedException();
        }
    }
}
