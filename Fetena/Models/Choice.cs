using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Fetena.Models
{
    public class Choice : IDateTimeStamp
    {
        public int Id { get; set; }

        [Required]
        public string PossibleAnswer { get; set; }

        [Required]
        public int QuizId { get; set; }

        public Quiz Quiz { get; set; }

        public DateTime DateAdded { get; set; }
        public DateTime DateModified { get; set; }
    }
}