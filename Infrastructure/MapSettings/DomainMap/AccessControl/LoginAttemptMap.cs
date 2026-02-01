using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NukeLogin.Src.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Infrastructure.MapSettings.DomainMap.AccessControl
{
    public class LoginAttemptMap : IEntityTypeConfiguration<LoginAttempt>
    {
        public void Configure(EntityTypeBuilder<LoginAttempt> builder)
        {
            throw new NotImplementedException();
        }
    }
}
