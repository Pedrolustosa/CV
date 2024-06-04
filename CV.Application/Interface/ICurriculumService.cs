using CV.Domain.Entity;

namespace CV.Application.Interface;

public interface ICurriculumService
{
    byte[] GerarCurriculoPdf(Curriculum curriculo);
}
