using System;

namespace TaskPBO
{
    // ===================== SUPERCLASS =====================
    public class Orang
    {
        public string Nama { get; set; }
        public int Umur { get; set; }

        public Orang(string nama, int umur)
        {
            Nama = nama;
            Umur = umur;
        }

        public virtual void Aktivitas()
        {
            Console.WriteLine($"{Nama} sedang melakukan aktivitas sehari-hari.");
        }

        public virtual void InfoOrang()
        {
            Console.WriteLine($"Nama: {Nama} | Umur: {Umur} tahun");
        }
    }

    // ===================== PASIEN =====================
    public class Pasien : Orang
    {
        public string Keluhan { get; set; }

        public Pasien(string nama, int umur, string keluhan) : base(nama, umur)
        {
            Keluhan = keluhan;
        }

        public void CekKeluhan()
        {
            Console.WriteLine($"Keluhan {Nama}: {Keluhan}");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"{Nama} (pasien) sedang menunggu pemeriksaan.");
        }

        public override void InfoOrang()
        {
            base.InfoOrang();
            Console.WriteLine($"  Peran: Pasien | Keluhan: {Keluhan}");
        }
    }

    public class PasienAnak : Pasien
    {
        public PasienAnak(string nama, int umur, string keluhan) : base(nama, umur, keluhan) { }

        public void Menangis()
        {
            Console.WriteLine($"{Nama} menangis karena takut disuntik: huhuhu...");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"{Nama} (pasien anak) bermain di ruang tunggu anak sambil ditemani orang tua.");
        }

        public override void InfoOrang()
        {
            base.InfoOrang();
            Console.WriteLine("  Kategori: Pasien Anak");
        }
    }

    public class PasienDewasa : Pasien
    {
        public PasienDewasa(string nama, int umur, string keluhan) : base(nama, umur, keluhan) { }

        public void Konsultasi()
        {
            Console.WriteLine($"{Nama} berkonsultasi dengan dokter mengenai keluhan: {Keluhan}.");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"{Nama} (pasien dewasa) mengisi formulir pendaftaran dan antre di poliklinik.");
        }

        public override void InfoOrang()
        {
            base.InfoOrang();
            Console.WriteLine("  Kategori: Pasien Dewasa");
        }
    }

    // ===================== TENAGA MEDIS =====================
    public class TenagaMedis : Orang
    {
        public string Spesialisasi { get; set; }

        public TenagaMedis(string nama, int umur, string spesialisasi) : base(nama, umur)
        {
            Spesialisasi = spesialisasi;
        }

        public void CekSpesialis()
        {
            Console.WriteLine($"{Nama} berspesialisasi di bidang {Spesialisasi}.");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"{Nama} (tenaga medis) bertugas melayani pasien.");
        }

        public override void InfoOrang()
        {
            base.InfoOrang();
            Console.WriteLine($"  Peran: Tenaga Medis | Spesialisasi: {Spesialisasi}");
        }
    }

    public class Dokter : TenagaMedis
    {
        public Dokter(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi) { }

        public void Diagnosa()
        {
            Console.WriteLine($"Dr. {Nama} mendiagnosa pasien berdasarkan keahlian {Spesialisasi}.");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"Dr. {Nama} memeriksa pasien dan menulis resep obat.");
        }

        public override void InfoOrang()
        {
            base.InfoOrang();
            Console.WriteLine("  Jabatan: Dokter");
        }
    }

    public class Perawat : TenagaMedis
    {
        public Perawat(string nama, int umur, string spesialisasi) : base(nama, umur, spesialisasi) { }

        public void CekPasien()
        {
            Console.WriteLine($"Perawat {Nama} mengecek tekanan darah dan suhu tubuh pasien.");
        }

        public override void Aktivitas()
        {
            Console.WriteLine($"Perawat {Nama} merawat pasien dan membantu dokter.");
        }

        public override void InfoOrang()
        {
            base.InfoOrang();
            Console.WriteLine("  Jabatan: Perawat");
        }
    }

    // ===================== RUMAH SAKIT =====================
    public class RumahSakit
    {
        public string NamaRS { get; set; }
        private List<Orang> koleksiOrang = new List<Orang>();

        public RumahSakit(string namaRS)
        {
            NamaRS = namaRS;
        }

        public void TambahOrang(Orang orang)
        {
            koleksiOrang.Add(orang);
            Console.WriteLine($"[+] {orang.Nama} ditambahkan ke {NamaRS}.");
        }

        public void DaftarOrang()
        {
            Console.WriteLine($"\n=== Daftar Orang di {NamaRS} (total: {koleksiOrang.Count}) ===");
            int no = 1;
            foreach (Orang o in koleksiOrang)
            {
                Console.Write($"{no++}. ");
                o.InfoOrang();
            }
        }

        public List<Orang> GetOrang()
        {
            return koleksiOrang;
        }
    }

    // ===================== MAIN =====================
    class Program
    {
        static void Judul(string teks)
        {
            Console.WriteLine();
            Console.WriteLine("==================================================");
            Console.WriteLine(teks);
            Console.WriteLine("==================================================");
        }

        static void Main(string[] args)
        {
            // 1. Buat objek rumah sakit
            RumahSakit rs = new RumahSakit("RS Sehat Sentosa");

            // 2. Buat beberapa objek orang
            Orang umum = new Orang("Budi", 40);
            Dokter dokter = new Dokter("Andi", 45, "Penyakit Dalam");
            Perawat perawat = new Perawat("Siti", 30, "Perawatan Umum");
            PasienAnak anak = new PasienAnak("Dina", 7, "Demam tinggi");
            PasienDewasa dewasa = new PasienDewasa("Rudi", 35, "Sakit kepala");
            Pasien pasien = new Pasien("Wati", 28, "Batuk pilek");

            // 3. Tambahkan ke rumah sakit
            rs.TambahOrang(umum);
            rs.TambahOrang(dokter);
            rs.TambahOrang(perawat);
            rs.TambahOrang(anak);
            rs.TambahOrang(dewasa);
            rs.TambahOrang(pasien);

            // 4. Tampilkan semua data
            rs.DaftarOrang();

            // 5. Demonstrasikan polymorphism (satu pemanggilan, perilaku berbeda)
            Judul("Polymorphism: Aktivitas() pada seluruh koleksi");
            foreach (Orang o in rs.GetOrang())
            {
                o.Aktivitas();
            }

            // 6. Panggil method khusus
            Judul("Method khusus tiap kelas");
            dokter.Diagnosa();
            dokter.CekSpesialis();
            perawat.CekPasien();
            perawat.CekSpesialis();
            anak.CekKeluhan();
            anak.Menangis();
            dewasa.CekKeluhan();
            dewasa.Konsultasi();

            // ---------------- Soal 1 ----------------
            Judul("Soal 1: Aktivitas() pada objek Dokter dan Pasien");
            dokter.Aktivitas();
            pasien.Aktivitas();

            // ---------------- Soal 2 ----------------
            Judul("Soal 2: Diagnosa() pada objek Dokter");
            dokter.Diagnosa();

            // ---------------- Soal 3 ----------------
            Judul("Soal 3: Informasi lengkap objek Dokter");
            dokter.InfoOrang();
            Console.WriteLine($"(Akses langsung) Nama: {dokter.Nama}, Umur: {dokter.Umur}, Spesialisasi: {dokter.Spesialisasi}");

            // ---------------- Soal 4 ----------------
            Judul("Soal 4: Menangis() pada objek PasienAnak");
            anak.Menangis();

            // ---------------- Soal 5 ----------------
            Judul("Soal 5: Variabel bertipe Orang diisi objek Perawat");
            Orang orangPerawat = new Perawat("Maya", 27, "Keperawatan Anak");
            orangPerawat.Aktivitas();
            // orangPerawat.CekPasien();  // ERROR kompilasi: tipe Orang tidak punya CekPasien()
            ((Perawat)orangPerawat).CekPasien(); // bisa setelah casting ke Perawat

            Judul("Selesai");
            if (!Console.IsInputRedirected)
            {
                Console.WriteLine("Tekan tombol apa saja untuk keluar...");
                Console.ReadKey();
            }
        }
    }
}