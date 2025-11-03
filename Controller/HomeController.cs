using System.Web.Mvc;

namespace WEBBAYU.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult TestDB()
        {
            return Content("Koneksi ke database berhasil!");
        }
    }
}
