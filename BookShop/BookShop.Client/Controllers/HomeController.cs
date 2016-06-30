using System.Web.Mvc;
using BookShop.Proxies;
using BookShop.Contracts;

namespace BookShop.Client.Controllers
{
    public class HomeController : Controller
    {
        private BookStoreClient bookClient;

        public HomeController()
        {
            bookClient = new BookStoreClient();
        }

        public ActionResult Index()
        {
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