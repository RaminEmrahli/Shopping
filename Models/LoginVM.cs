﻿using System.ComponentModel.DataAnnotations;

namespace Shopping.Models
{
	public class LoginVM
	{
		[EmailAddress]
		public string Email { get; set; }
		[Required]
		public string Password { get; set; }
		
	}
}
