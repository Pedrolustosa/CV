using CV.Domain.Entity;
using CV.Application.Interface;
using Microsoft.AspNetCore.Mvc;

namespace CV.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurriculumController(ICurriculumService curriculumService) : ControllerBase
{
    private readonly ICurriculumService _curriculumService = curriculumService;

    [HttpPost]
    [Route("GenerateCurriculum")]
    public IActionResult GerarCurriculum([FromBody] Curriculum curriculum)
    {
        var pdfBytes = _curriculumService.GerarCurriculoPdf(curriculum);
        return File(pdfBytes, "application/pdf", $"{curriculum.Name}.pdf");
    }
}
