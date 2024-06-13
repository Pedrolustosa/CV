using MediatR;
using QuestPDF.Fluent;
using QuestPDF.Infrastructure;
using CV.Application.CQRS.Commands;

namespace CV.Application.CQRS.Handlers;

public class CreateCurriculumCommandHandler() : IRequestHandler<CreateCurriculumCommand, byte[]>
{

    public async Task<byte[]> Handle(CreateCurriculumCommand request, CancellationToken cancellationToken)
    {
		try
		{
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

                            // Seção de Contato
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

                            // Seção de Educação
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

                            // Seção de Experiência Profissional
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

                            // Seção de Certificações
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

                return document.GeneratePdf();
            }
            catch (Exception)
            {
                throw;
            }
        }
		catch (Exception)
		{
			throw;
		}
    }
}
