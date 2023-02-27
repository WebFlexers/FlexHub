using FlexHub.Data.DTOs;
using System.Security.Claims;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlexHub.BlazorServer.Pages.MainFeed;

public partial class MainFeed
{
    public ContactsHorizontalBar ContactsHorizontalBarComponent { get; set; }
    public MainPostsFeed MainPostsFeedComponent { get; set; }

    [Inject]
    public ILogger<MainFeed> Logger { get; set; }
    [Inject]
    public IUserRepository UserRepository { get; set; }
    [Inject]
    public ITagRepository TagRepository { get; set; }

    private bool testBool = true;
    private bool _areRecentContactsEmpty = true;
    private UserDTO? _userDTO;
    private Claim[]? _userClaims;
    private List<TagDTO> _userTags = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender == false)
        {
            return;
        }

        if (_userClaims == null)
        {
            return;
        }

        _userDTO = CreateUserDtoFromClaims(_userClaims);

        _userTags = await TagRepository.GetUserTags(_userDTO!.ObjectId);
        MainPostsFeedComponent.PreferredTags = _userTags.Select(ut => new Tag
        {
            Id = ut.Id,
            Value = ut.Value
        }).ToList();

        await MainPostsFeedComponent.FetchPostsByPreferredTags(1, 5);
        MainPostsFeedComponent.Refresh();
        await ContactsHorizontalBarComponent.GetLastContactsOfUser(_userDTO.ObjectId, 6);

        _areRecentContactsEmpty = ContactsHorizontalBarComponent.RecentContacts.Any() == false;

        StateHasChanged();

        var isUserNew = _userClaims.FirstOrDefault(c => c.Type.Contains("newUser"))?.Value;
        if (isUserNew != null && _userDTO != null && bool.Parse(isUserNew))
        {
            await UserRepository.CreateUser(_userDTO);
        }
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
            Logger.LogError("1 or more properties from jwt token where null after registration. The properties are " +
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
