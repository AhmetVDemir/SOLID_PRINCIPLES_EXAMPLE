/*

    3.1. LSP – Başlangıç Seviyesi Örneği: Araç Motoru Başlatma
        Basit bir örnekte, temel bir “Vehicle” sınıfı ve bu sınıftan türeyen “Car” sınıfı üzerinden, 
        temel sınıfın yerine türetilmiş sınıfın kullanılabileceğini gösteriyoruz.

*/


using System;

namespace LSP_Beginner
{
    public class Vehicle
    {
        // Motoru başlatan temel metod.
        public virtual void StartEngine()
        {
            Console.WriteLine("Motor çalıştırıldı.");
        }
    }

    public class Car : Vehicle
    {
        // Araca özgü motor başlatma işlemi.
        public override void StartEngine()
        {
            Console.WriteLine("Araba motoru çalıştırıldı.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Vehicle tipindeki referansa Car nesnesi atanıyor.
            Vehicle vehicle = new Car();
            vehicle.StartEngine(); // Beklenen şekilde "Araba motoru çalıştırıldı." çıktısı verir.
            Console.ReadLine();
        }
    }
}


/*

Adım Adım Açıklama:
Vehicle Sınıfı:
– Motor başlatma işlemini gerçekleştiren temel metodu tanımlar.

Car Sınıfı:
– Vehicle’dan türeyerek, kendine özgü motor başlatma işlemini uygular.

Program:
– Vehicle referansı üzerinden Car nesnesi kullanıldığında, LSP’ye uygun olarak doğru davranış sergilenir.

*/