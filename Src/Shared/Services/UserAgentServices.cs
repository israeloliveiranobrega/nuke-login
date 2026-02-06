using NukeLogin.Src.Domain.ValueObjects.Base;
using UAParser;

namespace NukeLogin.Src.Shared.Services
{
    public interface IUserAgentServices
    {
        Task<UserAgentInfo> Track(string userAgentComplete); 
    }
    public class UserAgentServices : IUserAgentServices
    {
        public async Task<UserAgentInfo> Track(string userAgentComplete)
        {

            ClientInfo client = Parser.GetDefault().Parse(userAgentComplete);
            return new UserAgentInfo(
                userAgentComplete,
                client.UA.Family,
                client.UA.Major,
                client.OS.Family,
                client.OS.Major,
                client.Device.Family,
                client.Device.Brand,
                client.Device.IsSpider
                );
        }
    }
}
