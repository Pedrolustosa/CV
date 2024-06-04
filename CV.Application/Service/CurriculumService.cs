using iText.Layout;
using CV.Domain.Entity;
using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.Kernel.Geom;
using iText.Kernel.Colors;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Action;
using CV.Application.Interface;

namespace CV.Application.Service;

public class CurriculumService : ICurriculumService
{
    public byte[] GerarCurriculoPdf(Curriculum curriculum)
    {
        using var memoryStream = new MemoryStream();
        PdfWriter writer = new(memoryStream);
        PdfDocument pdf = new(writer);
        PageSize pageSize = PageSize.A4;
        Document document = new(pdf, pageSize);

        document.SetMargins(36, 36, 36, 36);
        PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        PdfFont normal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        var titleStyle = new Style()
            .SetFontSize(24)
            .SetBold()
            .SetFont(bold)
            .SetTextAlignment(TextAlignment.CENTER);

        var sectionTitleStyle = new Style()
            .SetFontSize(14)
            .SetBold()
            .SetFont(bold);

        var textStyle = new Style()
            .SetFontSize(12)
            .SetFont(normal);

        var bulletStyle = new Style()
            .SetFontSize(10)
            .SetFont(normal);

        var subBulletStyle = new Style()
            .SetFontSize(10)
            .SetFont(normal)
            .SetMarginLeft(15);

        document.Add(new Paragraph(curriculum.Name).AddStyle(titleStyle));
        document.Add(new Paragraph($"      Contato: {curriculum.Contact}").AddStyle(textStyle));
        document.Add(new Paragraph($"      Endereço: {curriculum.Address}").AddStyle(textStyle));
        document.Add(new Paragraph($"      Telefone: {curriculum.Telephone}").AddStyle(textStyle));
        document.Add(new Paragraph($"      Email: {curriculum.Email}").AddStyle(textStyle));

        Paragraph links = new Paragraph()
                .Add(new Link("GitHub", PdfAction.CreateURI(curriculum.GitHub)).SetUnderline().SetFontColor(ColorConstants.BLUE).AddStyle(textStyle))
                .Add(new Text(" | ").AddStyle(textStyle))
                .Add(new Link("LinkedIn", PdfAction.CreateURI(curriculum.LinkedIn)).SetUnderline().SetFontColor(ColorConstants.BLUE).AddStyle(textStyle));
        document.Add(links);

        Div educationSection = new Div().SetKeepTogether(true);
        educationSection.Add(new Paragraph("Educação:").AddStyle(sectionTitleStyle));

        foreach (var education in curriculum.Education)
        {
            educationSection.Add(new Paragraph($"• {education.Institution}, {education.City}, {education.State}")
                              .AddStyle(bulletStyle)
                              .SetFont(bold));
            educationSection.Add(new Paragraph($"  o {education.Course}")
                              .AddStyle(subBulletStyle));
            educationSection.Add(new Paragraph($"        [{education.Status}, {education.Period}]")
                              .AddStyle(subBulletStyle));
        }
        document.Add(educationSection);

        Div experienceSection = new Div().SetKeepTogether(true);
        experienceSection.Add(new Paragraph("Experiência Profissional:").AddStyle(sectionTitleStyle));
        foreach (var experience in curriculum.Experience)
        {
            experienceSection.Add(new Paragraph($"• {experience.Company}, {experience.City}")
                             .AddStyle(bulletStyle)
                             .SetFont(bold));
            experienceSection.Add(new Paragraph($"  o {experience.Position}")
                             .AddStyle(subBulletStyle));
            experienceSection.Add(new Paragraph($"    [{experience.Period}]")
                             .AddStyle(subBulletStyle));

            foreach (var descricao in experience.Description)
            {
                experienceSection.Add(new Paragraph($"• {descricao}").AddStyle(subBulletStyle));
            }
        }
        document.Add(experienceSection);

        Div certificationSection = new Div().SetKeepTogether(true);
        certificationSection.Add(new Paragraph("Certificações:").AddStyle(sectionTitleStyle));

        foreach (var certification in curriculum.Certification)
        {
            certificationSection.Add(new Paragraph($"• {certification.Name} - {certification.Institution}").AddStyle(bulletStyle));
        }
        document.Add(certificationSection);

        document.Close();
        return memoryStream.ToArray();
    }
}
