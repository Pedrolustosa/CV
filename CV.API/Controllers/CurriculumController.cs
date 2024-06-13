using CV.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using CV.Application.Interface;

namespace CV.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurriculumController(ICurriculumService curriculumService) : ControllerBase
{
    private readonly ICurriculumService _curriculumService = curriculumService;

    [HttpPost]
    [Route("GenerateCurriculum")]
    public async Task<IActionResult> GenerateCurriculum([FromBody] Curriculum curriculum)
    {
        try
        {
            var pdfBytes = await _curriculumService.GeneratePdf(curriculum);
            return File(pdfBytes, "application/pdf", $"{curriculum.Contact.FullName}.pdf");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao gerar o currículo: {ex.Message}");
        }
    }
}
