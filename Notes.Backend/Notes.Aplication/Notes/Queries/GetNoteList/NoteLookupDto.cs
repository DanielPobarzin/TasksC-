using System;
using AutoMapper;
using Notes.Aplication.Common.Mappings;
using Notes.Domain;
using MediatR;


namespace Notes.Aplication.Notes.Queries.GetNoteList
{

    public class NoteLookupDto : IMapWith<Note>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }  
        public void Mappping(Profile profile)
        {
            profile.CreateMap<Note, NoteLookupDto>()
                .ForMember(noteDto => noteDto.Id,
                opt => opt.MapFrom(note => note.Id))
                .ForMember(noteDto => noteDto.Title,
                opt => opt.MapFrom(note => note.Title));

        }
    }
}
