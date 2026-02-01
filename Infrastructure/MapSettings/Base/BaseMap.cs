using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NukeLogin.Src.Domain.Models.Base;

namespace NukeLogin.Infrastructure.MapSettings.Base;
public abstract class BaseMap<T> : IEntityTypeConfiguration<T> where T : BaseMetaData
{
    public virtual void Configure(EntityTypeBuilder<T> builder)
    {
        builder.HasKey(e => e.Id);
        builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedNever();

        builder.Property(e => e.CreatedBy).HasColumnName("created_by");
        builder.Property(e => e.CreateDate).HasColumnName("created_date").HasDefaultValueSql("NOW()");

        builder.Property(e => e.LastUpdateBy).HasColumnName("updated_by");
        builder.Property(e => e.LastUpdateDate).HasColumnName("updated_date");

        builder.Property(e => e.IsSuspended).HasColumnName("is_suspended").HasDefaultValue(false);
        builder.Property(e => e.SuspendedBy).HasColumnName("suspended_by");
        builder.Property(e => e.SuspendedDate).HasColumnName("Suspended_date");

        builder.Property(e => e.IsDeleted).HasColumnName("is_deleted").HasDefaultValue(false);
        builder.Property(e => e.DeletedBy).HasColumnName("deleted_by");
        builder.Property(e => e.DeletedDate).HasColumnName("deleted_date");

        builder.Property(e => e.Version)
            .HasColumnName("xmin")
            .HasColumnType("xid")
            .IsRowVersion()
            .ValueGeneratedOnAdd()
            .IsRequired(true);
    }
}
