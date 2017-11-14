using System;
using System.Globalization;
using System.Net;
using System.Net.Http;
//using FFImageLoading.Cache;
//using FFImageLoading.Forms;
using Xamarin.Forms;

namespace ThinkDoctor
{
	public class Config
	{
		public static string iconcolor = "#1ABC9C";
		public static string addressdetails = "";
        public static string concolor = "#63C3DA";
        public static string fontfamliyios = "micross";
        public static string fontfamliyandroid = "micross.ttf#micross";
        public static int mainFont = 10;
		public static string otp = "";
		public static string email = "";
		public static int user_Id = 0;
		public static DateTime exptime = DateTime.Now;
		public static bool clinicsaveflag = false;
		public static bool clinicupdateflag = false;
        public static bool consultinghours = false;
		public static string clock = "⏰";
		public static string morning = "☕";
		public static string aftnoon = "☀";
		public static string aftnoon1 = "🌞";
		public static string even = "☾  ";
        public static bool roomsaveflag = false;
        public static bool roomeditflag = false;

		public static bool test = false;


		public static string Api = "http://178.238.139.243/ThinkdocotorApi/api/DoctorRegsApi";

        public static string prof_Reg = "http://178.238.139.243/ThinkdocotorApi/api/RegistrationApi";

        public static string prof_Reg_id = "http://178.238.139.243/ThinkdocotorApi/api/RegistrationApi?id=";




	}
	public class consulting_services_clinicians_detailsinfo
	{
		public consulting_services_details[] consulting_services_details;
		public string futherdetails;
		public int consulting_id;
	}
	public class consulting_services_details
	{
		public int id { get; set; }
		public int userid { get; set; }
		public int consulting_id { get; set; }
		public int service_id { get; set; }
		public int created_by { get; set; }
		public int modified_by { get; set; }
		public DateTime created { get; set; }
		public DateTime modified { get; set; }
	}



	public class con_uploaddetails
	{
		public int userid { get; set; }
		public int consulting_id { get; set; }
		public string filename { get; set; }
		public string filetype { get; set; }
		public StreamContent stream { get; set; }
		public byte[] data { get; set;}


	}
	public class consulting_venues
	{
		public int id { get; set; }
		public string consulting_name { get; set; }
		public string address1 { get; set; }
		public string address2 { get; set; }
		public string address3 { get; set; }
		public string city_town { get; set; }
		public string county_state { get; set; }
		public int country { get; set; }
		public string postcode { get; set; }
		public string tel1 { get; set; }
		public string tel2 { get; set; }
		public string email1 { get; set; }
		public string email2 { get; set; }
		public bool diable_access { get; set; }
		public string parking { get; set; }
		public string parking_directions { get; set; }
		public string further_details { get; set; }
		public int created_by { get; set; }
		public int modify_by { get; set; }
		public DateTime created { get; set; }
		public DateTime modifyed { get; set; }
	}

public class envoc_data
{
	public string Name { get; set; }
	public string PhoneNumber { get; set; }	
	public string Email { get; set; }	
	public string Position { get; set; }
	public Urls[] Urls { get; set; }
	
}
	public class Urls
	{
		public string Type { get; set; }
		public string Link { get; set; }

		public Urls(string type, string link)
		{
			this.Type = type;
			this.Link = link;
		}
	}
	public class loginResponse
	{
		public string Status { get; set; }
		public string Userid { get; set; }
	}
	public class Responseerror
	{
		public string Status { get; set; }
		public string Message { get; set; }

	}
	public class Addressinfo
	{
		public Summaries[] Summaries { get; set; }
	}

public class Addressid
{
	public Address Address { get; set; }
}


