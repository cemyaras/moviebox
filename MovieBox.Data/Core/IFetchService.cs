using MovieBox.Data.Models;
using RestSharp;
using System.Collections.Generic;

namespace MovieBox.Data.Core
{
    public interface IFetchService
    {
        RespondModel<T> GetOutput<T>(string url, Dictionary<string, string> parameters = null, Method method = Method.GET, DataFormat format = DataFormat.Json) where T : class;
    }
}
