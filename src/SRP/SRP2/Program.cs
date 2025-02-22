/*

    1.2. SRP – Orta Seviye Örneği: E-Ticaret Sipariş İşlemleri
        Bu örnekte, bir siparişin doğrulanması, ödemesinin işlenmesi ve siparişe ait bildirimlerin gönderilmesi için ayrı sınıflar oluşturulmuştur. 
        Böylece her sınıf yalnızca tek bir işleve odaklanır.

*/

using System;

namespace SRP_Intermediate
{
    // Sipariş verilerini tutan sınıf.
    public class Order
    {
        public int OrderId { get; set; }
        public double OrderAmount { get; set; }
    }

    // Siparişin geçerliliğini kontrol eden sınıf.
    public class OrderValidator
    {
        public bool Validate(Order order)
        {
            if (order == null) return false;
            if (order.OrderAmount <= 0) return false;
            return true;
        }
    }

    // Ödeme işlemini gerçekleştiren sınıf.
    public class PaymentProcessor
    {
        public bool ProcessPayment(Order order)
        {
            Console.WriteLine("Sipariş ID'si " + order.OrderId + " için ödeme işleniyor.");
            // Gerçek ödeme işlemi burada simüle edilebilir.
            return true;
        }
    }

    // Sipariş sonrası müşteriye bildirim gönderen sınıf.
    public class OrderNotifier
    {
        public void Notify(Order order)
        {
            Console.WriteLine("Sipariş ID'si " + order.OrderId + " hakkında müşteri bilgilendirildi.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Order order = new Order { OrderId = 101, OrderAmount = 150.0 };

            // Siparişin doğruluğu kontrol ediliyor.
            OrderValidator validator = new OrderValidator();
            if (!validator.Validate(order))
            {
                Console.WriteLine("Geçersiz Sipariş!");
                return;
            }

            // Ödeme işlemi yapılıyor.
            PaymentProcessor paymentProcessor = new PaymentProcessor();
            if (paymentProcessor.ProcessPayment(order))
            {
                // Ödeme başarılı ise bildirim gönderiliyor.
                OrderNotifier notifier = new OrderNotifier();
                notifier.Notify(order);
            }
            Console.ReadLine();
        }
    }
}


/*
    Adım Adım Açıklama:
Order Sınıfı:
– Siparişe ait temel verileri (sipariş numarası, tutar) tutar.

OrderValidator Sınıfı:
– Siparişin geçerli olup olmadığını kontrol eder.
– Sadece sipariş doğrulama sorumluluğu vardır.

PaymentProcessor Sınıfı:
– Ödeme işleme işlemini gerçekleştirir.
– Farklı ödeme yöntemleri eklenebilse de bu sınıf yalnızca “ödeme”yle ilgilenir.

OrderNotifier Sınıfı:
– Siparişle ilgili bildirim gönderme işlemini gerçekleştirir.
*/