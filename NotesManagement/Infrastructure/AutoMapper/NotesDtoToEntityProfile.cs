using AutoMapper;
using Domain.DTO;
using Infrastructure.Entities;

namespace Infrastructure.AutoMapper
{
    public class NotesDtoToEntityProfile : Profile
    {
        public NotesDtoToEntityProfile()
        { 
             CreateMap<NoteDto, Note>();
        }
    }
}
