using NukeLogin.Src.Domain.ValueObjects.Base;

namespace NukeLogin.Src.Domain.Entitys;
public record LoginAttempt
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid UserId { get; set; }
    public DateTime SessionTime { get; set; }
    public bool IsSuccess { get; set; }

    public bool IsBot { get; set; }
    public string? ASN { get; set; }
    public string? IpAddress { get; set; }
    public UserAgentInfo? UserAgent { get; set; }
    public Coordinates? Coordinates { get; set; }
}
