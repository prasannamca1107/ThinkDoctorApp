using System;
using Thinkdocotor.Models.TableClass;

namespace Thinkdocotor
{
	public class Forgetpassworderror
	{
		public string Status { get; set; }
		public string Message { get; set; }	
	}

	public class Forgetpasswordresponse
	{
		public string Status { get; set; }
		public string otp { get; set; }
		public int userid { get; set; }
		public DateTime exptime { get; set; }	
	}

	public class loginResponse
	{
		public string Status { get; set; }
        public users user { get; set; }
		//public string Userid { get; set; }	
	}

	public class Responseerror
	{
		public string Status { get; set; }
		public string Message { get; set; }	
	}

	public class otpvalidresponse
	{
		public string Status { get; set; }
		public string message { get; set; }
	}

	public class otpvaliderror
	{
		public string Status { get; set; }
		public string Message { get; set; }	
	}
}
