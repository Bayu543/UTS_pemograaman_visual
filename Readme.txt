## 👤 Profil Mahasiswa

| Atribut         | Keterangan                |
| --------------- | ------------------------- |
| **Nama**        | Bayu Aji Yuwono           |
| **NIM**         | 312310xxx                 |
| **Kelas**       | TI.23.A.5                 |
| **Mata Kuliah** | Pemrograman Visual        |
| **Link Youtube** | https://youtu.be/xxxxx   |

---

# 🏫 Tugas UTS  
# 📘 Pustaka Raya — Deployment & Setup Guide

> Panduan instalasi & konfigurasi aplikasi **Pustaka Raya**  
> Berbasis **IIS**, **MongoDB**, dan **.NET Framework**

---

## ⚙️ Prasyarat

Pastikan environment kamu sudah memiliki:

- **Windows + IIS (Internet Information Services)**
- **.NET Runtime / Hosting Bundle** (sesuai versi proyek)
- **MongoDB**
- (Opsional) **Git** untuk clone project

---

## 🧩 1. Setup Database MongoDB

1. Pastikan service MongoDB sudah berjalan.  
2. Buka **MongoDB Compass**.  
3. Buat database baru bernama:  
   ```
   pustakaraya_db
   ```
4. Buat collection:
   - `books`
   - `members`
   - `transactions`
5. Masukkan contoh data awal menggunakan fitur **Insert Document** di Compass.

---

## 🖥️ 2. Deploy ke IIS

1. Buka **IIS Manager** di Windows.  
2. Tambahkan **Application Pool** baru:

   | Properti | Nilai |
   |-----------|--------|
   | Name | `PustakaRayaPool` |
   | .NET CLR Version | sesuai proyek (.NET 4.8 atau 6.0) |

3. Tambahkan **Website / Application** baru:  
   - **Physical path**: `C:\inetpub\wwwroot\pustakaraya`  
   - **Binding**: `http` — Port `8080`  
   - **Gunakan App Pool**: `PustakaRayaPool`

4. Set izin folder melalui **Command Prompt (Administrator):**
   ```bash
   icacls "C:\inetpub\wwwroot\pustakaraya" /grant "IIS AppPool\PustakaRayaPool":(OI)(CI)M /T
   ```

