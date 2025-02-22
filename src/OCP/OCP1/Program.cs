/*

    2.1. OCP – Başlangıç Seviyesi Örneği: Şekil Alan Hesaplama
        Bu örnekte, farklı şekillerin alanını hesaplamak için bir temel soyutlama (abstract class) kullanıyoruz. 
        Yeni bir şekil eklemek, mevcut hesaplama kodunu değiştirmeden yeni sınıf oluşturmakla mümkün olur.

*/

using System;

namespace OCP_Beginner
{
    // Tüm şekiller için ortak metodu tanımlayan soyut sınıf.
    public abstract class Shape
    {
        public abstract double CalculateArea();
    }

    // Dikdörtgen için alan hesaplaması.
    public class Rectangle : Shape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public override double CalculateArea()
        {
            return Width * Height;
        }
    }

    // Daire için alan hesaplaması.
    public class Circle : Shape
    {
        public double Radius { get; set; }

        public override double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Shape rect = new Rectangle { Width = 5, Height = 4 };
            Shape circle = new Circle { Radius = 3 };

            Console.WriteLine("Dikdörtgen Alanı: " + rect.CalculateArea());
            Console.WriteLine("Daire Alanı: " + circle.CalculateArea());
            Console.ReadLine();
        }
    }
}


/*
    Adım Adım Açıklama:
Shape Sınıfı:
– Tüm şekillerin ortak metodunu (CalculateArea) soyut olarak tanımlar.

Rectangle & Circle:
– Her biri kendi alan hesaplamasını gerçekleştirir.
– Yeni bir şekil eklemek için Shape sınıfından türetilip ilgili metodun uygulanması yeterlidir.


*/