using System.Web.Mvc;
using BookShop.Proxies;
using BookShop.Contracts;
using System.Collections.Generic;
using System.Linq;

namespace BookShop.Client.Controllers
{
    public class HomeController : Controller
    {
        private BookStoreClient bookClient;
        private BookGenreClient genreClient;

        public HomeController()
        {
            bookClient = new BookStoreClient();
            genreClient = new BookGenreClient();
        }

        public ActionResult Index()
        { 
            var genre = genreClient.GetAll().ToList();
            SelectList selectList = new SelectList(genre, "Id", "GenreName");
            ViewBag.Genres = selectList;

            return View(bookClient.GetAll());
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            return View(bookClient.GetItem(id));
        }
        [HttpPost]
        public ActionResult Delete(BookData book)
        {
            bookClient.Delete(book);
            return Redirect("/Home/Index");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            var genre = genreClient.GetAll().ToList();
            SelectList selectList = new SelectList(genre, "Id", "GenreName");
            ViewBag.Genres = selectList;
            return View(bookClient.GetItem(id));
        }

        [HttpPost]
        public ActionResult Edit(BookData book)
        {
            bookClient.Update(book);
            return Redirect("/Home/Index");
        }

        public ActionResult Create()
        {
            var genre = genreClient.GetAll().ToList();
            SelectList selectList = new SelectList(genre, "Id", "GenreName");
            ViewBag.Genres = selectList;
            return View();
        }

        [HttpPost]
        public ActionResult Create(BookData book)
        {
            bookClient.Add(book);
            return Redirect("/Home/Index");
        }
    }
}