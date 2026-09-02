using NutriFood.Application.Contracts;
using NutriFood.Domain.Entities;

namespace NutriFood.Application.Mappers;

public static class UserMapper
{
    public static UserResponse Map(User entity) => new(
        entity.Id,
        entity.Code,
        entity.FirstName,
        entity.LastName,
        entity.Email,
        entity.Active);

    public static User ToEntity(UserCreateRequest request) => new()
    {
        Code = request.Code,
        FirstName = request.FirstName,
        LastName = request.LastName,
        Email = request.Email,
        Password = request.Password,
        Active = true,
        CreaDate = DateTime.Now
    };

    public static User ToEntity(UserUpdateRequest request, User existing) => new()
    {
        Code = request.Code,
        FirstName = request.FirstName,
        LastName = request.LastName,
        Email = request.Email,
        Password = existing.Password,
        Active = request.Active,
        CreaDate = existing.CreaDate
    };
}