using MediatR;
using System;


namespace Filters.Application.Filters.Queries.GetFilterList
{
    public class GetFilterListQuery : IRequest <FilterListVm>
    {
        public string ModelFilter { get; set; }
    }
}
