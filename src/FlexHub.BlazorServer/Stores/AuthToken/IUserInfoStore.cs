using System.Security.Claims;
using FlexHub.Data.DTOs;

namespace FlexHub.BlazorServer.Stores.AuthToken;

public interface IUserInfoStore
{
    UserDTO? UserDTO { get; set; }
    UserDTO? CreateUserDtoFromClaims(Claim[] claims);
}