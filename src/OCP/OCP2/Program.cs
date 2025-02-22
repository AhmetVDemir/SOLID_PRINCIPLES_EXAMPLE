/*
    2.2. OCP – Orta Seviye Örneği: Ödeme İşlem Sistemi
        Bu örnekte, farklı ödeme yöntemleri için ortak bir soyutlama kullanarak ödeme işlemlerini gerçekleştiren yapıyı görüyoruz. 
        Yeni bir ödeme yöntemi eklemek, mevcut ödeme işleme kodunu değiştirmeden yeni sınıf oluşturmakla yapılır.

*/

using System;

namespace OCP_Intermediate
{
    // Tüm ödeme türleri için ortak soyut sınıf.
    public abstract class Payment
    {
        public abstract void ProcessPayment(double amount);
    }

    // Kredi kartı ile ödeme.
    public class CreditCardPayment : Payment
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Kredi kartı ile {amount:C} ödeme işleniyor.");
        }
    }

    // PayPal ile ödeme.
    public class PayPalPayment : Payment
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"PayPal ile {amount:C} ödeme işleniyor.");
        }
    }

    // Bitcoin ile ödeme.
    public class BitcoinPayment : Payment
    {
        public override void ProcessPayment(double amount)
        {
            Console.WriteLine($"Bitcoin ile {amount:C} ödeme işleniyor.");
        }
    }

    // Ödeme işlemini yöneten sınıf.
    public class PaymentProcessor
    {
        public void Process(Payment payment, double amount)
        {
            // Yeni ödeme türleri eklense bile bu metodda değişiklik yapmaya gerek yoktur.
            payment.ProcessPayment(amount);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            PaymentProcessor processor = new PaymentProcessor();

            Payment creditCard = new CreditCardPayment();
            Payment paypal = new PayPalPayment();
            Payment bitcoin = new BitcoinPayment();

            processor.Process(creditCard, 100.0);
            processor.Process(paypal, 150.0);
            processor.Process(bitcoin, 200.0);

            Console.ReadLine();
        }
    }
}


/*

Adım Adım Açıklama:
Payment Sınıfı:
– Tüm ödeme türlerinin uygulaması gereken ProcessPayment metodunu tanımlar.

Farklı Ödeme Türleri:
– CreditCardPayment, PayPalPayment, BitcoinPayment sınıfları kendi ödeme işlemlerini gerçekleştirir.

PaymentProcessor:
– Soyutlama üzerinden ödeme işlemini gerçekleştirir; yeni ödeme türü eklenmesi durumunda bu sınıfın kodu değiştirilmez.


*/