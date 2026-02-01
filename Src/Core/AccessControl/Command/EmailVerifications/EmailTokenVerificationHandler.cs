using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Core.AccessControl.Command.EmailVerifications
{
    internal class EmailTokenVerificationHandler : IRequestHandler<EmailTokenVerificationCommand, EmailTokenVerificationResponse>
    {
        public Task<EmailTokenVerificationResponse> Handle(EmailTokenVerificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
