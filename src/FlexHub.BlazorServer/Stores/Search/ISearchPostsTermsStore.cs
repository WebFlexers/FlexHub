using FlexHub.BlazorServer.Models;

namespace FlexHub.BlazorServer.Stores.Search;

public interface ISearchPostsTermsStore
{
    string? SearchText { get; set; }
    List<TagModel>? Tags { get; set; }
    SearchBy LastSearch { get; set; }

    /// <summary>
    /// Calculates whether the search should contain a search text, tags, both or none
    /// </summary>
    /// <returns>The search mode</returns>
    SearchBy GetSearchMode();
}