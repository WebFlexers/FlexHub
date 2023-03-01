using FlexHub.Data.DTOs;
using System.Security.Claims;

namespace FlexHub.BlazorServer.Stores.AuthToken;

public class UserInfoStore : IUserInfoStore
{
    public UserDTO? UserDTO { get; set; }

    private readonly ILogger<UserInfoStore> _logger;

    public UserInfoStore(ILogger<UserInfoStore> logger)
    {
        _logger = logger;
    }

    public UserDTO? CreateUserDtoFromClaims(Claim[] claims)
    {
        var userObjectId = claims.FirstOrDefault(c => c.Type.Contains("nameidentifier"))?.Value;
        var email = claims.FirstOrDefault(c => c.Type.Contains("emails"))?.Value;
        var givenName = claims.FirstOrDefault(c => c.Type.Contains("givenname"))?.Value;
        var surname = claims.FirstOrDefault(c => c.Type.Contains("surname"))?.Value;
        var displayName = claims.FirstOrDefault(c => c.Type.Equals("name"))?.Value;
        var country = claims.FirstOrDefault(c => c.Type.Contains("country"))?.Value;
        var createdAtUnix = claims.FirstOrDefault(c => c.Type.Contains("auth_time"))?.Value;

        if (string.IsNullOrWhiteSpace(userObjectId) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(givenName) ||
            string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(displayName) || string.IsNullOrWhiteSpace(country) ||
            string.IsNullOrWhiteSpace(createdAtUnix))
        {
            _logger.LogError("1 or more properties from jwt token where null after registration. The properties are " +
                             "objectId: {userObjectId}, email: {email}, given name: {givenName}, surname: {surname}, displayname: {displayName}" +
                             "country: {country}, createdAtUnix: {createdAtUnix}", 
                userObjectId, email, givenName, surname, displayName, country, createdAtUnix);
            return default;
        }

        var createdAt = DateTimeOffset.FromUnixTimeSeconds(long.Parse(createdAtUnix)).UtcDateTime;

        return new UserDTO
        {
            ObjectId = userObjectId,
            EmailAddress = email,
            GivenName = givenName,
            Surname = surname,
            DisplayName = displayName,
            Country = country,
            CreatedAt = createdAt,
            UpdatedAt = createdAt
        };
    }
}
