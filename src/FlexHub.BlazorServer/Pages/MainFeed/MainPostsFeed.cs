using FlexHub.BlazorServer.Models;
using FlexHub.Data.Entities;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;

namespace FlexHub.BlazorServer.Pages.MainFeed;

public partial class MainPostsFeed
{
    [Inject]
    public IPostRepository PostRepository { get; set; }
    [Inject]
    public IUserRepository UserRepository { get; set; }

    public List<PostModel>? Posts { get; set; } = new();
    public List<Tag> PreferredTags { get; set; }

    private int _pageNum = 2;

    public void Refresh()
    {
        StateHasChanged();
    }

    public async Task FetchPostsByPreferredTags(int pageNumber, int itemsPerPage)
    {
        var newPosts = await PostRepository.GetPaginatedPostsSortedByPreferredTags(PreferredTags, pageNumber, itemsPerPage);

        if (newPosts == null || newPosts.Any() == false)
        {
            return;
        }

        var newPostModels = new List<PostModel>();
        foreach (var newPost in newPosts)
        {
            var authorDisplayName = await UserRepository.GetUser(newPost.UserObjectId);
            newPostModels.Add(new PostModel
            {
                Title = newPost.Title,
                Content = newPost.Content,
                PublisherDisplayName = authorDisplayName.DisplayName,
                Tags = newPost.Tags,
            });
        }

        Posts!.AddRange(newPostModels);

        StateHasChanged();
    }
}
