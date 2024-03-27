using System;
using MediatR;

namespace Filters.Application.Filters.Queries.GetFilterDetails
{
    public class GetFilterDetailsQuery : IRequest<FilterDetailsVm>
    {
        public Guid FilterId { get; set; }
    }
}
