using FlexHub.Data.Entities;
using Microsoft.EntityFrameworkCore.Metadata;

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

    public override bool Equals(object obj)
    {
        if (obj == null) return false;

        if (typeof(UserDTO) == obj.GetType())
        {
            var userDTO = (UserDTO) obj;
            return userDTO == this;
        }

        if (obj.GetType() == typeof(UserDTO))
        {
            var user = (User)obj;

            return user.ObjectId == this.ObjectId && user.EmailAddress == this.EmailAddress &&
                   user.GivenName == this.GivenName &&
                   user.Surname == this.Surname && user.DisplayName == this.DisplayName && user.Country == this.Country;
        }

        return false;
    }
}
