using MediatR;
using CV.Domain.Entity;
using Microsoft.AspNetCore.Mvc;
using CV.Application.CQRS.Commands;

namespace CV.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CurriculumController(IMediator mediator) : ControllerBase
{
    private readonly IMediator _mediator = mediator;

    [HttpPost]
    [Route("GenerateCurriculum")]
    public async Task<IActionResult> GenerateCurriculum([FromBody] Curriculum curriculum)
    {
        try
        {
            var command = new CreateCurriculumCommand { Curriculum = curriculum };
            var pdfBytes = await _mediator.Send(command);
            return File(pdfBytes, "application/pdf", $"{curriculum.Contact.FullName}.pdf");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Erro ao gerar o currículo: {ex.Message}");
        }
    }
}
