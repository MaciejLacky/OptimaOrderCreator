using OptimaBaseForm.Presenters;
using OptimaBaseForm.Views;
using OptimaBaseForm.Views.Interfaces;

namespace OptimaBaseForm
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            IMainView view = new MainView();
            new MainPresenter(view);
            Application.Run((Form)view);
        }
    }
}