5. Jalankan website dan akses di browser:  
   👉 [http://localhost:8080/app#/](http://localhost:8080/app#/)

---

## 💾 3. Backup & Restore

| Jenis | Perintah |
|-------|-----------|
| **MongoDB Backup** | `mongodump --db pustakaraya_db -o C:\backup\` |
| **MongoDB Restore** | `mongorestore --db pustakaraya_db C:\backup\pustakaraya_db` |

---

## ✅ 4. Checklist Deploy

- [x] .NET Hosting Bundle terinstal  
- [x] IIS App Pool & Site aktif (port 8080)  
- [x] Connection string MongoDB sudah benar  
- [x] Folder permission diberikan untuk IIS  
- [x] Aplikasi dapat diakses di `http://localhost:8080/app#/`

---

## 🧭 5. Penjelasan Fungsi Tampilan UI Aplikasi

Berikut penjelasan tampilan antarmuka dari aplikasi **Pustaka Raya**, yang terhubung dengan **MongoDB** dan berjalan pada **IIS**.

---

### 🔐 1. Halaman Login
![Login](mockup/login.png)

> Digunakan untuk mengautentikasi pengguna sebelum masuk ke sistem.  
> Admin wajib login agar dapat mengelola data buku, anggota, dan transaksi.

---

### 🏠 2. Dashboard
![Dashboard](mockup/dashboard.png)

> Menampilkan ringkasan informasi perpustakaan seperti total buku, anggota, dan transaksi aktif.  
> Dari sini admin dapat menavigasi ke menu utama lainnya.

---

### 📚 3. Data Buku
![Data Buku](mockup/databuku.png)

> Berisi daftar seluruh buku yang ada di perpustakaan.  
> Admin dapat menambahkan, mengedit, atau menghapus data buku.  
> Saat ini, fitur ini **masih mengalami error pada koneksi ke MongoDB** dan sedang dalam tahap perbaikan.

---

### 👥 4. Data Karyawan / Anggota
![Data Karyawan](mockup/datakaryawan.png)

> Berfungsi untuk menampilkan data anggota atau karyawan yang memiliki akses ke sistem.  
> Saat ini menu ini masih **kosong**, karena belum selesai pada sisi backend.

---

### 📖 5. Peminjaman Buku
![Peminjaman](mockup/peminjaman.png)

> Fitur untuk mencatat transaksi peminjaman buku.  
> Admin memilih nama anggota dan buku yang dipinjam.  
> **Masih error** saat proses simpan data — dalam tahap debugging koneksi ke koleksi `transactions`.

---

### 🔁 6. Pengembalian Buku
![Pengembalian](mockup/pengembalian.png)

> Fitur untuk mengelola proses pengembalian buku yang telah dipinjam.  
> Dapat mencatat tanggal kembali dan menghitung keterlambatan.  
> Saat ini masih mengalami **error pada proses update data di MongoDB**.

---

### 📊 7. Laporan & Statistik
![Laporan](mockup/laporan.png)

> Menampilkan data rekap transaksi peminjaman dan pengembalian buku.  
> Fitur ini juga dapat diekspor menjadi file Excel atau PDF.

---

## 🔄 8. Alur Sistem Pustaka Raya

1. **Login** → Akses awal pengguna.  
2. **Dashboard** → Navigasi utama sistem.  
3. **Data Buku** → Pendataan koleksi buku.  
4. **Data Karyawan** → Pendataan anggota perpustakaan.  
5. **Peminjaman Buku** → Pencatatan peminjaman buku.  
6. **Pengembalian Buku** → Proses pengembalian buku.  
7. **Laporan** → Rekap semua transaksi.

---

## 👥 9. Skema Tim Pengembang

| Nama | Peran | Tanggung Jawab |
|------|-------|----------------|
| **Bayu Aji Yuwono** | Full Stack Developer | Analisis sistem, desain UI, pembuatan backend, konfigurasi IIS, dan pengujian sistem. |

---

## 🧩 10. Mockup Project

| Halaman | Preview |
|----------|----------|
| Dashboard | ![Dashboard](mockup/dashboard.png) |
| Data Buku | ![Data Buku](mockup/databuku.png) |
| Data Karyawan | ![Data Karyawan](mockup/datakaryawan.png) |
| Peminjaman Buku | ![Peminjaman](mockup/peminjaman.png) |
| Pengembalian Buku | ![Pengembalian](mockup/pengembalian.png) |
| Laporan | ![Laporan](mockup/laporan.png) |

---

## 📌 11. Status Proyek Saat Ini

- ✅ Login dan Dashboard sudah berfungsi.  
- ⚠️ Menu **Karyawan**, **Peminjaman**, dan **Pengembalian Buku** masih dalam tahap perbaikan.  
- ⚠️ Data Buku masih error dalam koneksi ke MongoDB.  
- 🔧 Proses debugging & pengujian web service sedang dilakukan.  

---

## 🏁 12. Kesimpulan

Sistem **Pustaka Raya** merupakan aplikasi berbasis web yang dirancang untuk mengelola data perpustakaan secara digital.  
Dengan dukungan **IIS**, **MongoDB**, dan **.NET**, sistem ini diharapkan dapat mempermudah proses administrasi buku, anggota, serta transaksi peminjaman dan pengembalian secara efisien.  
Proyek ini menjadi langkah awal menuju digitalisasi layanan perpustakaan yang cepat, aman, dan mudah digunakan.

---

© 2025 — *Dikembangkan oleh Bayu Aji Yuwono*
