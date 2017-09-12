﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Email
    {
        public static string Error = "";
        //public Email() { }
        public static bool sendEmail(string _to,string _name, string password, DateTime _dateTime)
        {
            try
            {
               
                string _subject = ("Your Account Details are: ");
                string Body = ("<p>Dear: "+_name+" </p>" +
                    "<p>Your account successfully created. And your username and password is given below</p>" +
                    "<br />UserName: " + _to +
                    "<br />Password: " + password +
                    "<br />Created Date/Time: " + _dateTime +
                    "<br />Please visit www.segura.com.au to logIn"+
                    "<p>Important:</p>" +
                    "<p> - Contact you company for further details. </p>" +
                    "<p> - Please login to manage your profile.</p>"+
                    "<p> - Please do not reply to this E-mail.</p>"+
                    "<br/> <br/>" +
                    "<p>Copyrights. www.Segura.com.au");
                Email.masterEmail(_to, _subject, Body);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool companySignUpNotification(string _to, string _name, string password, DateTime _dateTime)
        {

            try
            {
                string _subject = ("Wellcome to Segura. Health and safety application.");
                string Body = ("<p>Dear: " + _name + " </p>" +
                    "<p>Your account has been created. And your details are given below. Please wait for account authentication from Administrator.</p>" +
                    "<p>Shortly, you will be contacted and activated after authentication. thanks for your patience.</p>"+
                    "<br />UserName: " + _to +
                    "<br />Created Date/Time: " + _dateTime +
                    "<br />Please visit www.segura.com.au to logIn" +
                    "<p>Important:</p>" +
                    "<p> - Do not reply to this Email.</p>" +
                    "<p> - Please login to manage your profile.</p>" +
                    "<br/> <br/>" +
                    "<p>Copyrights. www.Segura.com.au");
                Email.masterEmail(_to, _subject, Body);
                return true;
            }
            catch
            {
                return false;
            }
        }
        public static bool companyActivation(string _to, string _name)
        {

            try
            {
                string _subject = ("Congratulation your account is active now.");
                string Body = ("<p>Dear: " + _name + " </p>" +
                    "<p>Your account has been made active. You can log on and manage your profile. </p>" +
                    "<br />UserName: " + _to +
                    "<br />Feel free to contact us."+
                    "<br />Please visit www.segura.com.au to logIn" +
                    "<p>Important:</p>" +
                    "<p> - Do not reply to this Email.</p>" +
                    "<p> - Please login to manage your profile.</p>" +
                    "<br/> <br/>" +
                    "<p>Copyrights. www.Segura.com.au");
                Email.masterEmail(_to, _subject, Body);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static bool companyDeActivation(string _to, string _name)
        {

            try
            {
                string _subject = ("Your account is de-active now.");
                string Body = ("<p>Dear: " + _name + " </p>" +
                    "<p>Your account has been made de-active. Please contact administrator for further inquiry. </p>" +
                    "<br />UserName: " + _to +
                    "<br />Feel free to contact us." +
                    "<br />Please visit www.segura.com.au to logIn" +
                    "<p>Important:</p>" +
                    "<p> - Do not reply to this Email.</p>" +
                    "<p> - Please login to manage your profile.</p>" +
                    "<br/> <br/>" +
                    "<p>Copyrights. www.Segura.com.au");
                Email.masterEmail(_to, _subject, Body);
                return true;
            }
            catch(Exception ex)
            {
                Email.Error = ex.Message;
                return false;
            }
        }

        public static bool SendPasswordResetEmail(string _to, string UserName, string UniqueId)
        {

            try
            {
                string _subject = ("Your account's reset password link.");
                string Body = ("<p>Dear: " + UserName + " </p>" +
                    "<p> Please click the following link to reset Your password.</p>" +
                    "<br/> <br/>" +
                    "<br />http://web167.surf.studiocoast.com.au/changePasswordLink.aspx?uid=" + UniqueId+
                    
                    "<br/> <br/>" +
                    "<p>Copyrights. www.Segura.com.au");
                Email.masterEmail(_to, _subject, Body);
                return true;
            }
            catch
            {
                return false;
            }
        }

        private static void masterEmail(string _to,string _subject, string _body)
        {
            MailMessage _mail = new MailMessage();
            _mail.To.Add(_to);
            _mail.From = new MailAddress("noreply@segura.com.au");
            _mail.Subject = _subject;
            
            _mail.Body = _body;
            _mail.IsBodyHtml = true;
            SmtpClient _smtp = new SmtpClient();
            _smtp.Host = "planet.studiocoast.com.au"; //Or Your SMTP Server Address
            _smtp.Port = 26;
            _smtp.Credentials = new System.Net.NetworkCredential("no-reply@segura.com.au", "Judo2petrol54voice5");

            //Or your Smtp Email ID and Password
            _smtp.EnableSsl = true;
            _smtp.Send(_mail);
        }


        public void Close()
        {
            throw new NotImplementedException();
        }
    }
}
