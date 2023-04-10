using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.User.Entities;

namespace RAS.Infrastructure.Data.Config.Menu;

public class MenuitemEntityConfiguration : BaseEntityConfiguration<MenuItemEntity>
{
    protected override void ConfigureEntity(EntityTypeBuilder<MenuItemEntity> builder)
    {
        builder.ToTable("MenuItems");

        builder.Property(x => x.Name).IsRequired().HasColumnType("nvarchar(128)");
        builder.Property(x => x.Category).IsRequired().HasColumnType("nvarchar(128)");
        builder.Property(x => x.Price).IsRequired();
    }
}
