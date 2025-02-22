/*

    5.1. DIP – Başlangıç Seviyesi Örneği: Basit Loglama
            Bu örnekte, bir uygulamanın loglama işlemi için yüksek seviye modülün (Application) doğrudan somut bir loglama sınıfına bağlı olmaması için ILogger arayüzü kullanıyoruz.

*/

using System;

namespace DIP_Beginner
{
    // Yüksek seviye modülun kullandığı soyut loglama arayüzü.
    public interface ILogger
    {
        void Log(string message);
    }

    // Konsola loglama yapan somut sınıf.
    public class ConsoleLogger : ILogger
    {
        public void Log(string message)
        {
            Console.WriteLine("Console Logger: " + message);
        }
    }

    // Uygulama, loglama için ILogger soyutlamasına bağlıdır.
    public class Application
    {
        private readonly ILogger _logger;
        public Application(ILogger logger)
        {
            _logger = logger;
        }

        public void Run()
        {
            _logger.Log("Uygulama çalışıyor.");
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            ILogger logger = new ConsoleLogger();
            Application app = new Application(logger);
            app.Run();
            Console.ReadLine();
        }
    }
}


/*
    Adım Adım Açıklama:
ILogger Arayüzü:
– Loglama işlemi için gerekli metodu tanımlar.

ConsoleLogger:
– ILogger arayüzünü uygulayarak konsola loglama yapar.

Application:
– Loglama işlemi için somut bir sınıfa değil, soyutlamaya bağlıdır. Böylece loglama yöntemi değiştirilebilir.
*/