using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Provider;
using Android.Database;
using Java.IO;
using Android.Net;
using Android.Webkit;


namespace ThinkDoctor.Droid
{
	public class IOUtil
	{

		public static String getPath(Context context, global::Android.Net.Uri uri)
		{

			bool isKitKat = Build.VERSION.SdkInt >= global::Android.OS.BuildVersionCodes.Kitkat;

			// DocumentProvider
			if (isKitKat && DocumentsContract.IsDocumentUri(context, uri))
			{
				// ExternalStorageProvider
				if (isExternalStorageDocument(uri))
				{
					String docId = DocumentsContract.GetDocumentId(uri);
					String[] split = docId.Split(':');
					String type = split[0];

					if ("primary".Equals(type, StringComparison.OrdinalIgnoreCase))
					{
						return global::Android.OS.Environment.ExternalStorageDirectory + "/" + split[1];
					}

					// TODO handle non-primary volumes
					else if ("content".Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase))
					{
						return getDataColumn(context, uri, null, null);
					}
					else if ("file".Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase))
					{
						return uri.Path;
					}
				}
				// DownloadsProvider
				else if (isDownloadsDocument(uri))
				{

					String id = DocumentsContract.GetDocumentId(uri);
					global::Android.Net.Uri contentUri = ContentUris.WithAppendedId(
							global::Android.Net.Uri.Parse("content://downloads/public_downloads"), long.Parse(id));

					return getDataColumn(context, contentUri, null, null);
				}
				// MediaProvider
				else if (isMediaDocument(uri))
				{
					String docId = DocumentsContract.GetDocumentId(uri);
					String[] split = docId.Split(':');
					String type = split[0];

					global::Android.Net.Uri contentUri = null;
					if ("image".Equals(type))
					{
						contentUri = MediaStore.Images.Media.ExternalContentUri;
					}
					else if ("video".Equals(type))
					{
						contentUri = MediaStore.Video.Media.ExternalContentUri;
					}
					else if ("audio".Equals(type))
					{
						contentUri = MediaStore.Audio.Media.ExternalContentUri;
					}

					String selection = "_id=?";
					String[] selectionArgs = new String[] {
					split[1]
			};

					return getDataColumn(context, contentUri, selection, selectionArgs);
				}
			}
			// MediaStore (and general)
			else if ("content".Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase))
			{
				return getDataColumn(context, uri, null, null);
			}
			// File
			else if ("file".Equals(uri.Scheme, StringComparison.OrdinalIgnoreCase))
			{
				return uri.Path;
			}

			return null;
		}

		public static String getDataColumn(Context context, global::Android.Net.Uri uri, String selection,
		String[] selectionArgs)
		{

			ICursor cursor = null;
			String column = "_data";
			String[] projection = {
				column
			};

			try
			{
				cursor = context.ContentResolver.Query(uri, projection, selection, selectionArgs,
						null);
				if (cursor != null && cursor.MoveToFirst())
				{
					int column_index = cursor.GetColumnIndexOrThrow(column);
					return cursor.GetString(column_index);
				}
			}
			finally
			{
				if (cursor != null)
					cursor.Close();
			}
			return null;
		}

		/**
 * @param uri The Uri to check.
 * @return Whether the Uri authority is ExternalStorageProvider.
 */
		public static bool isExternalStorageDocument(global::Android.Net.Uri uri)
		{
			return "com.android.externalstorage.documents".Equals(uri.Authority);
		}

		/**
         * @param uri The Uri to check.
         * @return Whether the Uri authority is DownloadsProvider.
         */
		public static bool isDownloadsDocument(global::Android.Net.Uri uri)
		{
			return "com.android.providers.downloads.documents".Equals(uri.Authority);
		}

		/**
         * @param uri The Uri to check.
         * @return Whether the Uri authority is MediaProvider.
         */
		public static bool isMediaDocument(global::Android.Net.Uri uri)
		{
			return "com.android.providers.media.documents".Equals(uri.Authority);
		}

		public static byte[] readFile(String file)
		{
			try
			{
				return readFile(new File(file));
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.Write(ex);
				return new byte[0];
			}
		}

		public static byte[] readFile(File file)
		{
			// Open file
			RandomAccessFile f = new RandomAccessFile(file, "r");
			try
			{
				// Get and check length
				long longlength = f.Length();
				int length = (int)longlength;
				if (length != longlength)
					throw new IOException("File size exceeds what is allowed!");
				// Read file and return data
				byte[] data = new byte[length];
				f.ReadFully(data);
				return data;
			}
			catch (Exception ex)
			{
				System.Diagnostics.Debug.Write(ex);
				return new byte[0];
			}
			finally
			{
				f.Close();
			}
		}

		public static string GetMimeType(string url)
		{
			String type = null;
			String extension = MimeTypeMap.GetFileExtensionFromUrl(url);

			if (extension != null)
			{
				type = MimeTypeMap.Singleton.GetMimeTypeFromExtension(extension);
			}

			return type;
		}
	}
}