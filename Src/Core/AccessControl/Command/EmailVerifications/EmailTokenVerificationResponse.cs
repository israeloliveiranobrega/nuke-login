using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Core.AccessControl.Command.EmailVerifications
{
    public class EmailTokenVerificationResponse(string Token);
}
