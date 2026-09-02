using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;
using NutriFood.Domain.Repositories;

namespace NutriFood.Application.Services.Implementations;

public sealed class UserService : CrudService<User, short>, IUserService
{
    public UserService(IUserRepository repository) : base(repository)
    {
    }
}