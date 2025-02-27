namespace AdAgent
{
    public class AppDockConfigureResponse
    {
        [Newtonsoft.Json.JsonPropertyAttribute("rsp")]
        public virtual Response response { get; set; }
    }

    public class Response
    {
        [Newtonsoft.Json.JsonPropertyAttribute("stat")]
        public virtual string status { get; set; }
       
        [Newtonsoft.Json.JsonPropertyAttribute("enableAd")]
        public virtual string enableAd { get; set; }
       
        [Newtonsoft.Json.JsonPropertyAttribute("realTimeAd")]
        public virtual string realTimeAd { get; set; }
       
        [Newtonsoft.Json.JsonPropertyAttribute("enableAdMenu")]
        public virtual string enableAdMenu { get; set; }
       
        [Newtonsoft.Json.JsonPropertyAttribute("adServerUrl")]
        public virtual string adServerUrl { get; set; }
       
        [Newtonsoft.Json.JsonPropertyAttribute("adServerBlankUrl")]
        public virtual string adServerBlankUrl { get; set; }
       
        [Newtonsoft.Json.JsonPropertyAttribute("maxRequestCnt")]
        public virtual string maxRequestCnt { get; set; }
    }
}