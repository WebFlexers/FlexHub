using FlexHub.Data.DTOs;
using System.Security.Claims;

namespace FlexHub.BlazorServer.Utilities;

public static class AuthUtilities
{
        public static UserDTO? CreateUserDtoFromClaims(IEnumerable<Claim>? claims, ILogger logger)
    {
        if (claims == null) return default;

        var claimsArray = claims as Claim[] ?? claims.ToArray();
        var userObjectId = claimsArray.FirstOrDefault(c => c.Type.Contains("nameidentifier"))?.Value;
        var email = claimsArray.FirstOrDefault(c => c.Type.Contains("emails"))?.Value;
        var givenName = claimsArray.FirstOrDefault(c => c.Type.Contains("givenname"))?.Value;
        var surname = claimsArray.FirstOrDefault(c => c.Type.Contains("surname"))?.Value;
        var displayName = claimsArray.FirstOrDefault(c => c.Type.Equals("name"))?.Value;
        var country = claimsArray.FirstOrDefault(c => c.Type.Contains("country"))?.Value;
        var createdAtUnix = claimsArray.FirstOrDefault(c => c.Type.Contains("auth_time"))?.Value;

        if (string.IsNullOrWhiteSpace(userObjectId) || string.IsNullOrWhiteSpace(email) ||
            string.IsNullOrWhiteSpace(givenName) ||
            string.IsNullOrWhiteSpace(surname) || string.IsNullOrWhiteSpace(displayName) ||
            string.IsNullOrWhiteSpace(country) ||
            string.IsNullOrWhiteSpace(createdAtUnix))
        {
            logger.LogWarning("1 or more properties from jwt token where null after registration. The properties are " +
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
