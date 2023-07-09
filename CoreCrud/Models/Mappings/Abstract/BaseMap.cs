using CoreCrud.Models.Abstract;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CoreCrud.Models.Mappings.Abstract
{
    // kalıtım vereceğim için abstract yaptım. doğrudan doğruya kullanılmasın kalıtım versin
    //IEntityTypeConfiguration bu interface Mic.Efcore'dan gelir. Biz ayrıyetten bir paket indirmedik zaten Mic.Efcore.Sql içine gömülü geldiği için direkt olarak bu paketi indirdik.

    //Abstract işaretlediğimiz için BaseMap sınıfı içindeki CONFIGURE metodu VIRTUAL işaretlediğimizde bu metod aynen kullanılabilir yada kalıtım alan diğer sınıflar içeriğini istediği gibi kullanabilir.
    public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseEntity
    {
        //abstract olduğu için değiştirilmeden kesinkes kullanılıyor. ben bunu istersen bu şekilde kullan istersen içini değiştir şeklinde değiştirmem lazım. bunun için virtual yaptım isteyen kullansın isteyen değiştirip kullansın demiş oldum bu şekilde
        public virtual void Configure(EntityTypeBuilder<T> builder)
        {
            
        }
    }
}
