using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NukeLogin.Src.Domain.Entitys;
using NukeLogin.Src.Domain.ValueObjects.Base;

namespace NukeLogin.Src.Infrastructure.MapSettings.DomainMap.AccessControl
{
    public class UserSessionMap : IEntityTypeConfiguration<UserSession>
    {
        public void Configure(EntityTypeBuilder<UserSession> builder)
        {
            builder.ToTable("user_session");

            builder.HasKey(e => e.Id);
            builder.Property(e => e.Id).HasColumnName("id").ValueGeneratedNever();

            builder.Property(e => e.UserId).HasColumnName("user_id").IsRequired();

            builder.HasOne<User>()
               .WithMany()
               .HasForeignKey(s => s.UserId)
               .HasConstraintName("fk_session_user_id")
               .OnDelete(DeleteBehavior.Restrict);

            builder.OwnsOne(x => x.UserAgent, userAgent =>
            {
                userAgent.Property(ua => ua.UserAgentComplete).HasColumnName("user_agent_complete").IsRequired();
                userAgent.Property(ua => ua.Browser).HasColumnName("browser");
                userAgent.Property(ua => ua.BrowserMajor).HasColumnName("browser_major");
                userAgent.Property(ua => ua.System).HasColumnName("system");
                userAgent.Property(ua => ua.SystemMajor).HasColumnName("system_major");
                userAgent.Property(ua => ua.Device).HasColumnName("device");
                userAgent.Property(ua => ua.DeviceBrand).HasColumnName("device_brand");
                userAgent.Ignore(ua => ua.SpiderOrBot);
            });

            builder.OwnsOne(x => x.RefreshToken, refreshToken =>
            {
                refreshToken.Property(rt => rt.Code).HasColumnName("refresh_token_code").IsRequired();
                refreshToken.Property(rt => rt.CreatedAt).HasColumnName("refresh_token_created_at").IsRequired();
                refreshToken.Property(rt => rt.ExpiresOn).HasColumnName("refresh_token_expires_on").IsRequired();
            });

            builder.Property(rt => rt.IsExpired).HasColumnName("refresh_token_is_expired").IsRequired();
            builder.Property(rt => rt.Revoked).HasColumnName("refresh_token_Is_revoked").IsRequired();
            builder.Property(rt => rt.IsActive).HasColumnName("refresh_token_is_active").IsRequired();
        }
    }
}
