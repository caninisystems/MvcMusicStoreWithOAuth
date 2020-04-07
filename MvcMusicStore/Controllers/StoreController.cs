using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MvcMusicStore.Models;

namespace MvcMusicStore.Controllers
{
    public class StoreController : Controller
    {
        MusicStoreEntities storeDb = new MusicStoreEntities();

        //
        // GET: /Store/
        public ActionResult Index()
        {
            var genres = storeDb.Genres.ToList();
            return View(genres);
        }
        //
        // GET: /Store/Browse?genre=Disco
        public ActionResult Browse(string genre)
        {
            // Retrieve Genre and its Associated Albums from database
            var genreModel = this.storeDb.Genres.Include("Albums").Single(g => g.Name == genre); ;

            return View(genreModel);
        }
        //
        // GET: /Store/Details/5
        public ActionResult Details(int id)
        {
            var store = this.storeDb.Albums;
            var album = this.storeDb.Albums.Find(id);

            return View(album);
        }
    }
}