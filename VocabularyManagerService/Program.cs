﻿using System;
using NamedPipeWrapper;
using System.Collections.Generic;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using NAudio.CoreAudioApi;
using VocabularyManagerService.Services;
using VolumeManagerService.Services;
using VocabularyManagerService.Interfaces;
using VocabularyManagerService.Commands;

namespace VolumeManagerService
{
    static class Program
    {
        static void Main()
        {
            var container = new SimpleInjector.Container();

            container.Register<IConnectionManagement, ConnectionManagement>();
            container.Register<ISystemVolumeService, SystemVolumeService>();

            //container.Register<ICommand, Commander>();
            //container.Register<ICommand, SetAudioCommand>();

            container.Verify();

            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[]
            {
                container.GetInstance<VocabularyManagerService>()
            };
#if DEBUG
            DebugService.RunInteractiveServices(ServicesToRun);
#else            
           
                ServiceBase.Run(ServicesToRun);
#endif
        }
    }
}
