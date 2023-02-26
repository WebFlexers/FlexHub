using System.Globalization;
using System;
using System.Text;
using Bogus;
using Bogus.DataSets;
using FlexHub.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace FlexHub.Data.Seeding;

public class SampleData
{
#pragma warning disable IDE1006
    private const int SeedNumber = 869236954;
    private const int ReferenceYear = 2023;
    private const int ReferenceMonth = 2;
    private const int ReferenceDay = 22;
#pragma warning restore IDE1006

    private readonly Random _random = new(SeedNumber);
    private readonly DateTime _referenceDateTime = new(ReferenceYear, ReferenceMonth, ReferenceDay);


    public static readonly string[] UserObjectIds = new[]
    {
        "88906cdb-ff0d-4031-9276-aaab0f9b5d8c",
        "ea664eff-c559-4f93-a794-ae26e5824ed3",
        "a26d0ee1-33b5-44da-9cbd-c472aeeb0c75",
        "a57f05c2-5bb5-4d58-bf10-077f7cb57ca5",
        "0b57deac-0d84-49bf-a0ba-a28138fade8d",
        "da8dfa3d-24a7-4198-b28a-36a716616107",
        "9ce0c17e-47ba-4c14-a23a-7cc5de96d64a",
        "269cf1a3-b20e-405d-863b-f8a427615294",
        "be9b6864-5ad9-412b-8ba5-2fb9fd79e522",
        "fd77f7d0-b55f-4485-bef4-c4d14cb47fe7"
    };

    public static string[] TagsStrings = new[]
    {
        "Science", "Music", "History", "Mathematics", "Literature", "Geography", 
        "Philosophy", "Art", "Religion", "Sports", "Technology", "Economics", "Political Science"
    };

    private List<Contact> _contacts = new();
    private List<ContactRequest> _contactRequests = new();
    private List<DirectMessage> _directMessages = new();
    private List<GroupChat> _groupChats = new();
    private List<GroupMessage> _groupMessages = new();
    private List<Post> _posts = new();
    private List<PostTag> _postTags = new();
    private List<Tag> _tags = new();
    private List<User> _users = new();
    private List<UserGroupChat> _userGroupChats = new();
    private List<UserTag> _userTags = new();

    public void Seed(ModelBuilder modelBuilder)
    {
        //if (System.Diagnostics.Debugger.IsAttached == false)
        //{
        //    System.Diagnostics.Debugger.Launch();
        //}

        Randomizer.Seed = _random;
        Date.SystemClock = () => new DateTime(ReferenceYear, ReferenceMonth, ReferenceDay);

        CreateUsers();
        CreatePosts();
        CreateTags();
        CreatePostsTags();
        CreateUsersTags();
        CreateGroupChats();
        CreateUserGroupChats();
        CreateGroupMessages();
        CreateContacts();
        CreateContactRequests();
        CreateDirectMessages();

        CreateExtraData();

        modelBuilder.Entity<User>().HasData(_users);
        modelBuilder.Entity<Tag>().HasData(_tags);
        modelBuilder.Entity<Post>().HasData(_posts);
        modelBuilder.Entity<PostTag>().HasData(_postTags);
        modelBuilder.Entity<UserTag>().HasData(_userTags);
        modelBuilder.Entity<GroupChat>().HasData(_groupChats);
        modelBuilder.Entity<UserGroupChat>().HasData(_userGroupChats);
        modelBuilder.Entity<GroupMessage>().HasData(_groupMessages);
        modelBuilder.Entity<Contact>().HasData(_contacts);
        modelBuilder.Entity<ContactRequest>().HasData(_contactRequests);
        modelBuilder.Entity<DirectMessage>().HasData(_directMessages);
    }

