﻿using FlexHub.BlazorServer.Models;

namespace FlexHub.BlazorServer.Stores.Search;

public class SearchPostsTermsStore : ISearchPostsTermsStore
{
    public string? SearchText { get; set; }
    public List<TagModel>? Tags { get; set; }

    public SearchBy LastSearch { get; set; } = SearchBy.None;

    /// <summary>
    /// Calculates whether the search should contain a search text, tags, both or none
    /// </summary>
    /// <returns>The search mode</returns>
    public SearchBy GetSearchMode()
    {
        var areAnyTagsSelected = Tags is not null && Tags.Any(tm => tm.IsChecked);

        if (string.IsNullOrWhiteSpace(SearchText) && areAnyTagsSelected.Equals(false))
        {
            return SearchBy.None;
        }

        if (string.IsNullOrWhiteSpace(SearchText) && areAnyTagsSelected)
        {
            return SearchBy.Tags;
        }

        if (string.IsNullOrWhiteSpace(SearchText).Equals(false) && areAnyTagsSelected.Equals(false))
        {
            return SearchBy.SearchText;
        }

        return SearchBy.SearchTextAndTags;
    }
}