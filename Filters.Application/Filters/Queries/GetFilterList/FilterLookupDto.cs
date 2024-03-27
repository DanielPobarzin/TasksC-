using System;
using AutoMapper;
using Filters.Application.Common.Mappings;
using Filters.Domain;

namespace Filters.Application.Filters.Queries.GetFilterList
{
    public class FilterLookupDto : IMapWith<Filter>
    {
        public Guid FilterId { get; set; }
        public string ModelFilter { get; set; }

        public void Mapping (Profile profile)
        {
            profile.CreateMap<Filter, FilterLookupDto>()
                .ForMember(filterDto => filterDto.FilterId,
                    opt => opt.MapFrom(filter => filter.FilterId))
                .ForMember(filterDto => filterDto.ModelFilter,
                    opt => opt.MapFrom(filter => filter.ModelFilter));
        }
    }
}
