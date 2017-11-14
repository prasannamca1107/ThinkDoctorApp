using System;

using Xamarin.Forms;

namespace ThinkDoctor
{
	public interface IDataViewer
	{
		void showPhoto(string AttachmentName, byte[] AttachmentBytes);
		string ImageExists(string Filename, byte[] ImageData);
	}
}

