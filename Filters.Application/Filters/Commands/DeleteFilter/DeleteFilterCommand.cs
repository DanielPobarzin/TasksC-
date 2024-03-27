using System;
using MediatR;


namespace Filters.Application.Filters.Commands.DeleteFilter
{
    public class DeleteFilterCommand : IRequest
    {
        public Guid FilterId { get; set; }
    }
}
