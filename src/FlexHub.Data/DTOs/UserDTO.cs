namespace FlexHub.Data.DTOs;

public class UserDTO
{
    public string ObjectId { get; set; }
    public string EmailAddress { get; set; }
    public string GivenName { get; set; }
    public string Surname { get; set; }
    public string DisplayName { get; set; }
    public string Country { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
