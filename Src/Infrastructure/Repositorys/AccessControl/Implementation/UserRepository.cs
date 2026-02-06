using MediatR;
using Microsoft.EntityFrameworkCore;
using NukeLogin.Src.Domain.Entitys;
using NukeLogin.Src.Domain.ValueObjects.Base;
using NukeLogin.Src.Domain.ValueObjects.Base.Enums;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Contracts;
using NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation.DTOs;
using System.Threading;

namespace NukeLogin.Src.Infrastructure.Repositorys.AccessControl.Implementation
{
    public partial class UserRepository(DataContext dataContext) : IUserRepository
    {
        private readonly DataContext _dataContext = dataContext;
        private readonly DbSet<User> _user = dataContext.Users;
    }
}
