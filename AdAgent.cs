using System;
using AdAgent.Common;
using Tizen.Applications;
using Tizen.DA.Service.CoBA.Common;

namespace AdAgent
{
    class AdAgent : ServiceApplication
    {

        private Service service;
       
        protected override void OnCreate()
        {
            CoBACommon.Initialize("com.samsung.da.adagent", "AdAgent", "d_g.kang@samsung.com");
            CCLogger.Debug($"ENTER");
            base.OnCreate();
        }

        protected async override void OnAppControlReceived(AppControlReceivedEventArgs e)
        {
            CCLogger.Debug($"ENTER");
            base.OnAppControlReceived(e);
            CCLogger.Debug($"{e.ReceivedAppControl.CallerApplicationId}");

            try 
            {
                
                foreach (var key in e.ReceivedAppControl.ExtraData.GetKeys())
                {
                    CCLogger.Debug($"key is {key}, valuve is {e.ReceivedAppControl.ExtraData.Get<string>(key)}");

                    Resource resource = new Placements.AppDockResource();
                    
                    Service service = new Service(resource);
                    var result = await service.GetAdvertise();
                }
            } catch (Exception exception)
            {
                CCLogger.Debug($"exception is {exception}");
            }
            
        }

        protected override void OnDeviceOrientationChanged(DeviceOrientationEventArgs e)
        {
            base.OnDeviceOrientationChanged(e);
        }

        protected override void OnLocaleChanged(LocaleChangedEventArgs e)
        {
            base.OnLocaleChanged(e);
        }

        protected override void OnLowBattery(LowBatteryEventArgs e)
        {
            base.OnLowBattery(e);
        }

        protected override void OnLowMemory(LowMemoryEventArgs e)
        {
            base.OnLowMemory(e);
        }

        protected override void OnRegionFormatChanged(RegionFormatChangedEventArgs e)
        {
            base.OnRegionFormatChanged(e);
        }

        protected override void OnTerminate()
        {
            base.OnTerminate();
        }

        static void Main(string[] args)
        {
            AdAgent app = new AdAgent();
            app.Run(args);
        }
    }
}
