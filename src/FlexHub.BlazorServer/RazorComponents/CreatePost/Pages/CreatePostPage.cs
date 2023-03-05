using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.Utilities;
using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using MatBlazor;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FlexHub.BlazorServer.RazorComponents.CreatePost.Pages;

public partial class CreatePostPage
{
    private readonly CreatePostModel _post = new();
    private List<TagModel>? _allTags;

    [Inject] public ILogger<CreatePostPage> Logger { get; set; } = null!;

    [Inject] public ITagRepository TagRepository { get; set; } = null!;

    [Inject] public IPostRepository PostRepository { get; set; } = null!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    [Inject] public IMatToaster Toaster { get; set; } = null!;

    public async Task Create()
    {
        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        if (_allTags == null || _allTags.Any().Equals(false)) return;

        var checkedTags = _allTags
            .Where(t => t.IsChecked)
            .Select(t => new TagDTO
            {
                Id = t.Id,
                Value = t.Value
            }).ToList();

        if (checkedTags.Any() == false)
        {
            ShowToastMessage(MatToastType.Danger,
                "Failed", "Failed To Create Post. You must select at least one tag");
            return;
        }

        var postCreated = await PostRepository.CreatePost(new CreatePostDTO
        {
            UserObjectId = userDTO.ObjectId,
            Title = _post.Title,
            Content = _post.Content,
            Tags = _allTags
                .Where(t => t.IsChecked)
                .Select(t => new TagDTO
                {
                    Id = t.Id,
                    Value = t.Value
                }).ToList()
        });

        if (postCreated)
        {
            ShowToastMessage(MatToastType.Success,
                "Success", "Successfully Created Post!");
        }
        else
        {
            ShowToastMessage(MatToastType.Danger,
                "Failed", "Failed To Create Post! Make sure you haven't already posted something with the same title");
        }
    }

    protected override async Task OnInitializedAsync()
    {
        var tags = await TagRepository.GetAllTags();

        if (tags == null || tags.Any().Equals(false)) return;

        _allTags = tags.Select(tag => new TagModel
        {
            Id = tag.Id,
            Value = tag.Value,
            IsChecked = false
        }).ToList();
    }

    public void ShowToastMessage(MatToastType type, string title, string message, string icon = "")
    {
        Toaster.Add(message, type, title, icon, config =>
        {
            config.ShowCloseButton = true;
            config.ShowProgressBar = true;
            config.MaximumOpacity = Convert.ToInt32(95);
 
            config.ShowTransitionDuration = Convert.ToInt32(500);
            config.VisibleStateDuration = Convert.ToInt32(5000);
            config.HideTransitionDuration = Convert.ToInt32(500);
 
            config.RequireInteraction = false;
        });
    }
}