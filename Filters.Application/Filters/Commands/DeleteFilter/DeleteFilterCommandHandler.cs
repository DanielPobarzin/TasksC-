using MediatR;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Filters.Application.Interfaces;
using Filters.Application.Common.Exceptions;
using Filters.Domain;
namespace Filters.Application.Filters.Commands.DeleteFilter
{
    public class DeleteFilterCommandHandler
        : IRequestHandler<DeleteFilterCommand>
    {
        private readonly IFilterDbContext _dbContext;

        public DeleteFilterCommandHandler(IFilterDbContext dbContext) => _dbContext = dbContext;

        public async Task Handle (DeleteFilterCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Filters.FindAsync(new object[] { request.FilterId }, cancellationToken);

            if (entity != null) 
            {
                throw new NotFoundException(nameof(Filter), request.FilterId);

            }

            _dbContext.Filters.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return;

        }
    }
}
