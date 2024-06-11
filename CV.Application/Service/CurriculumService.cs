using QuestPDF.Fluent;
using CV.Domain.Entity;
using QuestPDF.Infrastructure;
using CV.Application.Interface;

namespace CV.Application.Service
{
    public class CurriculumService : ICurriculumService
    {
        public async Task<byte[]> GeneratePdf(Curriculum curriculum)
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
                            column.Item().Row(row =>
                            {
                                row.RelativeItem().Column(col =>
                                {
                                    col.Item().Text(curriculum.Contact.FullName).FontSize(28).Bold().FontColor(Color.FromHex("#000")).AlignCenter();
                                    col.Item().Text(curriculum.Contact.Address);
                                    col.Item().Text($"Telefone: {curriculum.Contact.Phone}");
                                    col.Item().Text($"Email: {curriculum.Contact.Email}");
                                    col.Item().Hyperlink(curriculum.Contact.GitHub).Text("GitHub").FontColor(Color.FromHex("#3498db")).Underline();
                                    col.Item().Hyperlink(curriculum.Contact.LinkedIn).Text("LinkedIn").FontColor(Color.FromHex("#3498db")).Underline();
                                });
                            });

                            column.Item().Text("Educação").FontSize(20).Bold();
                            foreach (var education in curriculum.Educations)
                            {
                                column.Item().Row(row =>
                                {
                                    row.ConstantItem(9).Text("•");
                                    row.RelativeItem().Column(col =>
                                    {
                                        col.Item().Text($"{education.Institution} - {education.City}, {education.State}").Bold();
                                        col.Item().Text($"{education.Degree}");
                                        col.Item().Text($"[{education.StartDate} - {education.EndDate}]");
                                    });
                                });
                            }

                            column.Item().Text("Experiência Profissional").FontSize(20).Bold();
                            foreach (var work in curriculum.WorkExperiences)
                            {
                                column.Item().Row(row =>
                                {
                                    row.ConstantItem(9).Text("•");
                                    row.RelativeItem().Column(col =>
                                    {
                                        col.Item().Text($"{work.Company} - {work.City}, {work.State}").Bold();
                                        col.Item().Text($"{work.JobTitle}").Italic();
                                        col.Item().Text($"[{work.StartDate:MMM yyyy} - {work.EndDate:MMM yyyy}]");
                                        col.Item().Text(work.Description);
                                        col.Item().Text(string.Join(", ", work.Technologies));
                                    });
                                });
                            }

                            column.Item().Text("Certificações").FontSize(20).Bold();
                            foreach (var certification in curriculum.Certifications)
                            {
                                column.Item().Row(row =>
                                {
                                    row.ConstantItem(9).Text("•");
                                    row.RelativeItem().Column(col =>
                                    {
                                        col.Item().Text($"{certification.Name} - [{certification.Year}, {certification.Issuer}]");
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
    }
}
