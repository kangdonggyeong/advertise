using System.Net;
using AdAgent.Requests;

namespace AdAgent.Common
{
    public abstract class Resource
    {
        protected Service service;

        public abstract string Placement { get; }
        public abstract Configure Configure { get; }
        public abstract Advertise Advertise { get; }

        /*
        public async virtual System.Threading.Tasks.Task<AdvertiseResponse> Fetch()
        {
            CCLogger.Debug("[ad] ENTER");
            ConfigureResponse configureResponse = await Configure.Fetch();
            CCLogger.Debug("[ad] configure fetched");
            
            ControlDB<ConfigureData> db = new ControlDB<ConfigureData>();
            var configureData = db.Get(Placement);
            if (configureData == null)
            {
                int index = db.Alloc();
                configureData = new ConfigureData();
                configureData.Id = index;
                configureData.AdvertiseId = Placement;
            }
            configureData.Data = configureResponse.Response.Url;
            db.Update(configureData);

            AdvertiseResponse advertiseResponse = await Advertise.Fetch();
            return advertiseResponse;
            CCLogger.Debug("[ad] advertise fetched");
            string response = JsonConvert.SerializeObject(advertiseResponse);
            CCLogger.Debug($"[ad] resposne is {response}");
            CCLogger.Debug($"[ad] advertise id is {advertiseResponse.Ad.Info.ID}");

            ControlDB<AdvertiseData> adb = new ControlDB<AdvertiseData>();
            var advertiseData = adb.Get(advertiseResponse.Ad.Info.ID);
            if (advertiseData == null)
            {
                int index = adb.Alloc();
                advertiseData = new AdvertiseData();
                advertiseData.Id = index;
                advertiseData.AdvertiseId = advertiseResponse.Ad.Info.ID;
            }
            advertiseData.Data = response;
            adb.Update(advertiseData);
        }
        public abstract void ConfigureFetch();
        public abstract void AdvertiseFetch();
        */
    }
}