    private void CreateExtraData()
    {
        List<Post> posts = new List<Post>()
        {
            new Post
            {
                Id = 350,
                Title = "Post 350",
                Content = "Lorem ipsum dolor sit amet",
                UserObjectId = SampleData.UserObjectIds.First(),
            },
            new Post
            {
                Id = 956,
                Title = "Post 956",
                Content = "Lorem ipsum dolor sit amet",
                UserObjectId = SampleData.UserObjectIds.First(),
            },
            new Post
            {
                Id = 876,
                Title = "Post 876",
                Content = "Lorem ipsum dolor sit amet",
                UserObjectId = SampleData.UserObjectIds.Last(),
            },
        };

        List<PostTag> postTags = new List<PostTag>()
        {
            new PostTag() { PostId = posts[0].Id, TagId = 4 },
            new PostTag() { PostId = posts[0].Id, TagId = 10 },
            new PostTag() { PostId = posts[1].Id, TagId = 4 },
            new PostTag() { PostId = posts[1].Id, TagId = 10 },
            new PostTag() { PostId = posts[2].Id, TagId = 4 },
            new PostTag() { PostId = posts[2].Id, TagId = 10 },
            new PostTag() { PostId = posts[2].Id, TagId = 3 },
        };

        _posts.AddRange(posts);
        _postTags.AddRange(postTags);
    }

    private void CreateContactRequests()
    {
        _contactRequests = new List<ContactRequest>()
        {
            new ContactRequest() {SenderUserObjectId = _users[0].ObjectId, ReceiverUserObjectId = _users[1].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[0].ObjectId, ReceiverUserObjectId = _users[2].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[0].ObjectId, ReceiverUserObjectId = _users[3].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[0].ObjectId, ReceiverUserObjectId = _users.Last().ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[1].ObjectId, ReceiverUserObjectId = _users[0].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[1].ObjectId, ReceiverUserObjectId = _users[2].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[1].ObjectId, ReceiverUserObjectId = _users[3].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[1].ObjectId, ReceiverUserObjectId = _users[6].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[2].ObjectId, ReceiverUserObjectId = _users[4].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[2].ObjectId, ReceiverUserObjectId = _users[1].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[4].ObjectId, ReceiverUserObjectId = _users[3].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[4].ObjectId, ReceiverUserObjectId = _users[5].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users[4].ObjectId, ReceiverUserObjectId = _users[1].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users.Last().ObjectId, ReceiverUserObjectId = _users[6].ObjectId},
            new ContactRequest() {SenderUserObjectId = _users.Last().ObjectId, ReceiverUserObjectId = _users[2].ObjectId},
        };
    }

    public void CreateUsers()
    {
        int objectIdIndex = 0;

        var userFaker = new Faker<User>(locale: "en_US")
            .CustomInstantiator(f =>
            {
                var updatedAt = f.Date.Past().ToUniversalTime();

                var user = new User
                {
                    ObjectId = UserObjectIds[objectIdIndex],
                    EmailAddress = f.Person.Email,
                    GivenName = f.Person.FirstName,
                    Surname = f.Person.LastName,
                    DisplayName = f.Person.UserName,
                    Country = "USA",
                    CreatedAt = updatedAt.Subtract(TimeSpan.FromDays(1)),
                    UpdatedAt = updatedAt
                };

                objectIdIndex++;

                return user;
            });

        var generatedUsers = AssociateRandomUsersWithRealAccounts(userFaker.Generate(UserObjectIds.Length));

        _users.AddRange(generatedUsers);
    }

    public List<User> AssociateRandomUsersWithRealAccounts(List<User> users)
    {
        // Michalis
        DateTime.TryParseExact("2023-02-26 18:36:02.0000000", "yyyy-MM-dd HH:mm:ss.fffffff",
            CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var dateTimeMichalis);

        users.ElementAt(0).ObjectId = "88906cdb-ff0d-4031-9276-aaab0f9b5d8c";
        users.ElementAt(0).EmailAddress = "maik.stylianidis@gmail.com";
        users.ElementAt(0).GivenName = "Michail";
        users.ElementAt(0).Surname = "Stylianidis";
        users.ElementAt(0).DisplayName = "StyleM";
        users.ElementAt(0).Country = "Greece";
        users.ElementAt(0).CreatedAt = dateTimeMichalis.ToUniversalTime();
        users.ElementAt(0).UpdatedAt = dateTimeMichalis.ToUniversalTime();

        // Lefteris

        // Kostas

        return users;
    }

