using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Filters.Application.Interfaces;
using Filters.Domain;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using Filters.Application.Common.Exceptions;

namespace Filters.Application.Filters.Queries.GetFilterDetails
{
    public class GetFilterDetailsQueryHandler : IRequestHandler<GetFilterDetailsQuery, FilterDetailsVm>
    {
        private readonly IFilterDbContext _dbContext;
        private readonly IMapper _mapper;
        public GetFilterDetailsQueryHandler( IFilterDbContext dbContext, IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<FilterDetailsVm> Handle (GetFilterDetailsQuery request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Filters
                .FirstOrDefaultAsync(filter => 
                filter.FilterId == request.FilterId, cancellationToken);
            if (entity == null)
            {
                throw new NotFoundException(nameof(Filter), request.FilterId);
            }

            return _mapper.Map<FilterDetailsVm>(entity);   
        }


    }
}
