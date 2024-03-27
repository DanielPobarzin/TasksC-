using Filters.Application.Common.Mappings;
using System;
using Filters.Domain;
using AutoMapper;

namespace Filters.Application.Filters.Queries.GetFilterDetails
{
    public class FilterDetailsVm : IMapWith<Filter>
    {
        public Guid FilterId { get; set; }
        public string ModelFilter { get; set; }
        public double ActiveAreaSectional { get; set; }
        public double TotalAreaSectional { get; set; }
        public double FilterLength { get; set; }
        public double FilterWidth { get; set; }
        public double FilterHeight { get; set; }
        public double FilterWeight { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<Filter, FilterDetailsVm>()
                .ForMember(filterVm => filterVm.FilterId,
                    opt => opt.MapFrom(filter => filter.FilterId))
                .ForMember(filterVm => filterVm.ModelFilter,
                    opt => opt.MapFrom(filter => filter.ModelFilter))
                .ForMember(filterVm => filterVm.ActiveAreaSectional,
                    opt => opt.MapFrom(filter => filter.ActiveAreaSectional))
                .ForMember(filterVm => filterVm.TotalAreaSectional,
                    opt => opt.MapFrom(filter => filter.TotalAreaSectional))
                .ForMember(filterVm => filterVm.FilterLength,
                    opt => opt.MapFrom(filter => filter.FilterLength))
                .ForMember(filterVm => filterVm.FilterWidth,
                    opt => opt.MapFrom(filter => filter.FilterWidth))
                .ForMember(filterVm => filterVm.FilterHeight,
                    opt => opt.MapFrom(filter => filter.FilterHeight))
                .ForMember(filterVm => filterVm.FilterWeight,
                    opt => opt.MapFrom(filter => filter.FilterWeight));

        }

    }
}
