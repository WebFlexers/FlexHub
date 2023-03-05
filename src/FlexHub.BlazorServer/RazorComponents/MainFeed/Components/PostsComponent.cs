using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.Stores.Search;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;
using System.Globalization;
using Microsoft.AspNetCore.Components.Authorization;

namespace FlexHub.BlazorServer.RazorComponents.MainFeed.Components;

public partial class PostsComponent
{
    public bool ShowAnimation { get; set; } = false;

    [Inject] public IPostRepository PostRepository { get; set; } = null!;

    [Inject] public IUserRepository UserRepository { get; set; } = null!;

    [Inject] public ISearchPostsTermsStore SearchPostsTermsStore { get; set; } = null!;

    public List<PostModel>? Posts { get; set; } = new();

    public int PageNum { get; set; } = 1;

    public void Refresh()
    {
        StateHasChanged();
    }

    public async Task FetchPosts(int pageNumber, int itemsPerPage)
    {
        List<PostDTO>? newPosts;
        var newSearchMode = SearchPostsTermsStore.GetSearchMode();

        switch (newSearchMode)
        {
            case SearchBy.None:
                var tagEntities = SearchPostsTermsStore.Tags!.Select(tm => new Tag { Id = tm.Id, Value = tm.Value })
                    .ToList();
                newPosts = await PostRepository.GetPaginatedPostsSortedByPreferredTags(tagEntities, pageNumber,
                    itemsPerPage);
                break;
            case SearchBy.SearchText:
                newPosts = await PostRepository.GetPaginatedPostsFilteredByTitle(SearchPostsTermsStore.SearchText!,
                    pageNumber, itemsPerPage);
                break;
            case SearchBy.Tags:
                var tagEntities2 = SearchPostsTermsStore.Tags!
                    .Where(tm => tm.IsChecked)
                    .Select(tm => new Tag { Id = tm.Id, Value = tm.Value }).ToList();
                newPosts = await PostRepository.GetPaginatedPostsFilteredByTags(tagEntities2, pageNumber, itemsPerPage);
                break;
            case SearchBy.SearchTextAndTags:
                var tagEntities3 = SearchPostsTermsStore.Tags!
                    .Where(tm => tm.IsChecked)
                    .Select(tm => new Tag { Id = tm.Id, Value = tm.Value }).ToList();
                newPosts = await PostRepository.GetPaginatedPostsFilteredByTitleAndTags(
                    SearchPostsTermsStore.SearchText!, tagEntities3, pageNumber, itemsPerPage);
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }

        if (newPosts == null || newPosts.Any().Equals(false)) return;

        // If the search filters have changed search from the beginning
        if (newSearchMode.Equals(SearchPostsTermsStore.LastSearch) == false)
        {
            Posts = new List<PostModel>();
            PageNum = 1;
        }

        SearchPostsTermsStore.LastSearch = newSearchMode;

        var getPostsUsersTasks = new List<Task<UserDTO?>>();
        foreach (var post in newPosts)
        {
            getPostsUsersTasks.Add(GetPostUser(post.UserObjectId));
        }

        var newPostsUsers = await Task.WhenAll(getPostsUsersTasks);

        var newPostModels = new List<PostModel>();

        for (var i = 0; i < newPosts.Count; i++)
        {
            newPostModels.Add(new PostModel
            {
                Id = newPosts[i].PostId,
                Title = newPosts[i].Title,
                Content = newPosts[i].Content,
                PublisherDisplayName = newPostsUsers[i]?.DisplayName,
                CreatedAt = newPosts[i].CreatedAt.ToLocalTime().ToString(CultureInfo.InvariantCulture),
                Tags = newPosts[i].Tags
            });   
        }

        var postsCount = Posts!.Count;
        if (postsCount is > 0 and < 5) return;

        Posts!.AddRange(newPostModels);
    }

    private async Task<UserDTO?> GetPostUser(string userObjectId)
    {
        return await UserRepository.GetUser(userObjectId);
    }

    public async Task AnimateStateChange()
    {
        ShowAnimation = false;
        await InvokeAsync( StateHasChanged );
        await Task.Delay(TimeSpan.FromMilliseconds(1));

        ShowAnimation = true;
        await InvokeAsync( StateHasChanged );
    }
}