using System;
using System.ComponentModel.DataAnnotations;

namespace CovidStatisticsApp.Models.Entities
{
    /// <summary>
    /// Model of country in database
    /// </summary>
    public class Country
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(64)]
        public string Name { get; set; }
    }
}
