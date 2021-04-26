using System;
using System.ComponentModel.DataAnnotations;

namespace CovidStatisticsApp.Models.Entities
{
    /// <summary>
    /// Model of user in database
    /// </summary>
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(64)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(64)]
        public string Password { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string Email { get; set; }

    }
}
