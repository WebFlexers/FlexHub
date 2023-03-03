using System.Security.Claims;
using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.RazorComponents.MainFeed.Components;
using FlexHub.BlazorServer.Stores.AuthToken;
using FlexHub.BlazorServer.Stores.Search;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlexHub.BlazorServer.RazorComponents.MainFeed.Pages;

public partial class MainFeedPage
{
    private bool _areRecentContactsEmpty = true;
    private Claim[]? _userClaims;
    public ContactsHorizontalBarComponent? ContactsHorizontalBarComponent { get; set; } 
    public PostsComponent? MainPostsFeedComponent { get; set; }

    [Inject] public ILogger<MainFeedPage> Logger { get; set; } = null!;

    [Inject] public IUserRepository UserRepository { get; set; } = null!;

    [Inject] public ITagRepository TagRepository { get; set; } = null!;

    [Inject] public ISearchPostsTermsStore SearchPostsTermsStore { get; set; } = null!;

    [Inject] public IUserInfoStore UserInfoStore { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender == false) return;

        if (MainPostsFeedComponent == null || ContactsHorizontalBarComponent == null) return;

        if (_userClaims == null) return;

        UserInfoStore.UserDTO = UserInfoStore.CreateUserDtoFromClaims(_userClaims);

        if (UserInfoStore.UserDTO == null) return;

        var userTagDTOs = await TagRepository.GetUserTags(UserInfoStore.UserDTO.ObjectId);

        if (userTagDTOs != null && userTagDTOs.Any())
        {
            SearchPostsTermsStore.Tags = userTagDTOs
                .Select(ut => new TagModel { Id = ut.Id, IsChecked = false, Value = ut.Value }).ToList();
        }

        StateHasChanged();

        await MainPostsFeedComponent.FetchPosts(MainPostsFeedComponent.PageNum, 5);
        await ContactsHorizontalBarComponent.GetLastContactsOfUser(UserInfoStore.UserDTO.ObjectId, 6);

        _areRecentContactsEmpty = ContactsHorizontalBarComponent.RecentContacts?.Any() == false;

        await MainPostsFeedComponent.AnimateStateChange();

        var isUserNew = _userClaims.FirstOrDefault(c => c.Type.Contains("newUser"))?.Value;
        if (isUserNew != null && bool.Parse(isUserNew))
        {
            await UserRepository.CreateUser(UserInfoStore.UserDTO);
        }
    }

    public async Task OnSearchButtonClick()
    {
        if (MainPostsFeedComponent == null) return;

        MainPostsFeedComponent.Posts = new List<PostModel>();
        MainPostsFeedComponent.PageNum = 1;
        await MainPostsFeedComponent.FetchPosts(1, 5);
        await MainPostsFeedComponent.AnimateStateChange();

        if (MainPostsFeedComponent.Posts.Any().Equals(false))
        {
            MainPostsFeedComponent.Refresh();
        }
    }
}