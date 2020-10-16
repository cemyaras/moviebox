using MovieBox.Data.Models;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;
using System.Linq;

namespace MovieBox.Data.Core
{
    public class FetchService : IFetchService
    {
        public RespondModel<T> GetOutput<T>(string url, Dictionary<string, string> queryParameters = null, Method method = Method.GET, DataFormat format = DataFormat.Json) where T : class
        {
            var restClient = new RestClient();
            var restRequest = new RestRequest(url, method);

            if (queryParameters != null && queryParameters.Any())
            {
                foreach (var item in queryParameters)
                {
                    restRequest.AddQueryParameter(item.Key, item.Value);
                }
            }

            var restResponse = restClient.Execute(restRequest);
            if (restResponse.StatusCode == System.Net.HttpStatusCode.OK && restResponse != null && !string.IsNullOrWhiteSpace(restResponse.Content))
            {
                try
                {
                    var model = JsonConvert.DeserializeObject<T>(restResponse.Content);
                    return new RespondModel<T>
                    {
                        Object = model,
                        Success = true
                    };
                }
                catch (System.Exception ex)
                {

                    return new RespondModel<T>
                    {
                        Object = null,
                        Success = false
                    };
                }
            }

            return new RespondModel<T>
            {
                Object = null,
                Success = false
            };
        }
    }
}
