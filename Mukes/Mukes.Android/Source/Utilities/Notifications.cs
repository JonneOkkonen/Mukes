using Android.App;
using Android.Content;

namespace Mukes.Droid
{
    public static class Notifications
    {
        /// <summary>
        /// Creates and shows a spinner ProgressDialog in the given Context.
        /// </summary>
        /// <param name="context">A Context to which the dialog will be created.</param>
        /// <param name="message">The main message shown on the dialog.</param>
        /// <param name="title">Title of the dialog. If left unspecified it will be substituted with a default value from the Context's resources.</param>
        /// <returns>The created ProgressDialog.</returns>
        public static ProgressDialog CreateProgressSpinner(this Context context, string message, string title = null)
        {
            ProgressDialog progress = new ProgressDialog(context);
            progress.SetProgressStyle(ProgressDialogStyle.Spinner);
            progress.Indeterminate = true;
            progress.SetCancelable(false);
            progress.SetMessage(message);
            progress.SetTitle(title ?? "");
            progress.Show();
            return progress;
        }

        /// <summary>
        /// Creates an AlertDialog to the given Context. Show() must be called for the returned dialog to make it visible.
        /// </summary>
        /// <param name="context">A Context to which the dialog will be created.</param>
        /// <param name="message">The main message shown on the alert.</param>
        /// <param name="title">Title of the dialog. If left unspecified it will be substituted with a default value from the Context's resources.</param>
        /// <param name="buttonText">Text shown on the button. If left unspecified it will be substituted with a default value from the Context's resources.</param>
        /// <returns>The created AlertDialog</returns>
        public static AlertDialog CreateAlert(this Context context, string message, string title = null, string buttonText = null)
        {
            AlertDialog.Builder dialog = new AlertDialog.Builder(context);
            AlertDialog alert = dialog.Create();
            alert.SetTitle(title ?? context.GetString(Resource.String.alertTitle));
            alert.SetMessage(message);
            alert.SetButton(buttonText ?? context.GetString(Resource.String.alertButton), (c, ev) => { });
            return alert;
        }
    }
}