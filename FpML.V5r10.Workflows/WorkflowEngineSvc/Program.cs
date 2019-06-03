﻿using System.ServiceProcess;

namespace WorkflowEngineSvc
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            var servicesToRun = new ServiceBase[] 
                                              { 
                                                  new WorkflowEngineService() 
                                              };
            ServiceBase.Run(servicesToRun);
        }
    }
}