	public class Address
	{
		public int AddressId { get; set; }
		public string AdministrativeCounty { get; set; }
		public string Barcode { get; set; }
		public string BuildingName { get; set; }
		public string BuildingNumber { get; set; }
		public string Company { get; set; }
		public string CountryName { get; set; }
		public string County { get; set; }
		public string DeliveryPointSuffix { get; set; }
		public string Department { get; set; }
		public string DependentLocality { get; set; }
		public string DoubleDependentLocality { get; set; }
		public int Easting { get; set; }
		public string Latitude { get; set; }
		public string LatitudeShort { get; set; }
		public string Line1 { get; set; }
		public string Line2 { get; set; }
		public string Line3 { get; set; }
		public string Line4 { get; set; }
		public string Line5 { get; set; }
		public string Longitude { get; set; }
		public string LongitudeShort { get; set; }
		public int Northing { get; set; }
		public string Pobox { get; set; }
		public string PostTown { get; set; }
		public string PostalCounty { get; set; }
		public string Postcode { get; set; }
		public string PrimaryStreet { get; set; }
		public string PrimaryStreetName { get; set; }
		public string PrimaryStreetType { get; set; }
		public string SecondaryStreet { get; set; }
		public string SecondaryStreetName { get; set; }
		public string SecondaryStreetType { get; set; }
		public string StreetAddress1 { get; set; }
		public string StreetAddress2 { get; set; }
		public string StreetAddress3 { get; set; }
		public string SubBuilding { get; set; }
		public string TraditionalCounty { get; set; }
		public string Type { get; set; }

	}

	public class Addressinfoerror
	{
		public Error[] Error { get; set; }

	}
	public class Error
	{
		public int Id { get; set; }
		public string Cause { get; set; }
		public string Description { get; set; }
		public string Resolution { get; set; }
	}
	public class Summaries
	{
		public int Id { get; set; }
		public string StreetAddress { get; set; }
		public string Place { get; set; }

	}
	public class addressviewmodel
	{
		public addressviewmodel(Summaries v)
		{
			this.Places = v.StreetAddress + "," + v.Place;
			this.Id = v.Id;
		}

		public int Id { get; set; }
		public string Places { get; set; }

	}
	public class Forgetpasswordresponse
	{

		public string Status { get; set; }
		public string otp { get; set; }
		public int userid { get; set; }
		public DateTime exptime { get; set; }

	}
	public class Forgetpassworderror
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
	public class Changedpasswordresponse
	{
		public string Status { get; set; }
		public string message { get; set; }

	}
	public class Changedpassworderror
	{
		public string Status { get; set; }
		public string Message { get; set; }
	}


	public class CheckItem
	{
		public string Name { get; set; }
	}

class SearchItems
{
	public SearchItems(string name, string price, string avalable)
	{
		this.Name = name;
		this.Price = price;
		this.Avalable = avalable;
	}
	public string Name { get; set; }
	public string Price { get; set; }
	public string Avalable { get; set; }
	
	}

	//Reg Doctors
public class Doctors
{



	public int id { get; set; }
	public string Fname { get; set; }
	public string Professionaltype { get; set; }
	public string typeofspecialist { get; set; }
	public int Gmcno { get; set; }
	public DateTime Dob { get; set; }
	public int Age { get; set; }
	public string Postalcode { get; set; }
	public string Add1 { get; set; }
	public string Add2 { get; set; }
	public string Add3 { get; set; }
	public string City { get; set; }
	public string County { get; set; }
	public string Country { get; set; }
	public string Cmyname { get; set; }
	public string Hmobile { get; set; }
	public string Wmobile { get; set; }
	public string mobile { get; set; }
	public string Wemail { get; set; }
	public string Hemail { get; set; }
	public string Professionaldetails { get; set; }
	public string ActivationCode { get; set; }
	public string Temp_Password { get; set; }
	public int Emailconform { get; set; }
	public int Status { get; set; }
	public DateTime Logintime { get; set; }
	public DateTime Logouttime { get; set; }
	public string Deviceid { get; set; }



}
	//get setting details

public class Userdetails
{
	public string FirstName { get; set; }
	public DateTime Dob { get; set; }
	public string PostCode { get; set; }
	public string AddressLine1 { get; set; }
	public string AddressLine2 { get; set; }
	public string AddressLine3 { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string HomeNo { get; set; }
	public string WorkNo { get; set; }
	public string MobileNo { get; set; }
	public string EmailID1 { get; set; }
	public string freetext { get; set; }
public clinicdetails[] clinicdetails { get; set; }
	public Doctor_document document { get; set; }
		public string Imgpath
		{
			get;
			set;
		}
public string imageUrl
{
	get
	{
		string s = Imgpath.Replace("\\", "/");
		string m = s.Replace("C:/inetpub/wwwroot", "http://178.238.139.243");
				Imgpath = m;
		return Imgpath;
	}
	set
	{
		Imgpath = value;
		// CachedImage.InvalidateCache(Imgpath, CacheType.Memory , false);
	}
}
 }
	public class profilepic
	{
		public string filename { get; set; }

