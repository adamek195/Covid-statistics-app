using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
