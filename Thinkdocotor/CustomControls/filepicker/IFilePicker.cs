﻿using System;
using System.Threading.Tasks;

namespace ThinkDoctor
{
	/// <summary>
	/// Interface for FilePicker
	/// </summary>
	public interface IFilePicker
	{
		Task<FileData> PickFile();

		Task<bool> SaveFile(FileData fileToSave);

		void OpenFile(string fileToOpen);

		void OpenFile(FileData fileToOpen);
	}
}
