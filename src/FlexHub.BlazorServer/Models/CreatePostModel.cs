using System.ComponentModel.DataAnnotations;

namespace FlexHub.BlazorServer.Models;

public class CreatePostModel
{
    [Required]
    [StringLength(40, MinimumLength = 1, ErrorMessage = "The title can be 40 characters maximum")]
    public string? Title { get; set; }
    [Required]
    [StringLength(4000, MinimumLength = 1, ErrorMessage = "The content of your post can't be more than 4000 characters")]
    public string? Content { get; set; }
}
