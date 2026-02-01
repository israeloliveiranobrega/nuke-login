using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Src.Domain.Models.Base.Enums
{
    public enum AccountStatus
    {
        Pending = 0,
        Active = 1,
        Inactive = 2,
        Suspended = 3,
        Deleted = 4
    }
}