    public void CreateTags()
    {
        int tagId = 1;

        foreach (var tag in TagsStrings)
        {
            _tags.Add(new Tag
            {
                Id = tagId++,
                Value = tag
            });
        }
    }

    private readonly string[] feelingIndicatingWords = new[]
    {
        "I Love ",
        "I Hate " ,
        "I Like " ,
        "I Dislike ",
        "I Crave ",
        "I Adore ",
        "I Worship "
    };

    public void CreatePosts()
    {
        int postId = 1;

        var postFaker = new Faker<Post>(locale: "en_US")
            .CustomInstantiator(f =>
            {
                var updatedAt = f.Date.Past().ToUniversalTime();

                var post = new Post
                {
                    Id = postId++,
                    Title = f.PickRandom(feelingIndicatingWords) + f.Commerce.ProductName() + "!",
                    Content = f.Lorem.Paragraphs(count: f.Random.Int(1, 4)),
                    CreatedAt = updatedAt.Subtract(TimeSpan.FromDays(1)),
                    UpdatedAt = updatedAt,
                    UserObjectId = f.PickRandom(UserObjectIds)
                };

                return post;
            });

        _posts.AddRange(postFaker.Generate(UserObjectIds.Length * 8));
    }

    public void CreatePostsTags()
    {
        foreach (var post in _posts)
        {
            var tagsTemp = _tags.ToList();

            for (int i = 0; i < _random.Next(1, tagsTemp.Count); i++)
            {
                int tagId = tagsTemp.ElementAt(_random.Next(1, tagsTemp.Count)).Id;

                _postTags.Add(new PostTag
                {
                    PostId = post.Id,
                    TagId = tagId,
                });

                tagsTemp.Remove(tagsTemp.Find(t => t.Id.Equals(tagId)));
            }
        }
    }

    public void CreateUsersTags()
    {
        foreach (var user in _users)
        {
            var tagsTemp = _tags.ToList();

            for (int i = 0; i < _random.Next(1, tagsTemp.Count); i++)
            {
                int tagId = tagsTemp.ElementAt(_random.Next(1, tagsTemp.Count)).Id;

                _userTags.Add(new UserTag
                {
                    UserObjectId = user.ObjectId,
                    TagId = tagId,
                });

                tagsTemp.Remove(tagsTemp.Find(t => t.Id.Equals(tagId)));
            }
        }
    }

    public void CreateGroupChats()
    {
        int groupId = 1;

        var groupChatsFaker = new Faker<GroupChat>()
            .CustomInstantiator(f =>
            {
                var updatedAt = f.Date.Past().ToUniversalTime();

                var groupChat = new GroupChat
                {
                    Id = groupId++,
                    Title = $"The {f.Commerce.ProductMaterial()} Heads Chat",
                    CreatedAt = updatedAt.Subtract(TimeSpan.FromDays(1)),
                    UpdatedAt = updatedAt,
                };

                return groupChat;
            });

        // Divide by 3 to create fewer groups than users
        _groupChats.AddRange(groupChatsFaker.Generate(_users.Count / 3));
    }

    public void CreateUserGroupChats()
    {
        var usersPerGroupChat = _users.Count / _groupChats.Count;
        var usersCounter = 0;
        var groupChatId = 1;

        for (int userIndex = 0; userIndex < _users.Count; userIndex++)
        {
            // If we are at the last group don't reset the usersCounter
            // and keep adding to the same group chat
            bool isTheLastGroupChat = userIndex + 1 > usersPerGroupChat * _groupChats.Count;

            usersCounter++;

            if (usersCounter > usersPerGroupChat && isTheLastGroupChat == false)
            {
                usersCounter = 1;
                groupChatId++;
            }

            _userGroupChats.Add(new UserGroupChat
            {
                UserObjectId = _users[userIndex].ObjectId,
                GroupChatId = groupChatId,
            });


        }
    }

