/*

    5.2. DIP – Orta Seviye Örneği: Müşteri Servisi ile Veri Erişimi
        Bu örnekte, müşteri verilerine erişim için ICustomerRepository arayüzü kullanılarak, yüksek seviye müşteri servisinin
        somut veri erişim sınıfına bağlı olmaması sağlanır.

*/

using System;
using System.Collections.Generic;

namespace DIP_Intermediate
{
    public class Customer
    {
        public string Name { get; set; }
    }

    // Müşteri verilerine erişim için soyut arayüz.
    public interface ICustomerRepository
    {
        void Add(Customer customer);
        IEnumerable<Customer> GetAll();
    }

    // Bellek içi (in-memory) müşteri deposu.
    public class InMemoryCustomerRepository : ICustomerRepository
    {
        private readonly List<Customer> _customers = new List<Customer>();

        public void Add(Customer customer)
        {
            _customers.Add(customer);
            Console.WriteLine("Müşteri eklendi: " + customer.Name);
        }

        public IEnumerable<Customer> GetAll()
        {
            return _customers;
        }
    }

    // Müşteri servisinin, veri erişim için soyutlamaya bağımlı olması.
    public class CustomerService
    {
        private readonly ICustomerRepository _repository;
        public CustomerService(ICustomerRepository repository)
        {
            _repository = repository;
        }

        public void RegisterCustomer(string name)
        {
            Customer customer = new Customer { Name = name };
            _repository.Add(customer);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ICustomerRepository repository = new InMemoryCustomerRepository();
            CustomerService service = new CustomerService(repository);
            service.RegisterCustomer("Alice");
            Console.ReadLine();
        }
    }
}


/*
Adım Adım Açıklama:
ICustomerRepository:
– Müşteri verilerine erişim için gereken metotları tanımlar.

InMemoryCustomerRepository:
– Bellek içi veri deposu olarak ICustomerRepository arayüzünü uygular.

CustomerService:
– Veri erişimi için doğrudan somut sınıfa değil, soyut arayüze bağlıdır. Böylece farklı veri erişim yöntemleri entegre edilebilir.



*/