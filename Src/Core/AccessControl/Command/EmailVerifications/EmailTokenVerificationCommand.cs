using MediatR;
using NukeLogin.Src.Core.DTOs.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Core.AccessControl.Command.EmailVerifications
{
    public class EmailTokenVerificationCommand(string recipient, EmailPostDTO post) : IRequest<EmailTokenVerificationResponse>
    {
        public string Recipient { get; } = recipient;
        public EmailPostDTO Post { get; } = post;
    }
}
