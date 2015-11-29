using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using SendGrid;
using System.Net;
using Ssibir.MVC.Models.ViewModels;


namespace Ssibir.MVC.Helpers
{
	public class SendGridHelper
	{

		public NetworkCredential initCredentials()
		{
			// Create network credentials to access your SendGrid account
			var username = "azure_c371b33409c40998ae7188b4f981998c@azure.com";
			var pswd = "d7Uzhswcl7OTp6a";

			/* Alternatively, you may store these credentials via your Azure portal
			   by clicking CONFIGURE and adding the key/value pairs under "app settings".
			   Then, you may access them as follows: 
			   var username = System.Environment.GetEnvironmentVariable("SENDGRID_USER"); 
			   var pswd = System.Environment.GetEnvironmentVariable("SENDGRID_PASS");
			   assuming you named your keys SENDGRID_USER and SENDGRID_PASS */
			return new NetworkCredential(username, pswd);
		}

		public SendGridMessage createMail(string emailTo, TourRequest data)
		{
			// Create the email object first, then add the properties.
			var myMessage = new SendGridMessage();

			// Add the message properties.
			myMessage.From = new MailAddress(data.Email);

			//// Add multiple addresses to the To field.
			//List<String> recipients = new List<String>
			//{
			//	@"Jeff Smith <alex.sklv85@gmail.com>"
			//};

			//emailTo = "alex.sklv85@gmail.com";
			emailTo = "s5sibir@yandex.ru";

			myMessage.AddTo(emailTo);

			myMessage.Subject = String.Format("Заявка с сайта ssibir.ru от {0}.", data.UserName);

			//Add the HTML and Text bodies
			myMessage.Html = String.Format(@"<h2>Заявка с сайта ssibir.ru от {0}.</h2>
								<p><b>Имя:</b></p>
								<p>{0}</p>
								<p><b>Адрес электронной почты:</b></p>
								<p>{1}</p>
								<p><b>Телефон</b></p>
								<p>{2}</p>
								<p><b>Куда хочется:</b></p>
								<p>{3}</p>
								<p><b>Даты:</b></p>
								<p>с {4} по {5} </p>
								<p><b>Пожелания:</b></p>
								<p>{6}</p>
								<p><b>Заявка менеджеру:</b></p>
								<p>{7}</p>.
								<p><b>Дата заявки:</b></p>
								<p>{8}</p>", data.UserName, data.Email, data.Phone, data.Where ?? "не указано",
										   data.DepartureDate.HasValue ? data.DepartureDate.Value.Date.ToString() : "не указана",
										   data.ArrivalDate.HasValue ? data.ArrivalDate.Value.Date.ToString() : "не указана",
										   data.Wishes ?? "не указаны", data.ManagerName, data.CreatedDate);


			return myMessage;
		}

		public bool sendMail(SendGridMessage mail) {
			// Create credentials, specifying your user name and password.
			var credentials = initCredentials();

			// Create an Web transport for sending email.
			var transportWeb = new Web(credentials);
			
			// Send the email.
			// You can also use the **DeliverAsync** method, which returns an awaitable task.
			transportWeb.Deliver(mail);

			return true;
		}

	}
}