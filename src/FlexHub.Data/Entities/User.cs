namespace FlexHub.Data.Entities;

public class User
{
    public string ObjectId { get; set; }
    public string EmailAddress { get; set; }
    public string GivenName { get; set; }
    public string Surname { get; set; }
    public string DisplayName { get; set; }
    public string Country { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

    public HashSet<Contact> Contacts { get; set; }
    public HashSet<ContactRequest> ContactRequests { get; set; }
    public List<Post> Posts { get; set; }
    public HashSet<UserGroupChat> GroupChatsUsers { get; set; }
    public List<DirectMessage> DirectMessages { get; set; }
}
