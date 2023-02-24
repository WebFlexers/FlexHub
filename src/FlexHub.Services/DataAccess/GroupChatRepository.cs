﻿using FlexHub.Data;
using FlexHub.Data.DTOs;
using FlexHub.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FlexHub.Services.DataAccess;

public class GroupChatRepository
{
    private readonly ILogger<GroupChatRepository> _logger;
    private readonly ApplicationDbContext _dbContext;

    public GroupChatRepository(ILogger<GroupChatRepository> logger, ApplicationDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    /// <summary>
    /// Gets the group chats of the given user
    /// whose title contains the given title asynchronously
    /// </summary>
    public async Task<List<GroupChatDTO>> GetGroupChatsFilteredByName(string userObjectId, string groupChatTitle)
    {
        try
        {
            var groupChats = await _dbContext.UsersGroupChats
                .Where(groupChat => groupChat.UserObjectId == userObjectId && groupChat.GroupChat.Title.Contains(groupChatTitle))
                .Select(groupChat => new GroupChatDTO
                {
                    Id = groupChat.GroupChat.Id,
                    Title = groupChat.GroupChat.Title,
                    CreatedAt = groupChat.GroupChat.CreatedAt,
                    UpdatedAt = groupChat.GroupChat.UpdatedAt
                }).ToListAsync();

            return groupChats;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Failed to get group chats filtered by name");

            return default;
        }

        throw new NotImplementedException();
    }

    /// <summary>
    /// Gets X number of messages that were sent to the given group chat
    /// paginated and sorted by time descending asynchronously
    /// </summary>
    /// <param name="groupChatId">The group chat id</param>
    /// <param name="pageNumber">The page number of the pagination</param>
    /// <param name="numberOfMessagesToLoad">The number of messages to load</param>
    public async Task<List<GroupMessageDTO>> GetSortedGroupMessagesPaginated(
        int groupChatId, int pageNumber, int numberOfMessagesToLoad)
    {
        throw new NotImplementedException();
    }

    /// <summary>
    /// Stores a message sent by the sender user to the group chat asynchronously
    /// </summary>
    /// <returns>True if the operation is successful and false if it fails</returns>
    public async Task<bool> StoreGroupMessage(string senderUserObjectId, int groupChatId, string message)
    {
        throw new NotImplementedException();
    }
}
