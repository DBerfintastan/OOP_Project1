/****************************************************************************
**					     SAKARYA ÜNİVERSİTESİ
**				BİLGİSAYAR VE BİLİŞİM BİLİMLERİ FAKÜLTESİ
**				    BİLGİSAYAR MÜHENDİSLİĞİ BÖLÜMÜ
**				   NESNEYE DAYALI PROGRAMLAMA DERSİ
**					     2019-2020 BAHAR DÖNEMİ
**	
**				ÖDEV NUMARASI..........:  01
**				ÖĞRENCİ ADI............:  DENİZ BERFİN TAŞTAN
**				ÖĞRENCİ NUMARASI.......:  B181210010
**              DERSİN ALINDIĞI GRUP...:  1-D
****************************************************************************/
using System;
using System.IO;

namespace B181210010
{
    
       class Program
        {
            static void Main(string[] args)
            {
                string[] isim = { "Ahmet", "Mehmet", "Senem", "Bedirhan", "Semiha", "Eda", "Sena ", "Selin", "Ali", "Bahar", "Özlem", "Ömer", "Buğra", "Alparslan", "Elif", "Tuğçe" };
                string[] soyisim = { "ŞEN", "KANDEMİR", "ÇEVİK", "ERKURAN", "TÜTEN", "ÖZTÜRK", "VURAL", "YÜCEL", "SÖNMEZ", "ERTEKİN", "DEDE", "UYANIK", "ASLAN", "AKBULUT", "ORHON", "UZ", "YAVUZ", "ERDEM", "KULAÇ", "KAYA", "SELVİ", "AKPINAR", "ABACIOĞLU", "ÇAY", "IŞIK", "ÖZER", "ÖZDEMİR", "TAHTACI" };
                
                string dosyaYaz = @"ogrenciler.txt";
                FileStream fs = new FileStream(dosyaYaz, FileMode.OpenOrCreate, FileAccess.Write); 
                StreamWriter sw = new StreamWriter(fs); // program çalıştığında ogrenciler.txt adında bir dosya oluşturur.

                Random rastgelesayi = new Random(); // rastgele değer atamak için Random sınıfını kullanmak için nesne oluşturduk.

                int numara, notOdev1, notOdev2, notVize, notFinal, no1, no2;

                double ortalama;

                int AA = 0, BA = 0, BB = 0, CB = 0, CC = 0, DC = 0, DD = 0, FD = 0, FF = 0;

                sw.WriteLine("10    10    30     50");

                for (int i = 0; i < 100; i++)
                {
                    numara = rastgelesayi.Next(0, 9999);
                    notOdev1 = rastgelesayi.Next(0, 100);
                    notOdev2 = rastgelesayi.Next(0, 100);
                    notVize = rastgelesayi.Next(0, 100);
                    notFinal = rastgelesayi.Next(0, 100);
                    no1 = rastgelesayi.Next(0, isim.Length);
                    no2 = rastgelesayi.Next(0, soyisim.Length); // İsim, soyisim, numara, notlar gibi verileri rastgele olarak yukarıda oluşturduğumuz diziden çektik.
                    sw.WriteLine(isim[no1] + " " + soyisim[no2] + " " + Convert.ToInt32(numara) + "     " + Convert.ToInt32(notOdev1) + " " + Convert.ToInt32(notOdev2) + " " + Convert.ToInt32(notVize) + " " + Convert.ToInt32(notFinal)); //çektiğimiz verileri dosyaya yazdırdık.
                    ortalama = (notOdev1 * 0.1 + notOdev2 * 0.1 + notVize * 0.3 + notFinal * 0.5);
                    if (ortalama >= 90)
                        AA = AA + 1;
                    else if (ortalama >= 85)
                        BA = BA + 1;
                    else if (ortalama >= 80)
                        BB = BB + 1;
                    
                    else if (ortalama >= 75)
                        CB = CB + 1;
                    else if (ortalama >= 65)
                        CC = CC + 1;
                    else if (ortalama >= 58)
                        DC = DC + 1;
                    else if (ortalama >= 50)
                        DD = DD + 1;
                    else if (ortalama >= 40)
                        FD = FD + 1;
                    else
                        FF = FF + 1;
                } //Ortalama hesaplayıp hangi öğrenciye hangi harf notu girileceğini hesapladık.
                sw.Close();
                fs.Close(); 
                Console.WriteLine("Ortalama Hesaplamak İstiyor musunuz?");
                Console.WriteLine("Eğer Cevabınız 'Evet' ise 'E' tuşuna basınız.");
                var basilanTus = Console.ReadKey(); //Kullanıcıdan klavyeden bir değer girmesini istedik.

            if (basilanTus.Key == ConsoleKey.E) //Eğer girilen değer 'e' ise dosyaya yazma işlemini yapacak.
            {
                string dosyayaYaz = @"sonuclar.txt";
                FileStream i = new FileStream(dosyayaYaz, FileMode.OpenOrCreate, FileAccess.Write);
                StreamWriter j = new StreamWriter(i); // sonuclar.txt dosyası oluşturup ortaya çıkan verileri değerleri vs. dosyaya yazar.

                int kisiSayisi = AA + BA + BB + CB + CC + DC + DD + FF + FD;

                j.WriteLine("AA notu alan kisi sayisi:" + AA + " " + "%" + (double)AA / kisiSayisi * 100);
                j.WriteLine("BA notu alan kisi sayisi:" + BA + " " + "%" + (double)BA / kisiSayisi * 100);
                j.WriteLine("BB notu alan kisi sayisi:" + BB + " " + "%" + (double)BB / kisiSayisi * 100);
                j.WriteLine("CB notu alan kisi sayisi:" + CB + " " + "%" + (double)CB / kisiSayisi * 100);
                j.WriteLine("CC notu alan kisi sayisi:" + CC + " " + "%" + (double)CC / kisiSayisi * 100);
                j.WriteLine("DC notu alan kisi sayisi:" + DC + " " + "%" + (double)DC / kisiSayisi * 100);
                j.WriteLine("DD notu alan kisi sayisi:" + DD + " " + "%" + (double)DD / kisiSayisi * 100);
                j.WriteLine("FD notu alan kisi sayisi:" + FD + " " + "%" + (double)FD / kisiSayisi * 100);
                j.WriteLine("FF notu alan kisi sayisi:" + FF + " " + "%" + (double)FF / kisiSayisi * 100);
                j.WriteLine("Gecen ogrenci sayisi:" + (AA + BA + BB + CB + CC + DC + DD));
                j.WriteLine("Kalan ogrenci sayisi:" + (FF + FD)); //dosyaya yazma işlemleri

                j.Close();
                i.Close();
            }
           

            }
        }
    }


