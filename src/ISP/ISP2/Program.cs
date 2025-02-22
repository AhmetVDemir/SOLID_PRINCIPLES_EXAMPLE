/*

    4.2. ISP – Orta Seviye Örneği: Çalışan Davranışları
        Bu örnekte, bir çalışanın (Employee) iş yapma, yemek yeme ve uyuma gibi farklı davranışlarını ayrı arayüzlerle tanımlıyoruz.
        Robot gibi bazı nesneler ise sadece çalışma işlevine ihtiyaç duyar.

*/

using System;

namespace ISP_Intermediate
{
    // Çalışma davranışını tanımlar.
    public interface IWork
    {
        void Work();
    }

    // Yemek yeme davranışını tanımlar.
    public interface IEat
    {
        void Eat();
    }

    // Uyuma davranışını tanımlar.
    public interface ISleep
    {
        void Sleep();
    }

    // Tam zamanlı çalışan; tüm davranışları uygular.
    public class Employee : IWork, IEat, ISleep
    {
        public void Work()
        {
            Console.WriteLine("Çalışan çalışıyor.");
        }

        public void Eat()
        {
            Console.WriteLine("Çalışan yemek yiyor.");
        }

        public void Sleep()
        {
            Console.WriteLine("Çalışan uyuyor.");
        }
    }

    // Sadece çalışması gereken robot.
    public class Robot : IWork
    {
        public void Work()
        {
            Console.WriteLine("Robot kesintisiz çalışıyor.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            IWork employeeWork = new Employee();
            employeeWork.Work();

            IWork robotWork = new Robot();
            robotWork.Work();

            Console.ReadLine();
        }
    }
}


/*


Adım Adım Açıklama:
IWork, IEat, ISleep:
– Her biri, belirli bir işlevi tanımlar.

Employee & Robot:
– Employee tüm işlevleri (çalışma, yemek, uyku) uygular; Robot ise sadece çalışma işlevini uygular.

Program:
– İstemciler, sadece ihtiyaç duydukları arayüzlere bağımlı kalır.



*/