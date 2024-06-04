using MediatR;
using CV.Domain.Entity;

namespace CV.Application.CQRS.Commands;

public class CreateCurriculumCommand : IRequest<byte[]>
{
    public Curriculum Curriculum { get; set; }
}
