/*

3.3. LSP – İleri Seviye Örneği: Şekil Hesaplama (Doğru Tasarlanmış)
    Bu örnekte, farklı şekillerin alanını hesaplamak için ortak bir arayüz (IShape) kullanıyoruz. 
    Tüm şekiller (Dikdörtgen, Daire, Kare) bu arayüzü uyguladıkları için, herhangi biri temel arayüz referansı ile sorunsuzca kullanılabilir.

*/

using System;

namespace LSP_Advanced
{
    // Tüm şekillerin uygulaması gereken ortak arayüz.
    public interface IShape
    {
        double GetArea();
    }

    public class Rectangle : IShape
    {
        public double Width { get; set; }
        public double Height { get; set; }

        public double GetArea()
        {
            return Width * Height;
        }
    }

    public class Circle : IShape
    {
        public double Radius { get; set; }

        public double GetArea()
        {
            return Math.PI * Radius * Radius;
        }
    }

    public class Square : IShape
    {
        public double Side { get; set; }
        public double GetArea()
        {
            return Side * Side;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IShape[] shapes = new IShape[]
            {
                new Rectangle { Width = 4, Height = 5 },
                new Circle { Radius = 3 },
                new Square { Side = 4 }
            };

            foreach (var shape in shapes)
            {
                Console.WriteLine($"Alan: {shape.GetArea():F2}");
            }
            Console.ReadLine();
        }
    }
}
/*

Adım Adım Açıklama:
IShape Arayüzü:
– Her şeklin alanını hesaplamak için uygulaması gereken metodu tanımlar.

Rectangle, Circle, Square:
– Her biri kendi alan hesaplamasını yapar ve IShape arayüzünü uygulayarak, birbirinin yerine geçebilir hale gelir.

Program:
– IShape dizisi üzerinden tüm şekillerin alanı hesaplanır; LSP’ye uygunluk sağlanır.

*/