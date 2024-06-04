using CV.Domain.Entity;

namespace CV.Application.Interface;

public interface ICurriculumService
{
    Task<byte[]> GeneratePdf(Curriculum curriculo);
}
