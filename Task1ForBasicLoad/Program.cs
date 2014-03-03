using System;
using System.Collections.Generic;
using System.Windows.Forms;
using ESRI.ArcGIS.esriSystem;
using System.Threading;

namespace Task1ForBasicLoad
{
    static class Program
    {
        private static LicenseInitializer m_AOLicenseInitializer = new Task1ForBasicLoad.LicenseInitializer();
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //ESRI License Initializer generated code.
            m_AOLicenseInitializer.InitializeApplication(new esriLicenseProductCode[] { esriLicenseProductCode.esriLicenseProductCodeEngine },
            new esriLicenseExtensionCode[] { esriLicenseExtensionCode.esriLicenseExtensionCodeDataInteroperability });
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Thread thread = new Thread(new ThreadStart(ShowSplash));
            thread.Start();
            Application.Run(new Main());
            //ESRI License Initializer generated code.
            //Do not make any call to ArcObjects after ShutDownApplication()
            m_AOLicenseInitializer.ShutdownApplication();
        }
        static void ShowSplash()
        {
            Application.Run(new welcome());
        }
    }
}