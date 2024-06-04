using iText.Layout;
using CV.Domain.Entity;
using iText.Kernel.Pdf;
using iText.Kernel.Font;
using iText.Kernel.Colors;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Font.Constants;
using iText.Kernel.Pdf.Action;
using CV.Application.Interface;

namespace CV.Application.Service;

public class CurriculumService : ICurriculumService
{
    public async Task<byte[]> GeneratePdf(Curriculum curriculum)
    {
		try
		{
            using var memoryStream = new MemoryStream();
            PdfWriter writer = new(memoryStream);
            PdfDocument pdf = new(writer);
            Document document = new(pdf);
            float marginLeft = 3 * 72 / 2.54f;
            float marginRight = 2 * 72 / 2.54f;
            float marginTop = 3 * 72 / 2.54f;
            float marginBottom = 2 * 72 / 2.54f;

            document.SetMargins(marginLeft, marginRight, marginTop, marginBottom);
            PdfFont bold = PdfFontFactory.CreateFont(StandardFonts.HELVETICA_BOLD);
            PdfFont normal = PdfFontFactory.CreateFont(StandardFonts.HELVETICA);

            var contactTitleStyle = new Style()
                .SetFontSize(28)
                .SetBold()
                .SetFont(bold)
                .SetMarginBottom(5)
                .SetTextAlignment(TextAlignment.CENTER);

            var contactDetailsStyle = new Style()
                .SetFontSize(10)
                .SetFont(normal);

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

            #region Contato
            document.Add(new Paragraph($"{curriculum.Name}").AddStyle(contactTitleStyle));
            document.Add(new Paragraph($"Endereço: {curriculum.Contact.Address}").AddStyle(contactDetailsStyle));
            document.Add(new Paragraph($"Telefone: {curriculum.Contact.Telephone}").AddStyle(contactDetailsStyle));
            document.Add(new Paragraph($"Email: {curriculum.Contact.Email}").AddStyle(contactDetailsStyle));

            Paragraph links = new Paragraph()
                .Add(new Link("GitHub", PdfAction.CreateURI(curriculum.Contact.GitHub)).SetUnderline().SetFontColor(ColorConstants.BLUE).AddStyle(textStyle))
                .Add(new Text(" | ").AddStyle(textStyle))
                .Add(new Link("LinkedIn", PdfAction.CreateURI(curriculum.Contact.LinkedIn)).SetUnderline().SetFontColor(ColorConstants.BLUE).AddStyle(textStyle));
            document.Add(links);
            #endregion

            Div educationSection = new Div().SetKeepTogether(true);

            #region Certificações
            educationSection.Add(new Paragraph("Educação:").AddStyle(sectionTitleStyle));
            foreach (var education in curriculum.Education)
            {
                educationSection.Add(new Paragraph($"• {education.Institution}, {education.City}, {education.State}")
                    .AddStyle(bulletStyle)
                    .SetFont(bold));
                educationSection.Add(new Paragraph($"{education.Course}").AddStyle(subBulletStyle));
                educationSection.Add(new Paragraph($"[{education.Status}, {education.Period}]").AddStyle(subBulletStyle));
            }
            document.Add(educationSection);
            #endregion

            #region Experiência
            Div experienceSection = new Div().SetKeepTogether(true);
            experienceSection.Add(new Paragraph("Experiência:").AddStyle(sectionTitleStyle));
            foreach (var experience in curriculum.Experience)
            {
                experienceSection.Add(new Paragraph($"• {experience.Company}, {experience.City}")
                    .AddStyle(bulletStyle)
                    .SetFont(bold));
                experienceSection.Add(new Paragraph($"{experience.Position}").AddStyle(subBulletStyle).SetItalic());
                experienceSection.Add(new Paragraph($"[{experience.Period}]").AddStyle(subBulletStyle));

                foreach (var descricao in experience.Description)
                {
                    experienceSection.Add(new Paragraph($"• {descricao}").AddStyle(subBulletStyle));
                }
            }
            document.Add(experienceSection);
            #endregion

            #region Certificações
            Div certificationSection = new Div().SetKeepTogether(true);
            certificationSection.Add(new Paragraph("Certificações:").AddStyle(sectionTitleStyle));
            foreach (var certification in curriculum.Certification)
            {
                certificationSection.Add(new Paragraph($"• {certification.Name} - {certification.Institution}").AddStyle(bulletStyle));
            }
            document.Add(certificationSection);
            #endregion

            document.Close();
            return memoryStream.ToArray();
        }
		catch (Exception)
		{
			throw;
		}
    }
}