		public string filepath{get;set;}

		public byte[] data { get; set; }
	
	}
	public class profileeditpic
	{
	public string filename { get; set; }

	public string filepath { get; set; }

	public byte[] data { get; set; }
	}
public class Doctor_document
{
	public int Id { get; set; }
	public int userid { get; set; }
	public string gmc_path { get; set; }
	public string indemnity_path { get; set; }
	public string appraisal_path { get; set; }
	public string logo_path { get; set; }
	public string signature { get; set; }
	public DateTime createdate { get; set; }
	public DateTime modifydate { get; set; } }

	//add clinic
public class Clinic_Detailsinfo
{
public clinicdetails[] clinicdetails { get; set; }	
	
	}
    public class consultingRoomlistinfo
    {
        public consulting_room[] consulting_room { get; set; }

    }
    public class consulting_room
    {
        public int id { get; set; }
        public int userid { get; set; }
        public int consulting_id { get; set; }
        public string consulting_room_title { get; set; }
        public int created_by { get; set; }
        public int modified_by { get; set; }
        public DateTime created { get; set; }
        public DateTime modifyed { get; set; }

    }
public class Consulting_Detailsinfo
{
	public consulting_documents[] consulting_documents { get; set; }

}

public class consulting_documents
{
	public int id { get; set; }
	public int userid { get; set; }
	public int consulting_id { get; set; }
	public string file_type { get; set; }
	public string filename { get; set; }
	public string filepath { get; set; }
	public string filesize { get; set; }
	public bool allow_public { get; set; }
	public int created_by { get; set; }
	public int modified_by { get; set; }
	public DateTime created { get; set; }
	public DateTime modifyed { get; set; }

 }
public class consulting_documentsStackviewmodel
{
		public consulting_documentsStackviewmodel(consulting_documents v)
		{
			this.cv = v;
			this.ID = v.id;
			this.filename = v.filename;
			this.filepath = v.filepath;
			this.filetype = v.file_type;

			if (filetype == "")
			{
				filetypeimg = "";
			}
			else if (filetype == "")
			{
				filetypeimg = "";
			}
			else if (filetype == "")
			{
				filetypeimg = "";
			}



			this.Filesizedate = v.filesize + "-" + v.modifyed.ToString("D");
			this.Allowpublic = v.allow_public;
	}


		public int ID { get; set; }
		public string filename { get; set; }
		public string filepath { get; set; }
		public string filetype { get; set; }
		public string filetypeimg { get; set; }
		public string Filesizedate { get; set; }
		public bool Allowpublic { get; set; }
		public consulting_documents cv { get; set; }

	
	}

	public class serviesinfo
	{
	public servies[] servies { get; set; }
	}

