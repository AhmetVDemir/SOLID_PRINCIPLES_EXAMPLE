/*

5.3. DIP – İleri Seviye Örneği: .NET Core'un Yerleşik DI Konteyneri ile Bildirim Servisi
    Bu örnekte, Microsoft’un sağladığı DI (Dependency Injection) altyapısını kullanarak, yüksek seviye modülün (NotificationService)
     mesaj gönderme işlevini soyutlama (IMessageService) üzerinden almasını sağlıyoruz. Böylece, mesaj gönderme yöntemi (ör. e-posta, SMS)
      kolayca değiştirilebilir.
*/

using System;
using Microsoft.Extensions.DependencyInjection;

namespace DIP_Advanced
{
    // Mesaj gönderme işlemini tanımlayan soyut arayüz.
    public interface IMessageService
    {
        void SendMessage(string message);
    }

    // E-posta ile mesaj gönderimi yapan sınıf.
    public class EmailService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("E-posta gönderildi: " + message);
        }
    }

    // SMS ile mesaj gönderimi yapan sınıf.
    public class SmsService : IMessageService
    {
        public void SendMessage(string message)
        {
            Console.WriteLine("SMS gönderildi: " + message);
        }
    }

    // Bildirim servisi, mesaj gönderme işlevi için IMessageService soyutlamasına bağımlıdır.
    public class NotificationService
    {
        private readonly IMessageService _messageService;
        public NotificationService(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public void Notify(string message)
        {
            _messageService.SendMessage(message);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // DI konteyneri kuruluyor.
            var serviceCollection = new ServiceCollection();

            // Hizmetler kaydediliyor.
            // Burada EmailService veya SmsService arasında kolayca seçim yapılabilir.
            serviceCollection.AddTransient<IMessageService, EmailService>();
            serviceCollection.AddTransient<NotificationService>();

            var serviceProvider = serviceCollection.BuildServiceProvider();

            // NotificationService, DI konteyneri üzerinden çözülüyor.
            var notifier = serviceProvider.GetService<NotificationService>();
            notifier.Notify("DIP ileri seviye örneğinden selamlar!");

            Console.ReadLine();
        }
    }
}

/*


*/