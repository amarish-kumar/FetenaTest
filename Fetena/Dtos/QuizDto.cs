using Fetena.Models;
using System.Collections.Generic;

namespace Fetena.Dtos
{
    public class QuizDto
    {
        public QuizDto()
        {
            Choices = new List<ChoiceDto>();
        }
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public LanguageDto Language { get; set; }

        public int LevelId { get; set; }

        public LevelDto Level { get; set; }

        public int CategoryId { get; set; }

        public CategoryDto Category { get; set; }

        public string Question { get; set; }

        public string CorrectAnswer { get; set; }

        public string Feedback { get; set; }

        public ICollection<ChoiceDto> Choices { get; set; }

    }
}