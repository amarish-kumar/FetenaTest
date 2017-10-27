using Fetena.Models;
using System;
using System.Security.AccessControl;

namespace Fetena.Dtos
{
    public class AnswerDto
    {
       // public int Id { get; set; }

        public string UserId { get; set; }

        public string SelectedAnswer { get; set; }

        public int Score { get; set; }

       // public DateTime DateAdded { get; set; }

        public int QuizId { get; set; }

        //public QuizDto Quiz { get; set; }

    }
}