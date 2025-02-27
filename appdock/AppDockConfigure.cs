using System.Net.Http;
using System.Threading.Tasks;
using Tizen.DA.Service.CoBA.Common;

namespace AdAgent.Placements
{
    public class AppDockConfigure : Configure
    {
        protected override string Url { get; set; }

        protected override string Method { get; }

        protected override string Path { get; }
        public AppDockConfigure()
        {
            CCLogger.Debug($"ENTER");
            Url = "https://www.test.com";
            Method = "Get";
            Path = "/TileAd/v2";
        }
    }


}