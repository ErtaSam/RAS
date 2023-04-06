using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.User.Entities;

namespace RAS.Infrastructure.Data.Config.Menu;

public class MenuEntityConfiguration : BaseEntityConfiguration<MenuEntity>
{
    protected override void ConfigureEntity(EntityTypeBuilder<MenuEntity> builder)
    {
        builder.ToTable("Menu");
         
        builder.Property(x => x.Type).IsRequired().HasColumnType("nvarchar(128)");
        builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(128)");
        builder.HasMany(x => x.MenuItems)
            .WithOne(x => x.Menu)
            .HasForeignKey(x => x.MenuId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
