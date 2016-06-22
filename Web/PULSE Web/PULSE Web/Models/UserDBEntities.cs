using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;

namespace PULSE_Web.Models
{
    public class UserDBEntities : DbContext
    {
        public UserDBEntities() : base("name=PULSEUserDB")
        {
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Device> Devices { get; set; }
    }

    public class User
    {
        [Key]
        public string Username { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNum { get; set; }
        public string PasswordHash { get; set; }
        public virtual ICollection<Device> Devices { get; set; }
    }

    public class Device
    {
        [Key]
        public string PublicKey { get; set; }
    }
}