    public void CreateGroupMessages()
    {
        var oneYearAgo = _referenceDateTime.Subtract(TimeSpan.FromDays(365)).ToUniversalTime();
        var numberOfMinutesToAdd = TimeSpan.Zero;
        int groupMessageId = 1;

        int groupChatId = 1;

        var groupMessageFaker = new Faker<GroupMessage>()
            .CustomInstantiator(f =>
            {
                groupChatId++;

                if (groupChatId > _groupChats.Count)
                {
                    groupChatId = 1;
                }

                numberOfMinutesToAdd = numberOfMinutesToAdd.Add(TimeSpan.FromMinutes(5));

                List<string> idsOfGroupUsers = _userGroupChats
                    .Where(ugc => ugc.GroupChatId.Equals(groupChatId))
                    .Select(ugc => ugc.UserObjectId)
                    .ToList();

                var words = f.Lorem.Words(f.Random.Int(3, 15));
                var messageBuilder = new StringBuilder();
                foreach (var word in words)
                {
                    messageBuilder.Append(word);
                    messageBuilder.Append(" ");
                }

                var message = new GroupMessage
                {
                    Id = groupMessageId++,
                    Message = messageBuilder.ToString(),
                    CreatedAt = oneYearAgo.Add(numberOfMinutesToAdd),
                    SenderUserObjectId = f.PickRandom(idsOfGroupUsers),
                    GroupChatId = groupChatId,
                };

                return message;
            });

        _groupMessages.AddRange(groupMessageFaker.Generate(_users.Count * 20));
    }

    public void CreateContacts()
    {
        var oneYearAgo = _referenceDateTime.Subtract(TimeSpan.FromDays(365)).ToUniversalTime();
        var numberOfMinutesToAdd = TimeSpan.Zero;

        foreach (var user in _users)
        {
            numberOfMinutesToAdd = numberOfMinutesToAdd.Add(TimeSpan.FromMinutes(5));

            for (int i = 0; i < _random.Next(2, 5); i++)
            {             
                User randomUser;

                do
                {
                    randomUser = _users.ElementAt(_random.Next(0, _users.Count));
                } while 
                    (randomUser != user 
                    && _contacts.Any(contact => 
                        (contact.UserObjectId == user.ObjectId && contact.ContactObjectId == randomUser.ObjectId) ||
                        contact.UserObjectId == randomUser.ObjectId && contact.ContactObjectId == user.ObjectId));
              
                _contacts.Add(new Contact
                {
                    UserObjectId = user.ObjectId,
                    ContactObjectId = randomUser.ObjectId,
                    CreatedAt = oneYearAgo.Add(numberOfMinutesToAdd),
                });
            }
        }
    }

    public void CreateDirectMessages()
    {
        var oneYearAgo = _referenceDateTime.ToUniversalTime();
        var numberOfMinutesToAdd = TimeSpan.Zero;
        var directMessageId = 1;

        var directMessageFaker = new Faker<DirectMessage>()
            .CustomInstantiator(f =>
            {
                numberOfMinutesToAdd = numberOfMinutesToAdd.Add(TimeSpan.FromMinutes(5));

                var words = f.Lorem.Words(f.Random.Int(3, 15));
                var messageBuilder = new StringBuilder();
                foreach (var word in words)
                {
                    messageBuilder.Append(word);
                    messageBuilder.Append(' ');
                }

                string senderUserId;
                string receiverUserId;

                do
                {
                    var randomContact = f.PickRandom(_contacts);
                    if (f.Random.Bool())
                    {
                        senderUserId = randomContact.UserObjectId;
                        receiverUserId = randomContact.ContactObjectId;
                    }
                    else
                    {
                        senderUserId = randomContact.ContactObjectId;
                        receiverUserId = randomContact.UserObjectId;
                    }
                } while (senderUserId == receiverUserId);

                var directMessage = new DirectMessage
                {
                    Id = directMessageId++,
                    Message = messageBuilder.ToString(),
                    CreatedAt = oneYearAgo.Add(numberOfMinutesToAdd),
                    SenderUserObjectId = senderUserId,
                    ReceiverUserObjectId = receiverUserId,
                };

                return directMessage;
            });

        _directMessages.AddRange(directMessageFaker.Generate(_users.Count * 35));
    }
}