	public class servies
	{
		public int Id { get; set; }
		public string service_name { get; set; }
		public DateTime? created { get; set; }
		public DateTime? modified { get; set; } 

	}

public class clinicdetails
{
	public int Id { get; set; }
	public string clinic_name { get; set; }
	public string postalcode { get; set; }
	public string address1 { get; set; }
	public string address2 { get; set; }
	public string mobile_num { get; set; }
	public string landline { get; set; }
	public int userid { get; set; }

}
	public class Clinic_Details_edit
	{
		public int id { get; set; }
		public clinicdetails[] clinic_Details { get; set; }	

	}
public class Clinic_Details
{
	public int Id { get; set; }
	public string clinic_name { get; set; }
	public string postalcode { get; set; }
	public string address1 { get; set; }
	public string address2 { get; set; }
	public string mobile_num { get; set; }
	public string landline { get; set; }
	public int userid { get; set; }


}

public class ClinicStackviewmodel
{
public ClinicStackviewmodel(clinicdetails v)
	{
		this.ID = v.Id;
			this.editdetails = v.Id.ToString() + "$" + v.clinic_name + "$" + v.postalcode + "$" + v.address1 +"$"+v.address2+"$"+v.mobile_num+"$"+v.landline;
		this.Clinic_name = v.clinic_name ;
		this.Postalcode = v.postalcode;
		this.Address1 = v.address1 ;
		this.Address2 = v.address2;
		this.Mobile_num = v.mobile_num ;
		this.landline = v.landline ;

	}


		public int ID { get; set; }
		public string editdetails { get; set; }
	public string Clinic_name { get; set; }
	public string Postalcode { get; set; }
	public string Address1 { get; set; }
	public string Address2 { get; set; }
	public string Mobile_num { get; set; }
	public string landline { get; set; }
	}

    public class consulting_roomStackviewmodel
    {
        public consulting_roomStackviewmodel(consulting_room v)
        {
            this.Id = v.id;
            this.Userid = v.userid;
            this.Consulting_id = v.consulting_id;
            this.Consulting_room_title = v.consulting_room_title;
            this.editdetails = v.id.ToString() + "$" + v.consulting_id + "$" + v.consulting_room_title;

        }


        public int Id { get; set; }
        public int Userid { get; set; }
        public int Consulting_id { get; set; }
        public string Consulting_room_title { get; set; }
        public string editdetails { get; set; }
      
    }

public class CliniclsettingStackviewmodel
{
public CliniclsettingStackviewmodel(clinicdetails v)
	{
	
			this.Clinic_name = v.clinic_name;
			this.Id = v.Id;

	}

		public int Id { get; set; }
		public string Clinic_name { get; set; }
	
	}
	//Create slots

public class Create_Slots
{
	public int Id { get; set; }
	public string services { get; set; }
	public string appointment_type { get; set; }
	public int clinic_id { get; set; }
	public DateTime date { get; set; }
	public string start_time { get; set; }
	public string end_time { get; set; }
	public string breaktime { get; set; }
	public string appointment_length { get; set; }
	public int num_of_slots { get; set; }
	public string schedule { get; set; }
	public string optional { get; set; }
	public string access { get; set; }
	public DateTime? modifydate { get; set; }
	public DateTime? createddate { get; set; }
	
	}
public class DoctorReg
{
	public int id { get; set; }
	public string Title { get; set; }
	public string FirstName { get; set; }
	public string MiddleName { get; set; }
	public string LastName { get; set; }
	public string Professionaltype { get; set; }
	public string typeofspecialist { get; set; }
	public int Gmcno { get; set; }
	public DateTime Dob { get; set; }
	public string Gender { get; set; }
	public string NHSNo { get; set; }
	public string PostCode { get; set; }
	public string AddressLine1 { get; set; }
	public string AddressLine2 { get; set; }
	public string AddressLine3 { get; set; }
	public string City { get; set; }
	public string State { get; set; }
	public string Country { get; set; }
	public string HomeNo { get; set; }
	public string WorkNo { get; set; }
	public string MobileNo { get; set; }
	public string EmailID1 { get; set; }
	public string Email2 { get; set; }
	public string Age { get; set; }
	public string ParentName { get; set; }
	public string Relation { get; set; }
	public string ParentAddress { get; set; }
	public string ParentContactNo { get; set; }
	public string NxKintName { get; set; }
	public string NxtKinAddress { get; set; }
	public string NxtKinContactNo { get; set; }
	public string FileName { get; set; }
	public string FilePath { get; set; }

