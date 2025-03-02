using System;

namespace Osprey3.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; } // Ensure to handle this securely in your application

        public DateTime CreatedDate { get; set; }

        public User()
        {
            CreatedDate = DateTime.UtcNow; // Set the CreatedDate to the current UTC time
        }
    }
}
