using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Domain.Models
{
    public record UserSession(Guid UserId, string RefreshToken, DateTime ExpiresAt)
    {
        public Guid Id { get; private set; } = Guid.CreateVersion7();
        public Guid UserId { get; private set; } = UserId;

        public Guid? LoginAttemptId { get; private set; }

        public string RefreshToken { get; private set; } = RefreshToken;
        public DateTime ExpiresAt { get; private set; } = ExpiresAt;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime? RevokedAt { get; private set; }

        public bool IsActive => RevokedAt == null && DateTime.UtcNow < ExpiresAt;

        public void Revoke() => RevokedAt = DateTime.UtcNow;
    }
}
