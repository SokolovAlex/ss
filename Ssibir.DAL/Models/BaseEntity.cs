using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Ssibir.DAL.Models
{
	public abstract class BaseEntity
	{
		public Guid Id { get; set; }

		public string key { get; set; }

		protected BaseEntity()
		{
			Id = Guid.Empty;
			key = String.Empty;
		}

		protected BaseEntity(Guid id)
		{
			Id = id;
			key = String.Empty;
		}

		public bool IsNew()
		{
			return Id == Guid.Empty;
		}
	}
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
	public sealed class ValidatePasswordLengthAttribute : ValidationAttribute
	{
		private const string _defaultErrorMessage = "'{0}' must be at least {1} characters long.";
		private readonly int _minCharacters = 5;                  ///TODO Config

		public ValidatePasswordLengthAttribute()
			: base(_defaultErrorMessage)
		{
		}
		public override string FormatErrorMessage(string name)
		{
			return String.Format(CultureInfo.CurrentCulture, ErrorMessageString,
				name, _minCharacters);
		}

		public override bool IsValid(object value)
		{
			string valueAsString = value as string;
			return (valueAsString != null && valueAsString.Length >= _minCharacters);
		}
	}
}
