/*
    1.3. SRP – İleri Seviye Örneği: Restoran Sipariş Yönetimi
        Bu örnekte, restoran sipariş yönetim sistemi senaryosu üzerinden; siparişin doğrulanması, toplam tutar hesaplanması, 
        ödeme alınması ve mutfağa bildirim gönderilmesi gibi farklı sorumluluklar ayrı sınıflara bölünmüştür.


*/

using System;
using System.Collections.Generic;

namespace SRP_Advanced
{
    // Menüdeki bir ürünü temsil eder.
    public class MenuItem
    {
        public string Name { get; set; }
        public double Price { get; set; }
    }

    // Restoran siparişini temsil eden sınıf.
    public class RestaurantOrder
    {
        public int TableNumber { get; set; }
        public List<MenuItem> Items { get; set; } = new List<MenuItem>();
    }

    // Siparişin geçerli olup olmadığını kontrol eden sınıf.
    public class OrderValidator
    {
        public bool Validate(RestaurantOrder order)
        {
            if (order == null)
                return false;
            if (order.TableNumber <= 0)
                return false;
            if (order.Items.Count == 0)
                return false;
            return true;
        }
    }

    // Siparişin toplam tutarını hesaplayan sınıf.
    public class OrderProcessor
    {
        public double CalculateTotal(RestaurantOrder order)
        {
            double total = 0;
            foreach (var item in order.Items)
            {
                total += item.Price;
            }
            return total;
        }
    }

    // Ödeme işlemini gerçekleştiren servis.
    public class PaymentService
    {
        public bool ProcessPayment(RestaurantOrder order, double amount)
        {
            Console.WriteLine($"Masa {order.TableNumber} için {amount:C} ödeme işleniyor.");
            // Gerçek ödeme işleme kodu burada yer alır.
            return true;
        }
    }

    // Mutfağa sipariş bilgisini gönderen sınıf.
    public class KitchenNotifier
    {
        public void NotifyKitchen(RestaurantOrder order)
        {
            Console.WriteLine($"Mutfağa bildirim: Masa {order.TableNumber} için {order.Items.Count} ürün siparişi var.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Restoran siparişi oluşturuluyor.
            RestaurantOrder order = new RestaurantOrder { TableNumber = 5 };
            order.Items.Add(new MenuItem { Name = "Burger", Price = 9.99 });
            order.Items.Add(new MenuItem { Name = "Patates Kızartması", Price = 3.99 });
            order.Items.Add(new MenuItem { Name = "Kola", Price = 1.99 });

            // Sipariş doğrulanıyor.
            OrderValidator validator = new OrderValidator();
            if (!validator.Validate(order))
            {
                Console.WriteLine("Sipariş geçersiz.");
                return;
            }

            // Siparişin toplam tutarı hesaplanıyor.
            OrderProcessor processor = new OrderProcessor();
            double total = processor.CalculateTotal(order);
            Console.WriteLine($"Toplam Sipariş Tutarı: {total:C}");

            // Ödeme işleniyor.
            PaymentService paymentService = new PaymentService();
            if (paymentService.ProcessPayment(order, total))
            {
                // Ödeme başarılı ise mutfak bilgilendiriliyor.
                KitchenNotifier notifier = new KitchenNotifier();
                notifier.NotifyKitchen(order);
            }
            Console.ReadLine();
        }
    }
}


/*
    Adım Adım Açıklama:
MenuItem & RestaurantOrder:
– Menü öğeleri ve restoran siparişine ait veriler tanımlanır.

OrderValidator:
– Siparişin geçerliliği (masa numarası, sipariş boş olmamalı vb.) kontrol edilir.

OrderProcessor:
– Siparişin toplam tutarı, listedeki her ürünün fiyatı toplanarak hesaplanır.

PaymentService:
– Belirtilen tutarın ödemesi simüle edilir.

KitchenNotifier:
– Ödeme sonrası mutfak bilgilendirilir.


*/