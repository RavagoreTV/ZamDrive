using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ZamkDb.ViewModels
{
	public class Registration
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Address { get; set; }

		[Required]
		public bool canBeDriver { get; set; }

		[Required]
		[Display(Name = "EmailAddress")]
		public string Email { get; set; }

		[Required]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[DataType(DataType.Password)]
		[Display(Name = "Confirm password")]
		[Compare("Password", ErrorMessage = "Password and confirmation password do not match")]
		public string ConfirmPassword { get; set; }
    }
}
