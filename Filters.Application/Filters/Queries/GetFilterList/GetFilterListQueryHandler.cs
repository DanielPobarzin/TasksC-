using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Filters.Application.Interfaces;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using AutoMapper.QueryableExtensions;

namespace Filters.Application.Filters.Queries.GetFilterList
{
    public class GetFilterListQueryHandler
        : IRequestHandler<GetFilterListQuery, FilterListVm>    
    {
        private readonly IFilterDbContext _dbContext;
        private readonly IMapper _mapper;

        public async Task<FilterListVm> Handle(GetFilterListQuery request, CancellationToken cancellationToken)
        {
            var filterQuery = await _dbContext.Filters
                .Where(filter => filter.ModelFilter == request.ModelFilter)
                .ProjectTo<FilterLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new FilterListVm { Filters = filterQuery };
        }

    }
}
