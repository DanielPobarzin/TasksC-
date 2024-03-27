using Filters.Application.Interfaces;
using MediatR;
using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Filters.Application.Common.Exceptions;
using Filters.Domain;

namespace Filters.Application.Filters.Commands.UpdateFilter
{
    public class UpdateFilterCommandHandler : IRequestHandler<UpdateFilterCommand>
    {
        private readonly IFilterDbContext _DbContext;

        public UpdateFilterCommandHandler(IFilterDbContext dbContext) => _DbContext = dbContext;

        public async Task Handle (UpdateFilterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _DbContext.Filters.FirstOrDefaultAsync(filter => filter.FilterId == request.FilterId, cancellationToken);

            if  (entity == null || entity.ModelFilter != request.ModelFilter)
            {
                throw new NotFoundException(nameof(Filter), request.FilterId);
                
            }
            entity.ModelFilter = request.ModelFilter;
            entity.ActiveAreaSectional = request.ActiveAreaSectional;
            entity.TotalAreaSectional = request.TotalAreaSectional;
            entity.FilterLength = request.FilterLength;
            entity.FilterWidth = request.FilterWidth;
            entity.FilterHeight = request.FilterHeight;
            entity.FilterWeight = request.FilterWeight;
            await _DbContext.SaveChangesAsync(cancellationToken);

            return;
        }
    }
}
