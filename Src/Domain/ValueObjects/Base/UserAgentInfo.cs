using UAParser;

namespace NukeLogin.Src.Domain.ValueObjects.Base
{
    public record UserAgentInfo
    {
        public string UserAgentComplete { get; set; }
        public string? Browser { get; set; }
        public string? BrowserMajor { get; set; }
        public string? System { get; set; }
        public string? SystemMajor { get; set; }
        public string? Device { get; set; }
        public string? DeviceBrand { get; set; }
        public bool? SpiderOrBot { get; set; }

        private UserAgentInfo() { }

        public UserAgentInfo(string userAgentComplete, string? browser, string? browserMajor, string? system, string? systemMajor, string? device, string? deviceBrand, bool? spiderOrBot)
        {
            UserAgentComplete = userAgentComplete;
            Browser = browser;
            BrowserMajor = browserMajor;
            System = system;
            SystemMajor = systemMajor;
            Device = device;
            DeviceBrand = deviceBrand;
            SpiderOrBot = spiderOrBot;
        }
    }
}
    