using Fetena.Models;

namespace Fetena.Dtos
{
    public class ChoiceDto
    {
        public int Id { get; set; }

        public string PossibleAnswer { get; set; }

        public int QuizId { get; set; }

    }
}