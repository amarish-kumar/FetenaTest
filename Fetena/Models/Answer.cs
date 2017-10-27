using System;
using System.ComponentModel.DataAnnotations;
using System.Security.AccessControl;

namespace Fetena.Models
{
    public class Answer : IDateTimeStamp
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public string SelectedAnswer { get; set; }

        public int Score { get; set; }

        [Required]
        public int QuizId { get; set; }

        public Quiz Quiz { get; set; }

        public DateTime DateAdded { get; set; }

        public DateTime DateModified { get; set; }

    }
}