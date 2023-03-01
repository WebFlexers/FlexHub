using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.Stores.AuthToken;
using FlexHub.BlazorServer.Stores.Search;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Security.Claims;

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
    [Inject]
    public ISearchPostsTermsStore SearchPostsTermsStore { get; set; }
    [Inject]
    public IUserInfoStore UserInfoStore { get; set; }

    private bool _areRecentContactsEmpty = true;
    private Claim[]? _userClaims;

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

        UserInfoStore.UserDTO = UserInfoStore.CreateUserDtoFromClaims(_userClaims);

        if (UserInfoStore.UserDTO == null)
        {
            return;
        }

        var userTagDTOs = await TagRepository.GetUserTags(UserInfoStore.UserDTO.ObjectId);
        SearchPostsTermsStore.Tags = userTagDTOs.Select(ut => new TagModel { Id = ut.Id, IsChecked = false, Value = ut.Value }).ToList();

        await MainPostsFeedComponent.FetchPosts(MainPostsFeedComponent.PageNum, 5);
        MainPostsFeedComponent.Refresh();
        await ContactsHorizontalBarComponent.GetLastContactsOfUser(UserInfoStore.UserDTO.ObjectId, 6);

        _areRecentContactsEmpty = ContactsHorizontalBarComponent.RecentContacts.Any() == false;

        StateHasChanged();

        var isUserNew = _userClaims.FirstOrDefault(c => c.Type.Contains("newUser"))?.Value;
        if (isUserNew != null && bool.Parse(isUserNew))
        {
            await UserRepository.CreateUser(UserInfoStore.UserDTO);
        }
    }

    public async Task OnSearchButtonClick()
    {
        MainPostsFeedComponent.Posts = new List<PostModel>();
        MainPostsFeedComponent.PageNum = 1;
        await MainPostsFeedComponent.FetchPosts(1, 5);

        if (MainPostsFeedComponent.Posts.Any().Equals(false))
        {
            MainPostsFeedComponent.Refresh();
        }
    }
}
