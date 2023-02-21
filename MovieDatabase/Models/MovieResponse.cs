using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MovieDatabase.Models
{
    public class MovieResponse
    {
        [Key]
        [Required]
        public int MovieID { get; set; }

        [Required(ErrorMessage = "Movie Title is Required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Year of Release is Required")]
        public int Year { get; set; }

        [Required(ErrorMessage = "Director's name is Required")]
        public string Director { get; set; }

        [Required]
        public string Rating { get; set; }

        public bool Edited { get; set; }

        public string Lent { get; set; }

        [StringLength(25)]
        public string Notes { get; set; }


        //Foreign Key relationship
        [Required(ErrorMessage = "Movie Category is Required")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
    }
}
