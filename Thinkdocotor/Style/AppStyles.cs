using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Thinkdocotor.Models.TableClass;
using Xamarin.Forms;

namespace Thinkdocotor
{
	public class AppStyles
	{
		
        public static Color btnColor = Color.FromHex("#2ecc71");
        public static Color btcom = Color.FromHex("#8F13FD");

        public static Color AppBGColor = Color.FromHex("3A527C");
        public static Color menuBGcolor = Color.FromRgb(44, 45, 47);
        public static Color menuForecolor = Color.White;

        static string countryCodesUrl = "http://178.238.139.243/MedicalPracticeApi/api/CountryApi";
        static List<master_countrycodes> countries;
        public static async Task<List<master_countrycodes>> countries_list()
        {
            if (countries == null)
            {
                await getCountriesList();
            }
            return countries;
        }

        static async Task getCountriesList()
        {
            try
            {
                HttpClient httpclient = new HttpClient();
                string cc_string = await httpclient.GetStringAsync(countryCodesUrl);
                List<master_countrycodes> ccl = JsonConvert.DeserializeObject<List<master_countrycodes>>(cc_string);

                countries = ccl;
            }
            catch (Exception ex)
            {
                return;
            }
        }

        public static ResourceDictionary test()
		{
			ResourceDictionary rd = new ResourceDictionary();


			var labelColor = new Style(typeof(Label))
			{
				Setters =
				{
					new Setter { Property = Label.TextColorProperty,   Value = Color.Teal },
					new Setter { Property = Label.FontSizeProperty,   Value = Device.GetNamedSize(NamedSize.Large,typeof(Label)) }
				}
			};
			rd.Add("labelColor",labelColor);


			var CPButton = new Style(typeof(Button))
			{
				Setters =
				{
					new Setter { Property = Button.BackgroundColorProperty,   Value = btnColor },
					new Setter { Property = Button.HorizontalOptionsProperty,   Value = LayoutOptions.Fill },
					new Setter { Property = Button.VerticalOptionsProperty,   Value = LayoutOptions.FillAndExpand },
					new Setter { Property = Button.BorderWidthProperty,   Value = 1 },
					new Setter { Property = Button.BorderRadiusProperty,   Value = 10 },
                    new Setter { Property = Button.BorderColorProperty,   Value = Color.White },
                    new Setter { Property = Button.TextColorProperty,   Value = Color.White }
				}
			};
			rd.Add("CPButton", CPButton);

			var BCButton = new Style(typeof(Button))
			{
				Setters =
				{
					new Setter { Property = Button.BackgroundColorProperty,   Value = btcom },
					new Setter { Property = Button.BorderWidthProperty,   Value = 1 },
					new Setter { Property = Button.BorderRadiusProperty,   Value = 10 },
					new Setter { Property = Button.BorderColorProperty,   Value = btcom },
					new Setter { Property = Button.TextColorProperty,   Value = Color.White }
				}
			};
			rd.Add("BCButton", BCButton);






          

            return rd;
		}
	}
}
