using System.Threading.Tasks;
using AdAgent.Advertises;
using AdAgent.Configures;
using Tizen.DA.Service.CoBA.Common;

namespace AdAgent
{
    public class Service
    {
        Common.Resource Resource;

        public Service(Common.Resource resource)
        {
            CCLogger.Debug("ENTER");
            Resource = resource;            
        }
    
       
        public async Task<AdvertiseResponse> GetAdvertise()
        {
            var configure = await Resource.Configure.ExecuteAsync<ConfigureResponse>();
            return await Resource.Advertise.ExecuteAsync<AdvertiseResponse>();

        }
    }
}