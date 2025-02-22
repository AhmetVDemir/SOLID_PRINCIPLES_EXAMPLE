/*
    4.3. ISP – İleri Seviye Örneği: Belge İşlemleri
        Bu örnekte, belge yönetimi sisteminde farklı işlevleri (yazdırma, tarama, faks) ayrı arayüzlerle tanımlıyoruz. 
        Böylece, bir cihaz yalnızca desteklediği işlevleri uyguluyor.

*/

using System;

namespace ISP_Advanced
{
    // Belge yazdırma işlevini tanımlar.
    public interface IPrintable
    {
        void PrintDocument(string document);
    }

    // Belge tarama işlevini tanımlar.
    public interface IScannable
    {
        void ScanDocument(string document);
    }

    // Belge faks gönderme işlevini tanımlar.
    public interface IFaxable
    {
        void FaxDocument(string document);
    }

    // Tüm işlevleri destekleyen çok fonksiyonlu yazıcı.
    public class MultiFunctionPrinter : IPrintable, IScannable, IFaxable
    {
        public void PrintDocument(string document)
        {
            Console.WriteLine("Belge yazdırılıyor: " + document);
        }

        public void ScanDocument(string document)
        {
            Console.WriteLine("Belge taranıyor: " + document);
        }

        public void FaxDocument(string document)
        {
            Console.WriteLine("Belge fakslanıyor: " + document);
        }
    }

    // Sadece yazdırma yapabilen basit yazıcı.
    public class SimplePrinter : IPrintable
    {
        public void PrintDocument(string document)
        {
            Console.WriteLine("SimplePrinter yazdırıyor: " + document);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IPrintable printer = new SimplePrinter();
            printer.PrintDocument("Rapor.pdf");

            MultiFunctionPrinter mfp = new MultiFunctionPrinter();
            mfp.PrintDocument("Fatura.pdf");
            mfp.ScanDocument("Fatura.pdf");
            mfp.FaxDocument("Fatura.pdf");

            Console.ReadLine();
        }
    }
}


/*
Adım Adım Açıklama:
IPrintable, IScannable, IFaxable:
– Her biri, belge işlemlerinin farklı bir işlevini tanımlar.

MultiFunctionPrinter & SimplePrinter:
– MultiFunctionPrinter tüm işlevleri desteklerken, SimplePrinter yalnızca yazdırma işlevini uygular.

Program:
– Cihazların ihtiyaç duydukları arayüzlere göre ayrı implementasyonları yapılır; istemci, gereksiz metotlarla zorlanmaz.


*/