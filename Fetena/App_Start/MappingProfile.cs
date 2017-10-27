using AutoMapper;
using Fetena.Dtos;
using Fetena.Models;

namespace Fetena.App_Start
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            Mapper.CreateMap<Language, LanguageDto>();
            Mapper.CreateMap<Level, LevelDto>();
            Mapper.CreateMap<Category, CategoryDto>();
            Mapper.CreateMap<Quiz, QuizDto>();
            Mapper.CreateMap<Choice, ChoiceDto>();
            Mapper.CreateMap<Answer, AnswerDto>();

            Mapper.CreateMap<LanguageDto, Language>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<LevelDto, Level>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<CategoryDto, Category>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<QuizDto, Quiz>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<ChoiceDto, Choice>()
                .ForMember(m => m.Id, opt => opt.Ignore());
            Mapper.CreateMap<AnswerDto, Answer>()
                .ForMember(m => m.Id, opt => opt.Ignore());
        }
    }
}