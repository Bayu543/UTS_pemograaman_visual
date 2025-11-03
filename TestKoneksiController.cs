using System;
using System.Data.SqlClient;
using System.Configuration;
using System.Web.Mvc;

namespace NamaProject.Controllers
{
    public class TestKoneksiController : Controller
    {
        public ActionResult Index()
        {
            string connStr = ConfigurationManager.ConnectionStrings["UserDBContext"].ConnectionString;
            string hasil;

            using (SqlConnection conn = new SqlConnection(connStr))
            {
                try
                {
                    conn.Open();
                    hasil = "✅ Koneksi ke database BERHASIL!";
                }
                catch (Exception ex)
                {
                    hasil = "❌ Gagal konek: " + ex.Message;
                }
            }

            return Content(hasil);
        }
    }
}
