# APL2007M4BankAccount

## Deskripsi Proyek
Proyek ini adalah aplikasi simulasi rekening bank yang mencakup implementasi kelas `BankAccount` untuk mengelola rekening bank, transaksi, dan fitur terkait. Proyek ini juga mencakup pengujian unit menggunakan framework xUnit untuk memastikan bahwa fungsi-fungsi dalam aplikasi bekerja dengan benar.

## Struktur Proyek
- **BankAccountClass/**  
  Berisi implementasi utama aplikasi, termasuk kelas `BankAccount` dan program utama (`Program.cs`).
  
  - `BankAccount.cs`:  
    Mengimplementasikan kelas `BankAccount` yang memiliki properti seperti nomor rekening, saldo, nama pemilik, jenis rekening, dan tanggal pembukaan. Kelas ini juga memiliki metode untuk melakukan kredit, debit, transfer, menghitung bunga, dan mencetak laporan.

  - `Program.cs`:  
    Berisi logika untuk membuat sejumlah rekening bank secara acak, melakukan transaksi (kredit, debit, transfer), dan mencetak laporan transaksi.

  - `BankAccount.csproj`:  
    File konfigurasi proyek untuk aplikasi utama, menggunakan .NET 9.0.

- **BankAccount.UnitTests/**  
  Berisi pengujian unit untuk kelas `BankAccount` menggunakan framework xUnit.

  - `BankAccountTest.cs`:  
    Berisi berbagai pengujian unit untuk memverifikasi fungsi-fungsi utama dalam kelas `BankAccount`, seperti kredit, debit, transfer, dan perhitungan bunga.

  - `BankAccount.UnitTests.csproj`:  
    File konfigurasi proyek untuk pengujian unit, termasuk referensi ke paket-paket seperti `xunit`, `coverlet.collector`, dan `Microsoft.NET.Test.Sdk`.

- **APL2007M4BankAccount.sln**  
  File solusi Visual Studio yang menggabungkan proyek utama (`BankAccountClass`) dan proyek pengujian unit (`BankAccount.UnitTests`).

## Fitur Utama
1. **Kelas BankAccount**  
   - Properti:  
     - `AccountNumber`: Nomor rekening unik.
     - `Balance`: Saldo rekening.
     - `AccountHolderName`: Nama pemilik rekening.
     - `AccountType`: Jenis rekening (tabungan, giro, dll.).
     - `DateOpened`: Tanggal pembukaan rekening.
   - Metode:  
     - `Credit(double amount)`: Menambahkan saldo ke rekening.
     - `Debit(double amount)`: Mengurangi saldo dari rekening jika saldo mencukupi.
     - `Transfer(BankAccount toAccount, double amount)`: Mentransfer saldo ke rekening lain dengan validasi.
     - `CalculateInterest(double interestRate)`: Menghitung bunga berdasarkan saldo.
     - `PrintStatement()`: Mencetak laporan rekening.

2. **Program Utama**  
   - Membuat 20 rekening bank dengan data acak.
   - Melakukan 100 transaksi acak (kredit atau debit) untuk setiap rekening.
   - Melakukan transfer antar rekening dengan validasi.
   - Menampilkan laporan transaksi di konsol.

3. **Pengujian Unit**  
   - Menguji berbagai skenario seperti kredit, debit, transfer, dan perhitungan bunga.
   - Memastikan validasi seperti saldo tidak mencukupi atau batas transfer antar pemilik berbeda.

## Cara Menjalankan Proyek
1. **Menjalankan Aplikasi Utama**  
   - Buka solusi `APL2007M4BankAccount.sln` di Visual Studio.
   - Set proyek `BankAccountClass` sebagai proyek startup.
   - Jalankan aplikasi untuk melihat simulasi transaksi rekening bank di konsol.

2. **Menjalankan Pengujian Unit**  
   - Buka solusi `APL2007M4BankAccount.sln` di Visual Studio.
   - Jalankan semua pengujian unit dari Test Explorer untuk memastikan semua fungsi bekerja dengan benar.

## Teknologi yang Digunakan
- **Bahasa Pemrograman**: C#
- **Framework**: .NET 9.0
- **Framework Pengujian**: xUnit
- **Alat Pengujian**: Coverlet untuk pengukuran cakupan kode

## Catatan
- Pastikan Anda memiliki .NET SDK versi 9.0 atau lebih baru untuk menjalankan proyek ini.
- Pengujian unit mencakup berbagai skenario untuk memastikan keandalan aplikasi.
