using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Features.AccessControl.Login
{
    public record LoginUserResponse(Guid SessionId,Guid UserId, string AccessToken, string RefreshToken);
}
