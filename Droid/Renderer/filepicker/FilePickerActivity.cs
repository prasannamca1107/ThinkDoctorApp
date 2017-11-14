using System;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using System.Threading.Tasks;
using Android.Provider;
using Android.Database;

namespace ThinkDoctor.Droid
{
    [Activity(ConfigurationChanges = global::Android.Content.PM.ConfigChanges.Orientation | global::Android.Content.PM.ConfigChanges.ScreenSize)]
    [global::Android.Runtime.Preserve(AllMembers = true)]
    public class FilePickerActivity : Activity
    {
        private Context context;
        private Task<Tuple<string, bool>> path;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            this.context =global:: Android.App.Application.Context;

            Bundle b = (savedInstanceState ?? Intent.Extras);

            Intent intent = new Intent(Intent.ActionGetContent);
            intent.SetType("*/*");

            intent.AddCategory(Intent.CategoryOpenable);
            try
            {
                StartActivityForResult(Intent.CreateChooser(intent, "Select the file to be sent"),
                      0);
            }
            catch (System.Exception exAct)
            {
                System.Diagnostics.Debug.Write(exAct);
            }
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);

            if (resultCode == Result.Canceled)
            {
                // Notify user file picking was cancelled.
                OnFilePickCancelled();
                Finish();
            }
            else
            {
                System.Diagnostics.Debug.Write(data.Data);
                try
                {
                    var _uri = data.Data;

                    string filePath = IOUtil.getPath(this.context, _uri);

                    if (string.IsNullOrEmpty(filePath))
                        filePath = _uri.Path;

                    var file = IOUtil.readFile(filePath);

                    var fileName = GetFileName(this.context, _uri);

                    OnFilePicked(new FilePickerEventArgs(file, fileName, filePath));
                }
                catch (System.Exception readEx)
                {
                    // Notify user file picking failed.
                    OnFilePickCancelled();
                    System.Diagnostics.Debug.Write(readEx);
                }
                finally
                {
                    Finish();
                }
            }
        }

        string GetFileName(Context context, global::Android.Net.Uri uri)
        {

            String[] projection = { MediaStore.MediaColumns.DisplayName };

            ContentResolver cr = context.ContentResolver;
            string name = "";
            ICursor metaCursor = cr.Query(uri, projection, null, null, null);
            if (metaCursor != null)
            {
                try
                {
                    if (metaCursor.MoveToFirst())
                    {
                        name = metaCursor.GetString(0);
                    }
                }
                finally
                {
                    metaCursor.Close();
                }
            }
            return name;
        }

        internal static event EventHandler<FilePickerEventArgs> FilePicked;
        internal static event EventHandler<EventArgs> FilePickCancelled;

        private static void OnFilePickCancelled()
        {
	        FilePickCancelled?.Invoke(null, null);
        }

        private static void OnFilePicked(FilePickerEventArgs e)
        {
            var picked = FilePicked;
            if (picked != null)
                picked(null, e);
        }
    }
}