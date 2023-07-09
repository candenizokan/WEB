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
            builder.HasKey(a=>a.ID);//ID sistemin belirttiği bir isim, söylemeseydikde aslında pk olduğunu bilirdi ama yinede söyledik.
            builder.Property(a => a.IsActive).IsRequired();//defaultta IsRequired true kabul edilir. kolonun null geçiliğ geçilmeyeceğine karar veririrz. true=> gerekli alan boş bırakılmaz. false => gerekli değil, boş geçilebilir kolon
            builder.Property(a => a.UpdateDate).IsRequired(false);//boş geçilebilir bir alan olmalı
            builder.Property(a => a.DeleteDate).IsRequired(false);
        }
    }
}
