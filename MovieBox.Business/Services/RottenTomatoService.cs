using MovieBox.Business.Utils;
using MovieBox.Data.Core;
using MovieBox.Data.Models;
using System.Collections.Generic;

namespace MovieBox.Business.Services
{
    public class RottenTomatoService : IRottenTomatoService
    {
        private readonly IFetchService _fetchService;
        private readonly string _baseUrl = Configuration.AppSettings("rottenTomatoesBaseUrl");

        public RottenTomatoService(IFetchService fetchService)
        {
            _fetchService = fetchService;
        }

        public SearchMovieOutputModel SearchMovies(string keyword, int pageSize, int page)
        {
            var queryParameters = new Dictionary<string, string>() {
                { "q", keyword },
                { "page_limit", pageSize.ToString() },
                { "page",page.ToString() }
            };

            var result = _fetchService.GetOutput<SearchMovieOutputModel>(_baseUrl, queryParameters);

            if (result.Success)
                return result.Object;

            return new SearchMovieOutputModel();
        }

        public MovieDetailsOutputModel GetMovieDetails(int id)
        {
            var url = $"{_baseUrl}/{id}";

            var result = _fetchService.GetOutput<MovieDetailsOutputModel>(url);

            if (result.Success)
                return result.Object;

            return null;
        }

        public BoxOfficeOutputModel GetBoxOfficeMovieList(string country = "tr", int limit = 10)
        {
            var url = $"{_baseUrl}/box_office";

            var queryParameters = new Dictionary<string, string>() {
                { "country", country },
                { "limit", limit.ToString() }
            };

            var result = _fetchService.GetOutput<BoxOfficeOutputModel>(_baseUrl);

            if (result.Success)
                return result.Object;

            return null;
        }
    }
}
