using Tizen.DA.Service.CoBA.Common;

namespace AdAgent.Placements
{
    public class AppDockAdvertise : Advertise
    {
        protected override string Url { get; set; }
        protected override string Path { get; }
        protected override string Method { get => "Get"; }

        
        public AppDockAdvertise()
        {
            CCLogger.Debug($"ENTER");
            if (Tizen.System.Information.TryGetValue("tizen.org/system/model_name", out string model_name) is true)
            {
                CCLogger.Debug($"model_name is {model_name}");
            }
/*
            if (Tizen.System.Information.TryGetValue("tizen.org/system/model_name", out string model_name) is true)
            {
                CCLogger.Debug($"model_name is {model_name}");
            }
*/
            if (Tizen.System.Information.TryGetValue("tizen.org/system/build.model", out string build_model) is true)
            {
                CCLogger.Debug($"version_build is {build_model}");
            }

            if (Tizen.System.Information.TryGetValue("tizen.org/system/build.date", out string build_date) is true)
            {
                CCLogger.Debug($"build_date is {build_date}");
            }

            if (Tizen.System.Information.TryGetValue("tizen.org/system/build.id", out string build_id) is true)
            {
                CCLogger.Debug($"build_id is {build_id}");
            }

            
            if (Tizen.System.Information.TryGetValue("developer.samsung.com/system/store_model", out string store_model) is true)
            {
                CCLogger.Debug($"store_model is {store_model}");
            }

            
            if (Tizen.System.Information.TryGetValue("developer.samsung.com/system/store_mcc", out string store_mcc) is true)
            {
                CCLogger.Debug($"store_mcc is {store_mcc}");
            }
            
            if (Tizen.System.Information.TryGetValue("developer.samsung.com/system/store_mnc", out string store_mnc) is true)
            {
                CCLogger.Debug($"store_mnc is {store_mnc}");
            }

            if (Tizen.System.Information.TryGetValue("developer.samsung.com/system/product_model", out string product_model) is true)
            {
                CCLogger.Debug($"product_model is {product_model}");
            }
            
            if (Tizen.System.Information.TryGetValue("developer.samsung.com/system/product_id", out string product_id) is true)
            {
                CCLogger.Debug($"product_id is {product_id}");
            }
            Parameters = new System.Collections.Generic.Dictionary<string, string>();
            Parameters.Add("pid", "9037");
            Parameters.Add("Modelid", model_name);
            //Parameters.Add("Modelcode", product_id);
            //16_HAWKM_FHD
            Parameters.Add("Modelcode", "16_HAWKM_FHD");
            Parameters.Add("psid", Interop.PSID);
        }

        
    }


}