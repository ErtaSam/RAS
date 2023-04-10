using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RAS.Core.Aggregates.Menu.Entities;
using RAS.Core.Aggregates.User.Entities;

namespace RAS.Infrastructure.Data.Config.Menu;

public class MenuMenuItemEntityConfiguration : IEntityTypeConfiguration<MenuMenuItemEntity>
{
    public void Configure(EntityTypeBuilder<MenuMenuItemEntity> builder)
    {
        builder.ToTable("MenuMenuItems");

        builder.HasKey(x => new { x.MenuId, x.MenuItemId });

        builder
            .HasOne(x => x.Menu)
            .WithMany(x => x.MenuItems)
            .HasForeignKey(x => x.MenuId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);

        builder
            .HasOne(x => x.MenuItem)
            .WithMany()
            .HasForeignKey(x => x.MenuItemId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
