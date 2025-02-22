/*
    4.1. ISP – Başlangıç Seviyesi Örneği: Yazıcı ve Tarayıcı
        Bu örnekte, yalnızca yazdırma işlevini destekleyen bir cihaz ile hem yazdırma hem tarama yapabilen
        çok fonksiyonlu cihaz arasında arayüz ayrımı yapıyoruz.

*/

using System;

namespace ISP_Beginner
{
    // Yalnızca yazdırma işlevini tanımlayan arayüz.
    public interface IPrinter
    {
        void Print(string content);
    }

    // Yalnızca tarama işlevini tanımlayan arayüz.
    public interface IScanner
    {
        void Scan(string content);
    }

    // Sadece yazdırma yapabilen cihaz.
    public class Printer : IPrinter
    {
        public void Print(string content)
        {
            Console.WriteLine("Yazdırılıyor: " + content);
        }
    }

    // Hem yazdırma hem tarama yapabilen cihaz.
    public class MultiFunctionDevice : IPrinter, IScanner
    {
        public void Print(string content)
        {
            Console.WriteLine("MultiDevice Yazdırıyor: " + content);
        }

        public void Scan(string content)
        {
            Console.WriteLine("MultiDevice Tarıyor: " + content);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPrinter printer = new Printer();
            printer.Print("Merhaba Dünya!");

            MultiFunctionDevice multiDevice = new MultiFunctionDevice();
            multiDevice.Print("Belge");
            multiDevice.Scan("Belge");

            Console.ReadLine();
        }
    }
}


/*
Adım Adım Açıklama:
IPrinter & IScanner Arayüzleri:
– Cihazların hangi işlevleri gerçekleştireceğini ayrı ayrı tanımlar.
– Böylece, yalnızca ihtiyacı olan metotları implement etmek yeterli olur.

Printer & MultiFunctionDevice:
– Printer sadece IPrinter’ı, MultiFunctionDevice ise hem IPrinter hem IScanner’ı uygular.

Program:
– Arayüzler sayesinde, cihazların gereksiz metotlarla “zorlanması” engellenir.

*/