using System;
using MediatR;
using Filters.Domain;
using System.Threading;
using System.Threading.Tasks;
using Filters.Application.Interfaces;

namespace Filters.Application.Filters.Commands.CreateFilter
{
    public class CreateFilterCommandHandler : IRequestHandler<CreateFilterCommand, Guid>
    {
        private readonly IFilterDbContext _dbContext;   
        public CreateFilterCommandHandler(IFilterDbContext dbContext) => _dbContext = dbContext;
        public async Task<Guid> Handle(CreateFilterCommand request, CancellationToken cancellationToken)
        {
            var filter = new Filter
            {
                FilterId = Guid.NewGuid(),
                ModelFilter = request.ModelFilter,
                ActiveAreaSectional = request.ActiveAreaSectional,
                TotalAreaSectional = request.TotalAreaSectional,
                FilterLength = request.FilterLength,
                FilterWidth = request.FilterWidth,
                FilterHeight = request.FilterHeight,
                FilterWeight = request.FilterWeight
            };
            await _dbContext.Filters.AddAsync(filter, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return filter.FilterId;
        }
    }
}