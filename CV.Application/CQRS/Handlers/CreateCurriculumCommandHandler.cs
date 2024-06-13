using MediatR;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using CV.Application.CQRS.Commands;
using Microsoft.Extensions.Logging;

namespace CV.Application.CQRS.Handlers;

public class CreateCurriculumCommandHandler(ILogger<CreateCurriculumCommandHandler> logger) : IRequestHandler<CreateCurriculumCommand, byte[]>
{
    private readonly ILogger<CreateCurriculumCommandHandler> _logger = logger ?? throw new ArgumentNullException(nameof(logger));

    public async Task<byte[]> Handle(CreateCurriculumCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling CreateCurriculumCommand for {FullName}", request.Curriculum.Contact.FullName);

        try
        {
            var document = Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Margin(50);
                    page.Content().Element(ComposeContent);
                });

                void ComposeContent(IContainer container)
                {
                    container.Column(column =>
                    {
                        column.Spacing(10);

                        column.Item().Row(row =>
                        {
                            row.RelativeItem().Column(col =>
                            {
                                col.Item().Text(request.Curriculum.Contact.FullName)
                                    .FontSize(28).Bold().FontColor(Color.FromHex("#000")).AlignCenter();
                                col.Item().Text(request.Curriculum.Contact.Address)
                                    .FontSize(12);
                                col.Item().Text($"Telefone: {request.Curriculum.Contact.Phone}")
                                    .FontSize(12);
                                col.Item().Text($"Email: {request.Curriculum.Contact.Email}")
                                    .FontSize(12);
                                col.Item().Row(innerRow =>
                                {
                                    innerRow.RelativeItem().Hyperlink(request.Curriculum.Contact.GitHub)
                                        .Text("GitHub").FontColor(Color.FromHex("#3498db")).Underline();
                                    innerRow.ConstantItem(10).Text(" ");
                                    innerRow.RelativeItem().Hyperlink(request.Curriculum.Contact.LinkedIn)
                                        .Text("LinkedIn").FontColor(Color.FromHex("#3498db")).Underline();
                                });
                            });
                        });

                        column.Item().Text("Educação").FontSize(20).Bold();
                        foreach (var education in request.Curriculum.Educations)
                        {
                            column.Item().Row(row =>
                            {
                                row.ConstantItem(9).Text("•");
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text($"{education.Institution}, {education.City}, {education.State}")
                                        .Bold();
                                    col.Item().Text($"{education.Degree}")
                                        .FontSize(12);
                                    col.Item().Text($"[{education.StartDate:MMMM yyyy} - {education.EndDate:MMMM yyyy}]")
                                        .FontSize(12);
                                });
                            });
                        }

                        column.Item().Text("Experiência Profissional").FontSize(20).Bold();
                        foreach (var work in request.Curriculum.WorkExperiences)
                        {
                            column.Item().Row(row =>
                            {
                                row.ConstantItem(9).Text("•");
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text($"{work.Company}, {work.City}, {work.State}")
                                        .Bold();
                                    col.Item().Text($"{work.JobTitle}")
                                        .Italic().FontSize(12);
                                    col.Item().Text($"[{work.StartDate:MMMM yyyy} - {work.EndDate:MMMM yyyy}]")
                                        .FontSize(12);
                                    col.Item().Text(work.Description)
                                        .FontSize(12);
                                    col.Item().Text(string.Join(", ", work.Technologies))
                                        .FontSize(12);
                                });
                            });
                        }

                        column.Item().Text("Certificações").FontSize(20).Bold();
                        foreach (var certification in request.Curriculum.Certifications)
                        {
                            column.Item().Row(row =>
                            {
                                row.ConstantItem(9).Text("•");
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text($"{certification.Name} - [{certification.Year}, {certification.Issuer}]")
                                        .FontSize(12);
                                });
                            });
                        }
                    });
                }
            });

            var pdfBytes = document.GeneratePdf();
            _logger.LogInformation("Successfully generated PDF for {FullName}", request.Curriculum.Contact.FullName);
            return pdfBytes;
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error generating PDF for {FullName}", request.Curriculum.Contact.FullName);
            throw;
        }
    }
}
