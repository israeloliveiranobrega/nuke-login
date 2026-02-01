using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Core.DTOs.Base
{
    public record CompletedEmailDTO(string Recipient, EmailPostDTO Post);
}
