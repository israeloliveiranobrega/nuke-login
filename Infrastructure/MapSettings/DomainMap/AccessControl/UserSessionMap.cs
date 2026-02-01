using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NukeLogin.Src.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace NukeLogin.Infrastructure.MapSettings.DomainMap.AccessControl
{
    public class UserSessionMap : IEntityTypeConfiguration<UserSession>
    {
        public void Configure(EntityTypeBuilder<UserSession> builder)
        {
            throw new NotImplementedException();
        }
    }
}
