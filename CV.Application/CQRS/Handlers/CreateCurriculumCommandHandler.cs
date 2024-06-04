using MediatR;
using CV.Application.Interface;
using CV.Application.CQRS.Commands;

namespace CV.Application.CQRS.Handlers;

public class CreateCurriculumCommandHandler(ICurriculumService curriculumService) : IRequestHandler<CreateCurriculumCommand, byte[]>
{
    private readonly ICurriculumService _curriculumService = curriculumService;

    public async Task<byte[]> Handle(CreateCurriculumCommand request, CancellationToken cancellationToken)
    {
		try
		{
            var pdf = await _curriculumService.GeneratePdf(request.Curriculum);
            return pdf;
        }
		catch (Exception)
		{
			throw;
		}
        
    }
}
