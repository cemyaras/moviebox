using MovieBox.Data.Models;

namespace MovieBox.Business.Services
{
    public interface IRottenTomatoService
    {
        SearchMovieOutputModel SearchMovies(string keyword, int pageSize, int page);
        MovieDetailsOutputModel GetMovieDetails(int id);
        BoxOfficeOutputModel GetBoxOfficeMovieList(string country = "tr", int limit = 10);
    }
}
