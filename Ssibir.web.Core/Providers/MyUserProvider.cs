//using Ssibir.DAL.Models;
//using Ssibir.DAL.Repositories.IRepositories;
//using Ssibir.web.Core.Providers.IProviders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Web.Security;

//namespace Ssibir.web.Core.Providers
//{
//	public class MyUserProvider : MembershipProvider, IUserProvider
//	{
//		public IClientRepository _clientRepository;

//		public IManagerRepository _managerRepository;

//		public MyUserProvider(IClientRepository clientRepository, IManagerRepository managerRepository)
//		{
//			_clientRepository = clientRepository;
//			_managerRepository = managerRepository;

//			AutoMapper.Mapper.CreateMap<Manager, MembershipUser>()
//				.ForMember(dest => dest.UserName, src => src.MapFrom(x =>
//					String.Concat(x.FirstName, " ", x.LastName)));

//			AutoMapper.Mapper.CreateMap<Client, MembershipUser>()
//				.ForMember(dest => dest.UserName, src => src.MapFrom(x =>
//					String.Concat(x.FirstName, " ", x.LastName)));
//		}

//		public override string ApplicationName
//		{
//			get
//			{
//				throw new NotImplementedException();
//			}
//			set
//			{
//				throw new NotImplementedException();
//			}
//		}

//		public override bool ChangePassword(string username, string oldPassword, string newPassword)
//		{
//			throw new NotImplementedException();
//		}

//		public override bool ChangePasswordQuestionAndAnswer(string username, string password, string newPasswordQuestion, string newPasswordAnswer)
//		{
//			throw new NotImplementedException();
//		}

//		public override MembershipUser CreateUser(string username, string password, string email, string passwordQuestion, string passwordAnswer, bool isApproved, object providerUserKey, out MembershipCreateStatus status)
//		{
//			throw new NotImplementedException();
//		}

//		public override bool DeleteUser(string username, bool deleteAllRelatedData)
//		{
//			throw new NotImplementedException();
//		}

//		public override bool EnablePasswordReset
//		{
//			get { throw new NotImplementedException(); }
//		}

//		public override bool EnablePasswordRetrieval
//		{
//			get { throw new NotImplementedException(); }
//		}

//		public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
//		{
//			throw new NotImplementedException();
//		}

//		public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize, out int totalRecords)
//		{
//			throw new NotImplementedException();
//		}

//		public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
//		{
//			throw new NotImplementedException();
//		}

//		public override int GetNumberOfUsersOnline()
//		{
//			throw new NotImplementedException();
//		}

//		public override string GetPassword(string username, string answer)
//		{
//			throw new NotImplementedException();
//		}

//		public override MembershipUser GetUser(string username, bool userIsOnline)
//		{
//			var client = _clientRepository.GetByName(username);
//			if (client != null)
//			{
//				return AutoMapper.Mapper.Map<MembershipUser>(client);
//				//return new MembershipUser();
//			}

//			var manager = _managerRepository.GetByName(username);
//			if (manager != null)
//			{
//				return AutoMapper.Mapper.Map<MembershipUser>(manager);
//			}
//			return null;
//		}

//		public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
//		{
//			throw new NotImplementedException();
//		}

//		public override string GetUserNameByEmail(string email)
//		{
//			throw new NotImplementedException();
//		}

//		public override int MaxInvalidPasswordAttempts
//		{
//			get { throw new NotImplementedException(); }
//		}

//		public override int MinRequiredNonAlphanumericCharacters
//		{
//			get { throw new NotImplementedException(); }
//		}

//		public override int MinRequiredPasswordLength
//		{
//			get { throw new NotImplementedException(); }
//		}

//		public override int PasswordAttemptWindow
//		{
//			get { throw new NotImplementedException(); }
//		}

//		public override MembershipPasswordFormat PasswordFormat
//		{
//			get { throw new NotImplementedException(); }
//		}

//		public override string PasswordStrengthRegularExpression
//		{
//			get { throw new NotImplementedException(); }
//		}

//		public override bool RequiresQuestionAndAnswer
//		{
//			get { throw new NotImplementedException(); }
//		}

//		public override bool RequiresUniqueEmail
//		{
//			get { throw new NotImplementedException(); }
//		}

//		public override string ResetPassword(string username, string answer)
//		{
//			throw new NotImplementedException();
//		}

//		public override bool UnlockUser(string userName)
//		{
//			throw new NotImplementedException();
//		}

//		public override void UpdateUser(MembershipUser user)
//		{
//			throw new NotImplementedException();
//		}

//		public override bool ValidateUser(string username, string password)
//		{
//			var user = _clientRepository.GetIdByNameAndPassword(username, password);

//			//_clientRepository.Save(new Client()
//			//{
//			//	Birth = DateTime.Now.AddYears(-12),
//			//	FirstName = "Client",
//			//	Login = "a",
//			//	Password = "aaaaa"
//			//});


//			if (user != null) { return true; }

//			var manager = _managerRepository.GetByNameAndPassword(username, password);
//			if (manager != null) { return true; }

//			return false;
//		}

//		public string GetDisplayName(string userName)
//		{
//			var client = _clientRepository.GetByName(userName);
//			if (client != null)
//				return client.DisplayName;
//			var manager = _managerRepository.GetByName(userName);
//			if (manager != null)
//				return manager.DisplayName;
//			return string.Empty;
//		}
//	}
//}
