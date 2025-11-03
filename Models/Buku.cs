using System;

namespace WEBBAYU.Models
{
    public class Buku
    {
        public int Id { get; set; }
        public string KodeBuku { get; set; }
        public string Judul { get; set; }
        public string Pengarang { get; set; }
        public string Penerbit { get; set; }
        public int TahunTerbit { get; set; }
        public string Kategori { get; set; }
        public int JumlahStok { get; set; }
        public string LokasiRak { get; set; }
        public DateTime TanggalInput { get; set; } = DateTime.Now;
    }
}
