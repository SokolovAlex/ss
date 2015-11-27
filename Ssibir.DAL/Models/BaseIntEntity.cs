using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ssibir.DAL.Models
{
    public abstract class BaseIntEntity
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

		public string key { get; set; }

        protected BaseIntEntity()
        {
            Id = 0;
			key = String.Empty;
        }

        public bool IsNew()
        {
            return Id == 0;
        }
    }
}
