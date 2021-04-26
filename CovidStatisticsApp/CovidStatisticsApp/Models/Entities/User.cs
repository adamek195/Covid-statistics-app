using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
