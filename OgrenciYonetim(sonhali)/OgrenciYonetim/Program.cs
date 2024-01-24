using OgrenciYonetim;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

namespace OgrenciYonetimUygulamasi
{
    internal class Program
    {
        static List<Ogrenci> ogrenciler = new List<Ogrenci>(); // global değişken

        static void Main(string[] args)
        {
            Uygulama();
        }
        static void Uygulama()
        {
            SahteVeriEkle();
            //Menu();
            SecimAl();

        }

        static void SecimAl()
        {
            int maksimumDenemeSayisi = 10;
            int sayac = maksimumDenemeSayisi;
            while (true)
            {


                if (sayac == 0)
                {
                    Console.WriteLine("Üzgünüm sizi anlayamıyorum.Program sonlandırıldı.");
                    break;
                }

                Menu();           //  Her seçimde nelere basılacağını hatırlatmak için menu methodu buraya alındı. 

                Console.Write("Seçiminiz : ");
                string giris = Console.ReadLine().ToUpper();
                if (giris == "X" || giris == "4")
                {
                    Console.WriteLine("Çıkış yapıldı.");
                    break;

                }




                switch (giris)
                {
                    case "E":
                    case "1":
                        OgrenciEkle();
                        sayac = 10;
                        break;
                    case "L":
                    case "2":
                        OgrenciListele();
                        sayac = 10;
                        break;
                    case "S":
                    case "3":
                        OgrenciSil();
                        sayac = 10;
                        break;
                    default:
                        sayac--;
                        if (sayac != 0)
                        {
                            Console.WriteLine("Hatalı giriş yapıldı, tekrar deneyin! " + sayac + " hakkınız kaldı");
                        }
                        break;

                }


                Console.WriteLine();
            }

        }

        static void OgrenciEkle()
        {
            Ogrenci o = new Ogrenci();

            List<int> OgerenciListesindekiNolar = new List<int>();


            Console.WriteLine("1- Öğrenci Ekle ----------");
            Console.WriteLine((ogrenciler.Count + 1) + ". Öğrencinin");

            Console.Write("No: ");
            o.No = int.Parse(Console.ReadLine());




            foreach (Ogrenci item in ogrenciler)
            {
                OgerenciListesindekiNolar.Add(item.No);

            }

            while (OgerenciListesindekiNolar.Contains(o.No))
            {
                Console.WriteLine("Farklı bir numara girişi yapınız.");
                Console.Write("No: ");
                o.No = int.Parse(Console.ReadLine());
            }

            Console.Write("Adı: ");
            o.Ad = Console.ReadLine();
            o.Ad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(o.Ad.ToLower());
            Console.Write("Soyadı: ");
            o.Soyad = Console.ReadLine();
            o.Soyad = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(o.Soyad.ToLower());
            Console.Write("Şubesi: ");
            o.Sube = Console.ReadLine().ToUpper();

            Console.WriteLine();

            Console.Write("Öğrenciyi kaydetmek istediğinize emin misiniz? (E/H)  ");
            string secim = Console.ReadLine().ToUpper();

            if (secim == "E")
            {
                ogrenciler.Add(o);
                Console.WriteLine("Öğrenci eklendi.");
            }
            else
            {
                Console.WriteLine("Öğrenci eklenmedi.");
            }

            Console.WriteLine();

        }
        static void OgrenciListele()
        {
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Listelenecek öğrenci bulunamadı.");


            }
            else
            {
                Console.WriteLine("2- Öğrenci Listele-----------");
                Console.WriteLine();
                Console.WriteLine("Şube".PadRight(5) + "No".PadRight(7) + "Ad".PadRight(10) + "Soyad");
                Console.WriteLine("---------------------------------- ");

                foreach (Ogrenci item in ogrenciler)
                {
                    Console.WriteLine(item.Sube.PadRight(5) + item.No.ToString().PadRight(7) + item.Ad.PadRight(10) + item.Soyad);
                }

            }



        }
        static void OgrenciSil()
        {
            if (ogrenciler.Count == 0)
            {
                Console.WriteLine("Listede silinecek öğrenci yok.");
            }
            else
            {
                Console.WriteLine("3- Öğrenci Sil ----------");
                Console.WriteLine("Silmek istediğiniz öğrencinin");

                Console.Write("No: ");
                int no = int.Parse(Console.ReadLine());
                bool silmeKontrolDeğişkeni = true;

                Ogrenci ogr = null;

                foreach (Ogrenci item in ogrenciler)
                {
                    if (item.No == no)
                    {
                        ogr = item;
                        silmeKontrolDeğişkeni = false;
                        break;
                    }

                }
                while (silmeKontrolDeğişkeni)
                {
                    Console.WriteLine("Silmek istediğiniz numarada öğrenci bulunamadı.Tekrar deneyiniz.");
                    Console.Write("No: ");
                    no = int.Parse(Console.ReadLine());
                    foreach (Ogrenci item in ogrenciler)
                    {
                        if (item.No == no)
                        {
                            ogr = item;
                            silmeKontrolDeğişkeni = false;
                            break;
                        }

                    }

                }




                if (ogr != null)
                {
                    Console.WriteLine("Adı: " + ogr.Ad);
                    Console.WriteLine("Soyadı: " + ogr.Soyad);
                    Console.WriteLine("Şubesi: " + ogr.Sube);
                    Console.WriteLine();
                    Console.Write("Öğrenciyi silmek istediğinize emin misiniz? (E/H) ");

                    string secim = Console.ReadLine().ToUpper();

                    if (secim == "E")
                    {
                        ogrenciler.Remove(ogr);
                        Console.WriteLine("Öğrenci silindi");
                    }
                    else
                    {
                        Console.WriteLine("Öğrenci silme işlemini iptal ettiniz.");
                    }
                }


            }




        }
        static void Menu()
        {
            Console.WriteLine("Öğrenci Yönetim Uygulaması");
            Console.WriteLine("1 - Öğrenci Ekle(E)       ");
            Console.WriteLine("2 - Öğrenci Listele(L)    ");
            Console.WriteLine("3 - Öğrenci Sil(S)        ");
            Console.WriteLine("4 - Çıkış(X)              ");
            Console.WriteLine();
        }
        static void SahteVeriEkle()
        {
            Ogrenci o1 = new Ogrenci();
            o1.Ad = "Veli";
            o1.Soyad = "Gündüz";
            o1.No = 1;
            o1.Sube = "A";
            ogrenciler.Add(o1);

            Ogrenci o2 = new Ogrenci();
            o2.Ad = "Ali";
            o2.Soyad = "Yılmaz";
            o2.No = 2;
            o2.Sube = "B";
            ogrenciler.Add(o2);

            Ogrenci o3 = new Ogrenci();
            o3.Ad = "Ayşe";
            o3.Soyad = "Yıldız";
            o3.No = 3;
            o3.Sube = "C";
            ogrenciler.Add(o3);


        }

    }
}
