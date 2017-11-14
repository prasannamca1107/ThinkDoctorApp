using System;
using Xamarin.Forms;
using ThinkDoctor.Droid;

[assembly: Dependency(typeof(CrossFilePicker))]
namespace ThinkDoctor.Droid
{
  /// <summary>
  /// Cross platform FilePicker implemenations
  /// </summary>
  public class CrossFilePicker : ICrossFilePicker
	{
		static Lazy<IFilePicker> Implementation = new Lazy<IFilePicker>(() => CreateFilePicker(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

		/// <summary>
		/// Current settings to use
		/// </summary>
		public static IFilePicker Current
		{
			get
			{
				var ret = Implementation.Value;
				if (ret == null)
				{
					throw NotImplementedInReferenceAssembly();
				}
				return ret;
			}
		}

		static IFilePicker CreateFilePicker()
		{
			return new FilePickerImplementation();
		}

		internal static Exception NotImplementedInReferenceAssembly()
		{
			return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the NuGet package from your main application project in order to reference the platform-specific implementation.");
		}

		IFilePicker ICrossFilePicker.Current()
		{
			return Current;
		}
	}
}
