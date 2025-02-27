using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Tizen.DA.Service.CoBA.Common;

namespace AdAgent.Requests
{
    public abstract class Request
    {
        protected readonly HttpClient httpClient;
        protected abstract string Url { get; set; }
        protected abstract string Path { get;  }
        protected abstract string Method { get; }
        public IDictionary<string, string> Parameters { get; set; }

        public virtual async Task<TResponse> ExecuteAsync<TResponse>()
        {
            CCLogger.Debug("ENTER");
            var request = CreateRequest();
            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.SendAsync(request, CancellationToken.None).ConfigureAwait(false))
                {
                    return ParseResponse<TResponse>(response).Result;
                }
            }
        }
        
        protected HttpRequestMessage CreateRequest()
        {
            CCLogger.Debug("ENTER");
            StringBuilder stringBuilder = new StringBuilder(Url);
            stringBuilder.Append(Path);
            if (Parameters != null)
            {
                //stringBuilder.Append('?');
                stringBuilder.Append(stringBuilder.ToString().Contains("?") ? "&" : "?");
                stringBuilder.Append(String.Join("&", Parameters.Select(
                    x => string.IsNullOrEmpty(x.Value) ?
                        Uri.EscapeDataString(x.Key) :
                        String.Format("{0}={1}", Uri.EscapeDataString(x.Key), Uri.EscapeDataString(x.Value)))
                        .ToArray()));
            }
            CCLogger.Debug(stringBuilder.ToString());
            return new HttpRequestMessage(new HttpMethod(Method), new Uri(stringBuilder.ToString()));
        }

        protected virtual async Task<TResponse> ParseResponse<TResponse>(HttpResponseMessage response)
        {
            CCLogger.Debug("ENTER");
            CCLogger.Debug($"response.StatusCode is {response.StatusCode}");
            if (response.IsSuccessStatusCode)
            {
                var text = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                CCLogger.Debug($"text is {text}");
                var responseObj = JsonConvert.DeserializeObject<Dictionary<string, object>>(text);
                foreach (var item in responseObj)
                {
                    CCLogger.Debug($"key is {item.Key}, value is {item.Value}");
                }
                var serializedResponse = JsonConvert.SerializeObject(responseObj);
                using (JsonTextReader reader = new JsonTextReader(new StringReader(serializedResponse)))
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    return jsonSerializer.Deserialize<TResponse>(reader);
                }
            }
            else
            {
                Dictionary<string, object> responseObj = new Dictionary<string, object>();
                var serializedResponse = JsonConvert.SerializeObject(responseObj);
                using (JsonTextReader reader = new JsonTextReader(new StringReader(serializedResponse)))
                {
                    JsonSerializer jsonSerializer = new JsonSerializer();
                    return jsonSerializer.Deserialize<TResponse>(reader);
                }
            }
        }
    }
}