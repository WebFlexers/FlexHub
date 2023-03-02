using FlexHub.BlazorServer.Stores.AuthToken;
using FlexHub.BlazorServer.Stores.Search;
using FlexHub.Services.DataAccess;
using FlexHub.Services.DataAccess.Interfaces;
using Radzen;

namespace FlexHub.BlazorServer.StartupConfig;

public static class DependencyInjectionExtensions
{
    public static void AddRepositoryServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddTransient<IDirectMessageRepository, DirectMessageRepository>();
        builder.Services.AddTransient<IGroupChatRepository, GroupChatRepository>();
        builder.Services.AddTransient<IPostRepository, PostRepository>();
        builder.Services.AddTransient<ITagRepository, TagRepository>();
        builder.Services.AddTransient<IUserRepository, UserRepository>();
    }

    public static void AddRadzen(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<DialogService>();
        builder.Services.AddScoped<NotificationService>();
        builder.Services.AddScoped<TooltipService>();
        builder.Services.AddScoped<ContextMenuService>();
    }

    public static void AddStores(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISearchPostsTermsStore, SearchPostsTermsStore>();
        builder.Services.AddScoped<IUserInfoStore, UserInfoStore>();
    }
}