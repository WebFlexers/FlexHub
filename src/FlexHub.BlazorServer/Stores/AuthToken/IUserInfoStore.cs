using FlexHub.Data.DTOs;
using System.Security.Claims;

namespace FlexHub.BlazorServer.Stores.AuthToken;

public interface IUserInfoStore
{
    UserDTO? UserDTO { get; set; }
    UserDTO? CreateUserDtoFromClaims(Claim[] claims);
}