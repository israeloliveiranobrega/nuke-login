using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Features.AccessControl.EmailVerifications
{
    public class EmailTokenVerificationHandler : IRequestHandler<EmailTokenVerificationCommand, EmailTokenVerificationResponse>
    {
        public Task<EmailTokenVerificationResponse> Handle(EmailTokenVerificationCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
