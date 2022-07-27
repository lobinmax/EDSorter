using System;
using System.ServiceProcess;

namespace ED_Sorter_Service
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main(string[] args)
        {
            if (Environment.UserInteractive)
            {
                MainService service1 = new MainService();
                service1.TestStartupAndStop(args);
            }
            else
            {

                var ServicesToRun = new ServiceBase[]
                {
                    new MainService()
                };
                ServiceBase.Run(ServicesToRun);
            }

        }
    }
}
