/*

1.1. SRP – Başlangıç Seviyesi Örneği: Fatura İşlemleri
    Bu örnekte, fatura verisini tutan bir sınıf, fatura tutarını vergi oranıyla hesaplayan
    bir hesaplama sınıfı ve faturayı ekrana yazdıran ayrı bir sınıf kullanıyoruz. 
    Her sınıfın görevi ayrıdır.
*/
using System;

namespace SRP_Beginner
{
    // Fatura verilerini tutan sınıf; sadece veri barındırır.
    public class Invoice
    {
        public int InvoiceNumber { get; set; }
        public double Amount { get; set; }
    }

    // Fatura toplamını hesaplamak için ayrı sınıf.
    public class InvoiceCalculator
    {
        // Faturanın toplamını, vergi oranı uygulanarak hesaplar.
        public double CalculateTotal(Invoice invoice, double taxRate)
        {
            return invoice.Amount + (invoice.Amount * taxRate);
        }
    }

    // Faturayı ekrana yazdırma işlemini yapan sınıf.
    public class InvoicePrinter
    {
        public void PrintInvoice(Invoice invoice, double totalAmount)
        {
            Console.WriteLine("Fatura No: " + invoice.InvoiceNumber);
            Console.WriteLine("Tutar: " + invoice.Amount);
            Console.WriteLine("Vergi Dahil Toplam: " + totalAmount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Fatura nesnesi oluşturuluyor.
            Invoice invoice = new Invoice { InvoiceNumber = 1001, Amount = 200.0 };

            // Fatura hesaplama işlemi yapılır (örneğin %10 vergi).
            InvoiceCalculator calculator = new InvoiceCalculator();
            double total = calculator.CalculateTotal(invoice, 0.1);

            // Fatura bilgileri ekrana yazdırılır.
            InvoicePrinter printer = new InvoicePrinter();
            printer.PrintInvoice(invoice, total);

            Console.ReadLine();
        }
    }
}

/*

Adım Adım Açıklama:
Invoice Sınıfı:
– Fatura numarası ve tutarı gibi veriler burada tutulur.
– Sadece veri modelidir, hesaplama veya yazdırma gibi ek sorumlulukları yoktur.

InvoiceCalculator Sınıfı:
– Faturanın toplamını (vergi dahil) hesaplamak için ayrı bir sorumluluk üstlenir.
– Böylece fatura verisinin kendisi ile hesaplama işlemi ayrılmış olur.

InvoicePrinter Sınıfı:
– Fatura bilgilerini ekrana yazdırma görevini tek başına üstlenir.
– Böylece yazdırma işlemi, fatura verisi veya hesaplama ile karışmaz.

*/