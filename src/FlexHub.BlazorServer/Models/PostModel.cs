﻿using FlexHub.Data.DTOs;

namespace FlexHub.BlazorServer.Models;

public class PostModel
{
    public int Id { get; set; }
    public string? PublisherDisplayName { get; set; }
    public string? Title { get; set; }
    public string? Content { get; set; }
    public string? CreatedAt { get; set; }
    public List<TagDTO>? Tags { get; set; }
}
