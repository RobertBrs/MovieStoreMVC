using System;
using System.ComponentModel.DataAnnotations;

namespace MovieStoreMVC.Models
{
    public class Movie
    {
        [Key]
        public int MovieId { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        public string Genre { get; set; }

        [Required]
        [Range(1900, 2100)]
        public int Year { get; set; }

        [Required]
        [StringLength(200)]
        public string Director { get; set; }

        [Required]
        [Range(1, 300)]
        public int Duration { get; set; } // Duration in minutes

        [Required]
        [Range(0, 1000)]
        public decimal Price { get; set; }

        [StringLength(2048)]
        public string ImageUrl { get; set; } // Optional image URL
    }
}
