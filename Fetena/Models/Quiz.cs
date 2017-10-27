using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Fetena.Models
{
    public class Quiz : IDateTimeStamp
    {
        public Quiz()
        {
            Choices = new List<Choice>();
        }
        public int Id { get; set; }

        public Language Language { get; set; }

        [Required]
        public int LanguageId { get; set; }

        public Level Level { get; set; }

        [Required]
        public int LevelId { get; set; }

        public Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Required]
        public string Question { get; set; }

        [Required]
        [StringLength(1)]
        public string CorrectAnswer { get; set; }

        public string Feedback { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }

        public ICollection<Choice> Choices { get; set; }

    }
}