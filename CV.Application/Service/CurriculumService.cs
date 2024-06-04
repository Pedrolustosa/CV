using iText.Layout;
using iText.Kernel.Pdf;
using CV.Domain.Entity;
using iText.Layout.Element;
using CV.Application.Interface;

namespace CV.Application.Service;

public class CurriculumService : ICurriculumService
{
    public byte[] GerarCurriculoPdf(Curriculum curriculum)
    {
        using var memoryStream = new MemoryStream();
        PdfWriter writer = new(memoryStream);
        PdfDocument pdf = new(writer);
        Document document = new Document(pdf)
            .SetFontSize(12);

        document.SetMargins(36, 36, 72, 36);

        var titleStyle = new Style()
            .SetFontSize(14)
            .SetBold()
            .SetMarginBottom(10);

        var subtitleStyle = new Style()
            .SetFontSize(12)
            .SetBold()
            .SetMarginTop(10)
            .SetMarginBottom(5);

        var textStyle = new Style()
            .SetFontSize(11)
            .SetMarginBottom(5);

        document.Add(new Paragraph(curriculum.Name).AddStyle(titleStyle));
        document.Add(new Paragraph($"Contato: {curriculum.Contact}").AddStyle(textStyle));
        document.Add(new Paragraph($"Endereço: {curriculum.Address}").AddStyle(textStyle));
        document.Add(new Paragraph($"Telefone: {curriculum.Telephone}").AddStyle(textStyle));
        document.Add(new Paragraph($"Email: {curriculum.Email}").AddStyle(textStyle));
        document.Add(new Paragraph($"GitHub: {curriculum.GitHub}").AddStyle(textStyle));
        document.Add(new Paragraph($"LinkedIn: {curriculum.LinkedIn}").AddStyle(textStyle));

        document.Add(new Paragraph("Educação:").AddStyle(subtitleStyle));
        foreach (var education in curriculum.Education)
        {
            document.Add(new Paragraph($"* {education.Institution}").AddStyle(textStyle));
            document.Add(new Paragraph($"  - {education.Course}").AddStyle(textStyle));
            document.Add(new Paragraph($"     [{education.Period}]").AddStyle(textStyle));
        }

        document.Add(new Paragraph("Experiência Profissional:").AddStyle(subtitleStyle));
        foreach (var experience in curriculum.Experience)
        {
            document.Add(new Paragraph($"* {experience.Company}").AddStyle(textStyle));
            document.Add(new Paragraph($"  - {experience.Position}").AddStyle(textStyle));
            document.Add(new Paragraph($"     [{experience.Period}]").AddStyle(textStyle));
            foreach (var descricao in experience.Description)
            {
                document.Add(new Paragraph($"*   {descricao}").AddStyle(textStyle).SetItalic());
            }
        }

        document.Add(new Paragraph("Certificações:").AddStyle(subtitleStyle));
        foreach (var certification in curriculum.Certification)
        {
            document.Add(new Paragraph($"*   {certification.Name} - {certification.Institution}").AddStyle(textStyle));
        }

        document.Close();
        return memoryStream.ToArray();
    }
}