	public string ActivationCode { get; set; }
	public string Temp_Password { get; set; }
	public string Uniquecode { get; set; }
	public int? Emailconform { get; set; }
	public int? Status { get; set; }
	public DateTime? Logintime { get; set; }
	public DateTime? Logouttime { get; set; }
	public string Deviceid { get; set; }
	public int? temp_pasw_attempted { get; set; } }


}
public class deletefile
{
	public string gmc { get; set; }
	public string indemnity { get; set; }
	public string appraisal { get; set; }
	public string logo { get; set; }
	public string signature { get; set; }
}


public class consulting_hours
{
	public int id { get; set; }
	public int userid { get; set; }
	public int consulting_id { get; set; }
	public int weeks_id { get; set; }
	public bool open_close { get; set; }
	public bool work_24_7 { get; set; }
	public string morn_start { get; set; }
	public string morn_end { get; set; }
	public string aftn_start { get; set; }
	public string aftn_end { get; set; }
	public string evn_start { get; set; }
	public string evn_end { get; set; }
	public int created_by { get; set; }
	public int modified_by { get; set; }
	public DateTime created { get; set; }
	public DateTime modifyed { get; set; }
}
public class weeks
{
	public int id { get; set; }
	public string day_name { get; set; }
	public string day_img { get; set; }
}

public class consulting_hours_info
{
public consulting_hours_details[] consulting_hours_details { get; set; }

}
public class consulting_hours_details
{
	public int id { get; set; }
	public int userid { get; set; }
	public int consulting_id { get; set; }
	public int weeks_id { get; set; }
	public bool open_close { get; set; }
	public bool work_24_7 { get; set; }
	public string morn_start { get; set; }
	public string morn_end { get; set; }
	public string aftn_start { get; set; }
	public string aftn_end { get; set; }
	public string evn_start { get; set; }
	public string evn_end { get; set; }
	public string day_name { get; set; }
	public string day_img { get; set; }
}
public class consulting_hours_viewmodel
{
public static string clock = "\ud83d\udd50";
public static string morning = "☕";
public static string aftnoon = "☀";
public static string aftnoon1 = "🌞";
public static string even = "☾ ";
	public consulting_hours_viewmodel(consulting_hours_details c)
	{
		Id = c.id;
		Userid = c.userid;
		Consulting_id = c.consulting_id;
		Weeks_id = c.weeks_id;

		Open_close = c.open_close;
		if (c.open_close == true)
		{
			Heading = "Open";
			Headingcolor = Color.LimeGreen;
		}
		else
		{
			Heading = "Closed";
			Headingcolor = Color.Orange;
		}
		
		Work_24_7 = c.work_24_7;
		if (c.open_close == true)
		{
			if (Work_24_7 == true)
			{
				Openinghours = clock + "24/7";
			}
			else
			{
				Openinghours = "M-" + c.morn_start + "-" + c.morn_end + "\n" + "A-" + c.aftn_start + "-" + c.aftn_end + "\n" + "E-" + c.evn_start + "-" + c.evn_end;
			}
		}
		else
		{
			Openinghours = "---";
			
		}
		editdetails = c;
		Morn_start = c.morn_start;
		Morn_end = c.morn_end;
		Aftn_start = c.aftn_start;
		Aftn_end = c.aftn_end;
		Evn_start=c.evn_start;
		Evn_end = c.evn_end;
		Day_name = c.day_name;
		Day_img = c.day_img;

	}
	public int Id { get; set; }
	public int Userid { get; set; }
	public int Consulting_id { get; set; }
	public int Weeks_id { get; set; }
	public bool Open_close { get; set; }
	public bool Work_24_7 { get; set; }
	public string Heading { get; set; }
	public Color Headingcolor { get; set; }
	public string Openinghours { get; set; }
	public object  editdetails { get; set; }

	public string Morn_start { get; set; }
	public string Morn_end { get; set; }
	public string Aftn_start { get; set; }
	public string Aftn_end { get; set; }
	public string Evn_start { get; set; }
	public string Evn_end { get; set; }
	public string Day_name { get; set; }
	public string Day_img { get; set; }

}