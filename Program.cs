using System.Diagnostics;

namespace TacticalBaconLinker
{
    internal static class Program
    {
        public static FormsManager formsManager = new FormsManager();

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.ThreadException += new ThreadExceptionEventHandler(LogErrors);
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(LogErrors);

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();

            Application.Run(formsManager.activeForm);
        }

        private static void LogErrors(object sender, EventArgs e)
        {
            Exception exception = new Exception("unbekannter Fehler");
            if (e != null)
            {
                if (e is ThreadExceptionEventArgs tArgs)
                    exception = tArgs.Exception;
                else if (e is UnhandledExceptionEventArgs uArgs)
                    exception = (Exception)uArgs.ExceptionObject;
            }

            string strException = GetException(exception);
            if (Debugger.IsAttached)
                throw exception;

            Utils.logError(strException);
        }

        private static string GetException(Exception ex)
        {
            if (ex == null)
                return "";

            string stException = ex.ToString();
            if (ex.InnerException != null)
                stException += Environment.NewLine + GetException(ex.InnerException);

            return stException;
        }

    }
}