namespace Restful_Api1.Models
{
    public class User
    {

            public int Id { get; set; }

            public string Username { get; set; } = null!;

            // Stored as HASH, never plain text
            public string PasswordHash { get; set; } = null!;

            // Simple role-based auth
            // e.g. "Admin", "User"
            public string Role { get; set; } = "User";
        }

    }

