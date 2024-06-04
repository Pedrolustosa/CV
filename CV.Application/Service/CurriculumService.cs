using iText.Layout;
using iText.Kernel.Pdf;
using CV.Domain.Entity;
using iText.Kernel.Font;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using CV.Application.Interface;

namespace CV.Application.Service;

public class CurriculumService : ICurriculumService
{
    public byte[] GerarCurriculoPdf(Curriculum curriculum)
    {
        using var memoryStream = new MemoryStream();
        PdfWriter writer = new(memoryStream);
        PdfDocument pdf = new(writer);
        Document document = new(pdf);

        PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
        PdfFont normal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

        var titleStyle = new Style()
            .SetFontSize(20)
            .SetBold()
            .SetFont(bold)
            .SetTextAlignment(TextAlignment.LEFT);

        var sectionTitleStyle = new Style()
            .SetFontSize(14)
            .SetBold()
            .SetFont(bold);

        var textStyle = new Style()
            .SetFontSize(12)
            .SetFont(normal);

        var bulletStyle = new Style()
            .SetFontSize(12)
            .SetFont(normal);

        var subBulletStyle = new Style()
            .SetFontSize(12)
            .SetFont(normal)
            .SetMarginLeft(15);

        document.Add(new Paragraph(curriculum.Name).AddStyle(titleStyle));
        document.Add(new Paragraph($"Contato: {curriculum.Contact}").AddStyle(textStyle));
        document.Add(new Paragraph($"Endereço: {curriculum.Address}").AddStyle(textStyle));
        document.Add(new Paragraph($"Telefone: {curriculum.Telephone}").AddStyle(textStyle));
        document.Add(new Paragraph($"Email: {curriculum.Email}").AddStyle(textStyle));
        document.Add(new Paragraph($"GitHub: {curriculum.GitHub}").AddStyle(textStyle));
        document.Add(new Paragraph($"LinkedIn: {curriculum.LinkedIn}").AddStyle(textStyle));

        document.Add(new Paragraph("Educação:").AddStyle(sectionTitleStyle));
        foreach (var education in curriculum.Education)
        {
            document.Add(new Paragraph($"• {education.Institution}, {education.City}, {education.State}").AddStyle(bulletStyle).SetFont(bold));
            document.Add(new Paragraph($"  o {education.Course}").AddStyle(subBulletStyle));
            document.Add(new Paragraph($"      [{education.Status}, {education.Period}]").AddStyle(subBulletStyle));
        }

        document.Add(new Paragraph("Experiência Profissional:").AddStyle(sectionTitleStyle));
        foreach (var experience in curriculum.Experience)
        {
            document.Add(new Paragraph($"• {experience.Company}, {experience.City}").AddStyle(bulletStyle).SetFont(bold));
            document.Add(new Paragraph($"  o {experience.Position}").AddStyle(subBulletStyle));
            document.Add(new Paragraph($"    [{experience.Period}]").AddStyle(subBulletStyle));
            foreach (var descricao in experience.Description)
            {
                document.Add(new Paragraph($"• {descricao}").AddStyle(subBulletStyle));
            }
        }

        document.Add(new Paragraph("Certificações:").AddStyle(sectionTitleStyle));
        foreach (var certification in curriculum.Certification)
        {
            document.Add(new Paragraph($"• {certification.Name} - {certification.Institution}").AddStyle(bulletStyle));
        }

        document.Close();
        return memoryStream.ToArray();
    }
}
