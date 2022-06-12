using BLL.Abstractions.cs.Interfaces;
using BLL.Validation;
using Core.Models;
using DAL.Abstractions.Interfaces;
using DAL.Data;
using iText.Html2pdf;
using iText.Kernel.Pdf;
using iText.Layout;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmailService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<User> _userManager;
        private readonly IEmailSender _emailSender;

        public EmailService(IUnitOfWork unitOfWork,
            UserManager<User> userManager,
            IEmailSender emailSender)
        {
            _unitOfWork = unitOfWork;
            _userManager = userManager;
            _emailSender = emailSender;
        }

        public async Task SendTextMaterialAsPdf(User user, TextMaterial textMaterial)
        {
            var stream = new MemoryStream();
            var writer = new PdfWriter(stream);

            var document = HtmlConverter.ConvertToDocument(textMaterial.Content, writer);

            document.Close();
            MemoryStream pdfStream = new MemoryStream(stream.ToArray());

            try
            {
                _emailSender.SendSmtpMail(new EmailTemplate()
                {
                    To = user.Email,
                    Subject = "Movie Report",
                    Body = "Here is your pdf report",
                    Attachment = new Attachment(pdfStream, "textMaterial.pdf")
                });
            }
            catch (Exception e)
            {
                throw new CardFileException(e.Message);
            }
            finally
            {
                stream.Close();
                pdfStream.Close();
                writer.Close();
            }
        }
    }
}
