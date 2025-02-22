/*

3.2. LSP – Orta Seviye Örneği: Repository Tasarımı
    Bu örnekte, genel bir repository (depolama) soyutlaması ve bu soyutlamayı kullanan müşteri repository’si üzerinden LSP’nin 
    nasıl sağlandığını gösteriyoruz.

*/

using System;
using System.Collections.Generic;

namespace LSP_Intermediate
{
    // Genel repository için soyut sınıf.
    public abstract class Repository<T>
    {
        protected List<T> _data = new List<T>();

        public virtual void Add(T item)
        {
            _data.Add(item);
        }

        public virtual T Get(int index)
        {
            return _data[index];
        }
    }

    // Müşteri verilerini saklayan repository.
    public class CustomerRepository : Repository<Customer>
    {
        // Repository<T> içindeki davranışlar aynen kullanılır.
    }

    public class Customer
    {
        public string Name { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Repository<Customer> repo = new CustomerRepository();
            repo.Add(new Customer { Name = "Alice" });
            repo.Add(new Customer { Name = "Bob" });

            Customer c = repo.Get(0);
            Console.WriteLine("Müşteri: " + c.Name);
            Console.ReadLine();
        }
    }
}


/*

Adım Adım Açıklama:
Repository<T> Sınıfı:
– Genel veri depolama ve erişim operasyonlarını tanımlar.

CustomerRepository:
– Repository<Customer>’nın tüm özelliklerini devralır ve değiştirmeden kullanır.

Program:
– Repository arayüzü üzerinden müşteri verilerine erişim, LSP’nin temel gereksinimini karşılar.
*/