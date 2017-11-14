using System;
namespace ThinkDoctor
{
	public class FilePickerEventArgs : EventArgs
	{
		public byte[] FileByte { get; set; }

		public string FileName { get; set; }

		public string FilePath { get; set; }

		FileData data = new FileData();

		public FilePickerEventArgs()
		{

		}

		public FilePickerEventArgs(byte[] fileByte)
		{
			FileByte = fileByte;
		}

		public FilePickerEventArgs(byte[] fileByte, string fileName, string filepath)
		{
			FileByte = fileByte;
			FileName = fileName;
			FilePath = filepath;

			data.FileName = fileName;
			data.FilePath = filepath;
		}


	}
}

