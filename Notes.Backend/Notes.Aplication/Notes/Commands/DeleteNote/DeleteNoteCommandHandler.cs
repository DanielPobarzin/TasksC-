using MediatR;
using Notes.Aplication.intefaces;
using System;
using System.Threading.Tasks;
using Notes.Aplication.Common.Exeptions;
using Notes.Domain;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Notes.Aplication.Notes.Commands.DeleteNote;

namespace Notes.Aplication.Notes.Commands.DeleteNote
{
    public class DeleteNoteCommandHandler : IRequestHandler<DeleteNoteCommand>
    {
        private readonly INotesDbContext _dbContext;
        public DeleteNoteCommandHandler(INotesDbContext dbContext) => _dbContext = dbContext;
        public async Task Handle(DeleteNoteCommand request, CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Notes.FindAsync(new object[] { request.Id }, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Note), request.Id);
            }
            _dbContext.Notes.Remove(entity);   
            await _dbContext.SaveChangesAsync(cancellationToken);
            return;
        }
    }
}
