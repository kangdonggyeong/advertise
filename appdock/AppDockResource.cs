using Tizen.DA.Service.CoBA.Common;

namespace AdAgent.Placements
{
    public class AppDockResource : Common.Resource
    {   
        public override Configure Configure { get; }
        public override Advertise Advertise { get; }
        public override string Placement { get { return "AppDock"; } }

        public AppDockResource() 
        {
            CCLogger.Debug("ENTER");
            Configure = new AppDockConfigure();
            Advertise = new AppDockAdvertise();
        }
    }
}