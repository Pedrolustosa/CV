using CV.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using CV.Application.Interface;

namespace CV.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurriculumController(ICurriculumService curriculumService, ILogger<CurriculumController> logger) : ControllerBase
{
    private readonly ILogger<CurriculumController> _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    private readonly ICurriculumService _curriculumService = curriculumService ?? throw new ArgumentNullException(nameof(curriculumService));

    [HttpPost]
    [Route("GenerateCurriculum")]
    public async Task<IActionResult> GenerateCurriculum([FromBody] Curriculum curriculum)
    {
        try
        {
            var pdfBytes = await _curriculumService.GeneratePdf(curriculum);
            _logger.LogInformation("GenerateCurriculum action succeeded");
            return File(pdfBytes, "application/pdf", $"{curriculum.Contact.FullName}.pdf");
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error occurred while getting curriculum");
            return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
        }
    }
}
