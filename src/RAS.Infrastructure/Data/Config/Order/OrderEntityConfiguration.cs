using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RAS.Core.Aggregates.Order.Entities;
using RAS.Core.Aggregates.User.Entities;

namespace RAS.Infrastructure.Data.Config.User;

public class OrderEntityConfiguration : BaseEntityConfiguration<OrderEntity>
{
    protected override void ConfigureEntity(EntityTypeBuilder<OrderEntity> builder)
    {
        builder.ToTable("Orders");
                          
        builder.Property(x => x.Status).IsRequired().HasColumnType("nvarchar(64)");
        builder.Property(x => x.Sum).IsRequired();

        builder
            .HasOne(x => x.User)
            .WithMany()
            .HasForeignKey(x => x.UserId)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
