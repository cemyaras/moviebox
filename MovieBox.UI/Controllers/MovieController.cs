using MovieBox.Business.Services;
using System.Web.Mvc;

namespace MovieBox.Ui.Controllers
{
    public class MovieController : BaseController
    {
        private readonly IRottenTomatoService _service;
        public MovieController(IRottenTomatoService service)
        {
            _service = service;
        }

        public ActionResult Index()
        {
            var boxscoreList = _service.GetBoxOfficeMovieList();
            return View(boxscoreList);
        }

        public ActionResult Search(string keyword, int page = 1)
        {
            var model = _service.SearchMovies(keyword, pageSize, page);
            ViewBag.Page = page;
            ViewBag.MaxPageLimit = model.Total / pageSize;
            ViewBag.Keyword = keyword;

            return View(model);
        }

        public ActionResult Detail(int id)
        {
            var model = _service.GetMovieDetails(id);
            return View(model);
        }

        //public ActionResult BoxOffice()
        //{
        //    var boxscoreList = _service.GetBoxOfficeMovieList();
        //    return View(boxscoreList);
        //}
    }
}