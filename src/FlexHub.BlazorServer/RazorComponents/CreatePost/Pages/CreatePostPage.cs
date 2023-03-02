using System.Security.Claims;
using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.Stores.AuthToken;
using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;
using Radzen;

namespace FlexHub.BlazorServer.RazorComponents.CreatePost.Pages;

public partial class CreatePostPage
{
    private readonly CreatePostModel _post = new();
    private List<TagModel>? _allTags;
    private Claim[]? _userClaims;

    [Inject] public ILogger<CreatePostPage> Logger { get; set; } = null!;

    [Inject] public IUserInfoStore UserInfoStore { get; set; } = null!;

    [Inject] public ITagRepository TagRepository { get; set; } = null!;

    [Inject] public IPostRepository PostRepository { get; set; } = null!;

    [Inject] public NotificationService NotificationService { get; set; } = null!;

    public async Task Create()
    {
        if (UserInfoStore.UserDTO?.ObjectId == null) return;

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
            NotificationService.Notify(new NotificationMessage
            {
                Summary = "Failed",
                Detail = "Failed To Create Post. You must select at least one tag",
                Style = "position: fixed; left: 50%; transform: translate(-50%)",
                Severity = NotificationSeverity.Error,
                Duration = 5000
            });
            return;
        }

        var postCreated = await PostRepository.CreatePost(new CreatePostDTO
        {
            UserObjectId = UserInfoStore.UserDTO.ObjectId,
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
            NotificationService.Notify(new NotificationMessage
            {
                Summary = "Success",
                Detail = "Successfully Created Post!",
                Style = "position: fixed; left: 50%; transform: translate(-50%)",
                Severity = NotificationSeverity.Success,
                Duration = 5000
            });
        }
        else
        {
            NotificationService.Notify(new NotificationMessage
            {
                Summary = "Failed",
                Detail = "Failed To Create Post! Make sure you haven't already posted something with the same title",
                Style = "position: fixed; left: 50%; transform: translate(-50%)",
                Severity = NotificationSeverity.Error,
                Duration = 5000
            });
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

    protected override void OnAfterRender(bool firstRender)
    {
        if (firstRender == false) return;

        UserInfoStore.UserDTO = UserInfoStore.CreateUserDtoFromClaims(_userClaims!);

        StateHasChanged();
    }
}