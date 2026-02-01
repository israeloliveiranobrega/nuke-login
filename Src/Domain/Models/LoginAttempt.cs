namespace NukeLogin.Src.Domain.Models;
public record LoginAttempt
{
    public Guid Id { get; set; } = Guid.CreateVersion7();
    public Guid UserId { get; set; }

    public DateTime SessionTime { get; set; }

    public bool IsSuccess { get; set; }
    public bool IsBot { get; set; }

    //user agent details
    public string? UserAgent { get; set; }
    public string? Browser { get; set; }
    public string? BrowserMajor { get; set; }
    public string? System { get; set; }
    public string? SystemMajor { get; set; }
    public string? Device { get; set; }
    public string? DeviceBrand { get; set; }

    //network details
    public string? ASN { get; set; }
    public string? IpAddress { get; set; }

    //location details
    public string? Latitude { get; set; }
    public string? Longitude { get; set; }
    public string? Country { get; set; }
    public string? City { get; set; }
}
