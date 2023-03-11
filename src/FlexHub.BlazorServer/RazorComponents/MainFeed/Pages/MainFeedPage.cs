using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.RazorComponents.MainFeed.Components;
using FlexHub.BlazorServer.Stores.Search;
using FlexHub.BlazorServer.Utilities;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FlexHub.BlazorServer.RazorComponents.MainFeed.Pages;

public partial class MainFeedPage
{
    public ContactsHorizontalBarComponent? ContactsHorizontalBarComponent { get; set; } 
    public PostsComponent? MainPostsFeedComponent { get; set; }

    [Inject] public ILogger<MainFeedPage> Logger { get; set; } = null!;

    [Inject] public IUserRepository UserRepository { get; set; } = null!;

    [Inject] public ITagRepository TagRepository { get; set; } = null!;

    [Inject] public ISearchPostsTermsStore SearchPostsTermsStore { get; set; } = null!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender == false) return;

        if (MainPostsFeedComponent == null || ContactsHorizontalBarComponent == null) return;

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        var userTagDTOs = await TagRepository.GetUserTags(userDTO.ObjectId);

        if (userTagDTOs != null && userTagDTOs.Any())
        {
            SearchPostsTermsStore.Tags = userTagDTOs
                .Select(ut => new TagModel { Id = ut.Id, IsChecked = false, Value = ut.Value }).ToList();
        }

        StateHasChanged();

        await MainPostsFeedComponent.FetchPosts(MainPostsFeedComponent.PageNum++, 5);
        await ContactsHorizontalBarComponent.GetLastContactsOfUser(userDTO.ObjectId, 6);

        await MainPostsFeedComponent.AnimateStateChange();

        var isUserNew = authState.User.Claims.FirstOrDefault(c => c.Type.Contains("newUser"))?.Value;
        if (isUserNew != null && bool.Parse(isUserNew))
        {
            await UserRepository.CreateUser(userDTO);
        }
        else
        {
            await UserRepository.UpdateUser(userDTO);
        }
    }

    /// <summary>
    /// Fetches the posts according to the selected filters if any
    /// </summary>
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