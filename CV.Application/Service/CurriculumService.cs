using MediatR;
using CV.Domain.Entity;
using CV.Application.Interface;
using CV.Application.CQRS.Commands;

namespace CV.Application.Service
{
    public class CurriculumService(IMediator mediator) : ICurriculumService
    {
        private readonly IMediator _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

        public async Task<byte[]> GeneratePdf(Curriculum curriculum)
        {
            var command = new CreateCurriculumCommand { Curriculum = curriculum };
            var cvPdf = await _mediator.Send(command);
            return cvPdf;
        }
    }
}
