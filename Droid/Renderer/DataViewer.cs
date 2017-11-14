using Android.Content;
using Android.Webkit;
using Android.Widget;
using System;
using System.IO;

using Xamarin.Forms;
using ThinkDoctor.Droid;

[assembly: Dependency(typeof(DataViewer))]
namespace ThinkDoctor.Droid
{
public class DataViewer : IDataViewer
{
	public void showPhoto(string AttachmentName, byte[] AttachmentBytes)
	{
		string dirPath = Xamarin.Forms.Forms.Context.GetExternalFilesDir( global::Android.OS.Environment.DirectoryPictures).Path;
		var FileName = AttachmentName;
		Java.IO.File file = new Java.IO.File(dirPath, FileName);

		if (!file.Exists())
		{
			var filename = Path.Combine(dirPath, AttachmentName);
			File.WriteAllBytes(filename, AttachmentBytes);
		}

		Device.BeginInvokeOnMainThread(() =>
		{
				//var oDir = Xamarin.Forms.Forms.Context.FilesDir.AbsolutePath;
			 global::Android.Net.Uri uri =  global::Android.Net.Uri.FromFile(file);
			Intent intent = new Intent(Intent.ActionView);
			String mimeType = MimeTypeMap.Singleton.GetMimeTypeFromExtension(MimeTypeMap.GetFileExtensionFromUrl((string)uri).ToLower());
			intent.SetDataAndType(uri, mimeType);

			intent.SetFlags(ActivityFlags.ClearWhenTaskReset | ActivityFlags.NewTask);

			try
			{
				Xamarin.Forms.Forms.Context.StartActivity(intent);
			}
			catch (System.Exception ex)
			{
				Toast.MakeText(Xamarin.Forms.Forms.Context, "No Application Available to View this file", ToastLength.Short).Show();
			}
		});
	}

	public string ImageExists(string FileName, byte[] Imagedata)
	{
		string dirPath = Xamarin.Forms.Forms.Context.GetExternalFilesDir( global::Android.OS.Environment.DirectoryPictures).Path;

		Java.IO.File file = new Java.IO.File(dirPath, FileName);

		if (!file.Exists())
		{
			var filename = Path.Combine(dirPath, FileName);
			File.WriteAllBytes(filename, Imagedata);
			return filename;
		}
		else
		{
			var filename = Path.Combine(dirPath, FileName);
			return filename;
		}
	}
}
}