using FlexHub.BlazorServer.Models;
using FlexHub.BlazorServer.Utilities;
using FlexHub.Data.DTOs;
using FlexHub.Services.DataAccess.Interfaces;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace FlexHub.BlazorServer.RazorComponents.Profile.Components;

public partial class TagsSidebarComponent
{
    [Inject] public ILogger<ProfileMainComponent> Logger { get; set; } = null!;

    [Inject] public ITagRepository TagRepository { get; set; } = null!;

    [Inject] public AuthenticationStateProvider AuthenticationStateProvider { get; set; } = null!;

    private List<TagModel> _allTags = new();

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender == false) return;

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        var tagsFetchTasks = new List<Task<List<TagDTO>?>>
        {
            TagRepository.GetAllTags(),
            TagRepository.GetUserTags(userDTO.ObjectId)
        };

        var results = await Task.WhenAll(tagsFetchTasks);

        var userTags = results[1] ?? new List<TagDTO>();

        _allTags = results[0]?.Select(tag => new TagModel
        {
            Id = tag.Id,
            Value = tag.Value,
            IsChecked = userTags.Any(ut => ut.Id.Equals(tag.Id))
        }).ToList() ?? new List<TagModel>();

        await InvokeAsync(StateHasChanged);
    }

    private async Task OnTagCheckboxValueChanged(ChangeEventArgs e, int tagId)
    {
        if (e.Value is not bool isChecked) return;

        var authState = await AuthenticationStateProvider.GetAuthenticationStateAsync();
        var userDTO = AuthUtilities.CreateUserDtoFromClaims(authState.User.Claims, Logger);

        if (userDTO == null) return;

        bool result;

        if (isChecked)
        {
            result = await TagRepository.SubscribeTagToUser(userDTO.ObjectId, tagId);
        }
        else
        {
            result = await TagRepository.UnsubscribeTagFromUser(userDTO.ObjectId, tagId);
        }

        if (result == false)
        {
            _allTags.Find(t => t.Id.Equals(tagId))!.IsChecked = isChecked;
            await InvokeAsync(StateHasChanged);
        }
    }
}
