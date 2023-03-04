using FlexHub.BlazorServer.Stores.AuthToken;
using FlexHub.BlazorServer.Stores.Search;
using FlexHub.Services.DataAccess;
using FlexHub.Services.DataAccess.Interfaces;
using MatBlazor;

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

    public static void AddMatBlazorServices(this WebApplicationBuilder builder)
    {
        builder.Services.AddMatBlazor();
        builder.Services.AddMatToaster(config =>
        {
            config.Position = MatToastPosition.BottomCenter;
            config.PreventDuplicates = true;
            config.NewestOnTop = true;
            config.ShowCloseButton = true;
            config.MaximumOpacity = 95;
            config.VisibleStateDuration = 3000;
        });
    }

    public static void AddStores(this WebApplicationBuilder builder)
    {
        builder.Services.AddScoped<ISearchPostsTermsStore, SearchPostsTermsStore>();
        builder.Services.AddScoped<IUserInfoStore, UserInfoStore>();
    }
}