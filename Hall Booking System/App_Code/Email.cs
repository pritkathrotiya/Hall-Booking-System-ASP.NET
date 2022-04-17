using HallBookingSystem.BAL;
using HallBookingSystem.ENT;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

/// <summary>
/// Summary description for Email
/// </summary>
public class Email
{
    #region  Constructor
    public Email()
    {

    }
    #endregion

    #region Local Variables
    protected static string _Message;
    public static string Message
    {
        get
        {
            return _Message;
        }
        set
        {
            _Message = value;
        }
    }
    #endregion

    #region Create Mail Protocol
    protected static SmtpClient createSMTP()
    {
        SmtpClient smtp = new SmtpClient();
        smtp.Host = "smtp.gmail.com";
        smtp.Port = 587;
        smtp.Credentials = new NetworkCredential("email", "email-password");
        smtp.EnableSsl = true;
        return smtp;
    }
    #endregion

    #region Send Email Of User Reset Password
    public static string sendEmailOfUserResetPassword(string userEmail)
    {
        UserDetailsBAL balUserDetails = new UserDetailsBAL();
        UserDetailsENT entUserDetails = new UserDetailsENT();

        entUserDetails = balUserDetails.SelectByEmail(userEmail);

        if (entUserDetails != null)
        {
            MailMessage msg = new MailMessage();
            msg.Subject = "Forget Password ";
            msg.Body = string.Format("Hi <b>{0}</b>,<br /><br />Your password is <b>{1}</b>.<br /><br />Thank You.<br /><br />This is system generated Email", entUserDetails.Username, entUserDetails.Password);
            msg.IsBodyHtml = true;

            msg.To.Add(entUserDetails.Email.ToString());
            msg.From = new MailAddress("p2rtechnology@gmail.com");
            SmtpClient sendMail = createSMTP();

            try
            {
                sendMail.Send(msg);
                Message = "Password has been sent to your email address.";
                return Message;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Message;
            }
        }
        else
        {
            Message = balUserDetails.Message;
            return Message;
        }
    }
    #endregion

    #region Send Email Of Admin Reset Password
    public static string sendEmailOfAdminResetPassword(string userEmail)
    {
        AdminDetailsBAL balAdminDetails = new AdminDetailsBAL();
        AdminDetailsENT entAdminDetails = new AdminDetailsENT();

        entAdminDetails = balAdminDetails.SelectByEmail(userEmail);

        if (entAdminDetails != null)
        {
            MailMessage msg = new MailMessage();
            msg.Subject = "Forget Password ";
            msg.Body = string.Format("Hi <b>{0}</b>,<br /><br />Your password is <b>{1}</b>.<br /><br />Thank You.<br /><br />This is system generated Email", entAdminDetails.Username, entAdminDetails.Password);
            msg.IsBodyHtml = true;

            msg.To.Add(entAdminDetails.Email.ToString());
            msg.From = new MailAddress("p2rtechnology@gmail.com");
            SmtpClient sendMail = createSMTP();

            try
            {
                sendMail.Send(msg);
                Message = "Password has been sent to your email address.";
                return Message;
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                return Message;
            }
        }
        else
        {
            Message = balAdminDetails.Message;
            return Message;
        }
    }
    #endregion
}