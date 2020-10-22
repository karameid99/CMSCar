using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace CMSCar.Helper
{
    public class SendEmail
    {
        public static void SendMail(String Email, String Name, String callbackUrl)
        {
            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("cmszamel@gmail.com", "Admin11$");
            objeto_mail.From = new MailAddress("cmszamel@gmail.com", "Saudi Ground Services Careers");
            objeto_mail.To.Add(new MailAddress(Email));
            objeto_mail.Subject = "SGS | Reset Password";
            string body = $"<!DOCTYPE HTML PUBLIC>";
            body += "<html><head></head>";
            body += "<div class=''><div class='aHl'></div><div id=':oh' tabindex='-1'></div><div id=':o6' class='ii gt'><div id=':o5' class='a3s aXjCH msg-3195231037618582888'><u></u>";
            body += "<div style='background:#f9f9f9'>";
            body += "<div style='background-color:#f9f9f9'>";
            body += "<div style='margin:0px auto;max-width:640px;background:transparent'><table role='presentation' cellpadding='0' cellspacing='0' style='font-size:0px;width:100%;background:transparent' align='center' border='0'><tbody><tr><td style='text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:40px 0px'><div aria-labelledby='mj-column-per-100' class='m_-3195231037618582888mj-column-per-100' style='vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%'><table role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'><tbody><tr><td style='word-break:break-word;font-size:0px;padding:0px' align='center'><table role='presentation' cellpadding='0' cellspacing='0' style='border-collapse:collapse;border-spacing:0px' align='center' border='0'><tbody><tr><td style='width:138px'><a href='#' target='_blank' data-saferedirecturl=''><img alt='' title='' height='38px' src='https://sgs2.azurewebsites.net/Images/sgs.png' width='138' class='CToWUd'></a></td></tr></tbody></table></td></tr></tbody></table></div></td></tr></tbody></table></div>";
            body += "<div style='max-width:640px;margin:0 auto;border-radius:4px;overflow:hidden'><div style='margin:0px auto;max-width:640px;background:#ffffff'><table role='presentation' cellpadding='0' cellspacing='0' style='font-size:0px;width:100%;background:#ffffff' align='center' border='0'><tbody><tr><td style='text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:40px 50px'><div aria-labelledby='mj-column-per-100' class='m_-3195231037618582888mj-column-per-100' style='vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%'><table role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'><tbody><tr><td style='word-break:break-word;font-size:0px;padding:0px' align='left'><div style='color:#737f8d;font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;font-size:16px;line-height:24px;text-align:left'>";
            body += "<h2 style='font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;font-weight:500;font-size:20px;color:#4f545c;letter-spacing:0.27px'>";
            body += $"Hey {Name},</h2>";
            body += "<p>Your account SGS password can be reset by clicking the button below. If you did not request a new password, please ignore this email.</p>";
            body += $"</div></td></tr><tr><td style='word-break:break-word;font-size:0px;padding:10px 25px;padding-top:20px' align='center'><table role='presentation' cellpadding='0' cellspacing='0' style='border-collapse:separate' align='center' border='0'><tbody><tr><td style='border:none;border-radius:3px;color:white;padding:15px 19px' align='center' valign='middle' bgcolor='#7289DA'><a href='{HtmlEncoder.Default.Encode(callbackUrl)}' style='text-decoration:none;line-height:100%;background:#7289da;color:white;font-family:Ubuntu,Helvetica,Arial,sans-serif;font-size:15px;font-weight:normal;text-transform:none;margin:0px' target='_blank' data-saferedirecturl=''>";
            body += "Reset Password";
            body += "</a></td></tr></tbody></table></td></tr><tr><td style='word-break:break-word;font-size:0px;padding:30px 0px'><p style='font-size:1px;margin:0px auto;border-top:1px solid #dcddde;width:100%'></p></td></tr><tr><td style='word-break:break-word;font-size:0px;padding:0px' align='left'><div style='color:#747f8d;font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;font-size:13px;line-height:16px;text-align:left'>";
            body += "<p>Need help? <a href='#' style='font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;color:#7289da' target='_blank' data-saferedirecturl=''>Contact our support team</a> or hit us up on Twitter <a href='https://twitter.com/sgs' style='font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;color:#7289da' target='_blank' data-saferedirecturl=''>@discordapp</a>.<br>";
            body += "<a href='' style='font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;color:#7289da' target='_blank' data-saferedirecturl=''></a></p>";
            body += "</div></td></tr></tbody></table></div></td></tr></tbody></table></div>";
            body += "</div><div style='margin:0px auto;max-width:640px;background:transparent'><table role='presentation' cellpadding='0' cellspacing='0' style='font-size:0px;width:100%;background:transparent' align='center' border='0'><tbody><tr><td style='text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:0px'><div aria-labelledby='mj-column-per-100' class='m_-3195231037618582888mj-column-per-100' style='vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%'><table role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'><tbody><tr><td style='word-break:break-word;font-size:0px'><div style='font-size:1px;line-height:12px'>&nbsp;</div></td></tr></tbody></table></div></td></tr></tbody></table></div>";
            body += "<div style='margin:0 auto;max-width:640px;background:#ffffff;border-radius:4px;overflow:hidden'><table cellpadding='0' cellspacing='0' style='font-size:0px;width:100%;background:#ffffff' align='center' border='0'><tbody><tr><td style='text-align:center;vertical-align:top;font-size:0px;padding:0px'><div aria-labelledby='mj-column-per-100' class='m_-3195231037618582888mj-column-per-100' style='vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%'><table role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'><tbody><tr><td style='word-break:break-word;font-size:0px;padding:30px 40px 0px 40px' align='center'><div style='color:#43b581;font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;font-size:18px;font-weight:bold;line-height:16px;text-align:center'>SGS Company</div></td></tr><tr><td style='word-break:break-word;font-size:0px;padding:14px 40px 30px 40px' align='center'><div style='color:#737f8d;font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;font-size:16px;line-height:22px;text-align:center'>";
            body += "Your new concept for the real estate world";
            body += "</div></td></tr></tbody></table></div></td></tr></tbody></table></div>";
            body += "<div style='margin:0px auto;max-width:640px;background:transparent'><table role='presentation' cellpadding='0' cellspacing='0' style='font-size:0px;width:100%;background:transparent' align='center' border='0'><tbody><tr><td style='text-align:center;vertical-align:top;direction:ltr;font-size:0px;padding:20px 0px'><div aria-labelledby='mj-column-per-100' class='m_-3195231037618582888mj-column-per-100' style='vertical-align:top;display:inline-block;direction:ltr;font-size:13px;text-align:left;width:100%'><table role='presentation' cellpadding='0' cellspacing='0' width='100%' border='0'><tbody><tr><td style='word-break:break-word;font-size:0px;padding:0px' align='center'><div style='color:#99aab5;font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;font-size:12px;line-height:24px;text-align:center'>";
            body += "Sent by SGS • <a href='~' style='color:#1eb0f4;text-decoration:none' target='_blank' data-saferedirecturl=''>check our blog</a> • <a href='#' style='color:#1eb0f4;text-decoration:none' target='_blank' data-saferedirecturl=''>@SGSApp</a>";
            body += "</div></td></tr><tr><td style='word-break:break-word;font-size:0px;padding:0px' align='center'><div style='color:#99aab5;font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;font-size:12px;line-height:24px;text-align:center'>";
            body += "444 De Haro Street, Suite 200, San Francisco, CA 94107";
            body += "</div></td></tr><tr><td style='word-break:break-word;font-size:0px;padding:0px' align='left'><div style='color:#000000;font-family:Whitney,Helvetica Neue,Helvetica,Arial,Lucida Grande,sans-serif;font-size:13px;line-height:22px;text-align:left'>";
            body += "<img src='' width='1' height='1' class='CToWUd'>";
            body += "</div></td></tr></tbody></table></div></td></tr></tbody></table></div></div>";
            body += "<img width='1px' height='1px' alt='' src='' class='CToWUd'></div><div class='yj6qo'></div><div class='adL'>";
            body += "</div></div></div><div id=':om' class='ii gt' style='display:none'><div id=':ol' class='a3s aXjCH undefined'></div></div><div class='hi'></div></div>";
            body += "<body>";
            body += "</body></html>";

            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            // Add the alternate body to the message.

            AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
            objeto_mail.AlternateViews.Add(alternate);
            client.Send(objeto_mail);

        }

        public static async Task SendMailAsync(String Email, String Title, string Message)
        {
            MailMessage objeto_mail = new MailMessage();
            SmtpClient client = new SmtpClient();
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.EnableSsl = true;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.UseDefaultCredentials = false;
            client.Credentials = new System.Net.NetworkCredential("iconcompany2020@gmail.com", "Admin11$");
            objeto_mail.From = new MailAddress("iconcompany2020@gmail.com", "شركة الإمارات للسيارات");
            objeto_mail.To.Add(new MailAddress(Email));
            objeto_mail.Subject = Title;
            string body = $"<!DOCTYPE HTML PUBLIC>";
            body += "<html><head></head>";
            body += $"<p>@{Message}</p>";
            body += "<body>";
            body += "</body></html>";

            ContentType mimeType = new System.Net.Mime.ContentType("text/html");
            // Add the alternate body to the message.

            AlternateView alternate = AlternateView.CreateAlternateViewFromString(body, mimeType);
            objeto_mail.AlternateViews.Add(alternate);
            await client.SendMailAsync(objeto_mail);
        }

    }
}
