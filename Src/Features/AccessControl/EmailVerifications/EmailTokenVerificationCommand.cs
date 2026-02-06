using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Features.AccessControl.EmailVerifications
{
    public class EmailTokenVerificationCommand(string recipient) : IRequest<EmailTokenVerificationResponse>
    {
        public string Recipient { get; } = recipient;
    }
}
