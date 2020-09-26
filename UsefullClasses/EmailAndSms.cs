using Newtonsoft.Json;
using System;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace UsefullClasses
{
    public static partial class EmailAndSms
    {

        public static async Task<bool> SendEmail(string body, string attachment = "", string subject = "", params string[] toMails)
        {
            try
            {

                string Email = "something@myhost.com";
                string password = "Vew?n474";
                string sender = "Amin";
                string Host = "www.myhost.com";
                var mailMsg = new MailMessage();
                mailMsg.BodyEncoding = Encoding.UTF8;
                mailMsg.HeadersEncoding = Encoding.UTF8;
                mailMsg.SubjectEncoding = Encoding.UTF8;
                mailMsg.Priority = MailPriority.Normal;
                mailMsg.Subject = subject;
                mailMsg.Body = body;
                mailMsg.DeliveryNotificationOptions = DeliveryNotificationOptions.OnFailure;
                mailMsg.IsBodyHtml = true;
                mailMsg.From = new MailAddress(Email, sender, Encoding.UTF8);
                mailMsg.Sender = new MailAddress(Email, sender, Encoding.UTF8);
                foreach (var mail in toMails)
                {
                    if (!string.IsNullOrEmpty(mail))
                        mailMsg.To.Add(new MailAddress(mail));
                }
                if (attachment != "")
                    mailMsg.Attachments.Add(new Attachment(attachment));

                var smtp = new SmtpClient(Host, 25);
                smtp.EnableSsl = false;
                smtp.Timeout = 10000;
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = new NetworkCredential(Email, password);
                await smtp.SendMailAsync(mailMsg);
                return true;
            }
            catch (Exception e)
            {
                //Tools.AlertBox(page, string.Format("خطا در ارسال ایمیل \n  شرح خطا: {0}", e.Message));
                return false;
            }




        }
        public static string SendSms(string text, string phone, string[] phones = null)
        {
            try
            {


                WebRequest request = WebRequest.Create("http://ippanel.com/services.jspd");

                string[] rcpts = phones != null ? phones : new string[] { phone };
                string json = JsonConvert.SerializeObject(rcpts);
                request.Method = "POST";
                string postData = "op=send&uname=borhani0038&pass=b@b@k123@#&message=" + text + "&to=" + json + "&from=+9850002040";
                byte[] byteArray = Encoding.UTF8.GetBytes(postData);
                request.ContentType = "application/x-www-form-urlencoded";
                request.ContentLength = byteArray.Length;
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(byteArray, 0, byteArray.Length);
                dataStream.Close();
                WebResponse response = request.GetResponse();
                Console.WriteLine(((HttpWebResponse)response).StatusDescription);
                dataStream = response.GetResponseStream();
                StreamReader reader = new StreamReader(dataStream);
                string responseFromServer = reader.ReadToEnd();
                Console.WriteLine(responseFromServer);
                reader.Close();
                dataStream.Close();
                response.Close();
                System.Diagnostics.Debug.WriteLine(responseFromServer);
                return responseFromServer;

            }
            catch (Exception e)
            {
                return e.Message;
            }
        }

    }
}
