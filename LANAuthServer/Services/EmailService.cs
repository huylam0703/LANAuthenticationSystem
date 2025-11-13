using System;
using System.Net;
using System.Net.Mail;

namespace LANAuthServer.Services
{
    internal class EmailService
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _senderEmail;
        private readonly string _senderPassword;

        public EmailService(
            string smtpServer = "smtp.gmail.com",
            int smtpPort = 587,
            string senderEmail = "",
            string senderPassword = "")
        {
            _smtpServer = smtpServer;
            _smtpPort = smtpPort;
            _senderEmail = senderEmail;
            _senderPassword = senderPassword;
        }

        public bool SendViolationAlert(string recipientEmail, string employeeName, string url, DateTime violationTime)
        {
            try
            {
                string subject = $"Cảnh báo vi phạm - {employeeName}";
                string body = $@"
                    <h2>Thông báo vi phạm chính sách sử dụng Internet</h2>
                    <p><strong>Nhân viên:</strong> {employeeName}</p>
                    <p><strong>Website truy cập:</strong> {url}</p>
                    <p><strong>Thời gian:</strong> {violationTime:dd/MM/yyyy HH:mm:ss}</p>
                    <hr>
                    <p>Đây là email tự động từ hệ thống LAN Authentication.</p>
                ";

                return SendEmail(recipientEmail, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending violation alert: " + ex.Message);
                return false;
            }
        }

        public bool SendWelcomeEmail(string recipientEmail, string employeeName, string userCode)
        {
            try
            {
                string subject = "Chào mừng bạn đến với hệ thống LAN Authentication";
                string body = $@"
                    <h2>Chào mừng {employeeName}!</h2>
                    <p>Tài khoản của bạn đã được tạo thành công.</p>
                    <p><strong>Mã nhân viên:</strong> {userCode}</p>
                    <p>Vui lòng đăng nhập và cập nhật đầy đủ thông tin cá nhân.</p>
                    <hr>
                    <p>Trân trọng,<br>Ban quản trị hệ thống</p>
                ";

                return SendEmail(recipientEmail, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending welcome email: " + ex.Message);
                return false;
            }
        }

        public bool SendPasswordResetEmail(string recipientEmail, string resetCode)
        {
            try
            {
                string subject = "Đặt lại mật khẩu - LAN Authentication";
                string body = $@"
                    <h2>Yêu cầu đặt lại mật khẩu</h2>
                    <p>Mã xác nhận của bạn là: <strong>{resetCode}</strong></p>
                    <p>Mã này có hiệu lực trong 15 phút.</p>
                    <p>Nếu bạn không yêu cầu đặt lại mật khẩu, vui lòng bỏ qua email này.</p>
                ";

                return SendEmail(recipientEmail, subject, body);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error sending reset email: " + ex.Message);
                return false;
            }
        }

        private bool SendEmail(string to, string subject, string body)
        {
            if (string.IsNullOrEmpty(_senderEmail) || string.IsNullOrEmpty(_senderPassword))
            {
                Console.WriteLine("Email credentials not configured");
                return false;
            }

            try
            {
                using (SmtpClient client = new SmtpClient(_smtpServer, _smtpPort))
                {
                    client.EnableSsl = true;
                    client.Credentials = new NetworkCredential(_senderEmail, _senderPassword);

                    MailMessage message = new MailMessage
                    {
                        From = new MailAddress(_senderEmail, "LAN Auth System"),
                        Subject = subject,
                        Body = body,
                        IsBodyHtml = true
                    };

                    message.To.Add(to);

                    client.Send(message);
                    Console.WriteLine($"Email sent successfully to {to}");
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to send email: {ex.Message}");
                return false;
            }
        }
    }
}