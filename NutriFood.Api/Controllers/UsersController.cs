using NutriFood.Api.Controllers.Bases;
using NutriFood.Application.Contracts;
using NutriFood.Application.Mappers;
using NutriFood.Application.Services.Abstractions;
using NutriFood.Domain.Entities;

namespace NutriFood.Api.Controllers;

public sealed class UsersController : CrudControllerBase<User, short, UserCreateRequest, UserUpdateRequest, UserResponse>
{
    public UsersController(IUserService service) : base(service)
    {
    }

    protected override User ToEntity(UserCreateRequest request) => UserMapper.ToEntity(request);

    protected override User ToEntity(UserUpdateRequest request, User existing) => UserMapper.ToEntity(request, existing);

    protected override UserResponse Map(User entity) => UserMapper.Map(entity);
}