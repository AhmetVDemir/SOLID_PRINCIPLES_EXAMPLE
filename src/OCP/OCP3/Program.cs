/*

    2.3. OCP – İleri Seviye Örneği: Eklenti Tabanlı Dosya İşleme Sistemi
        Bu örnekte, farklı dosya türlerini işleyebilen eklenti (plugin) tabanlı bir mimari görüyoruz. 
        Dosya işleyiciler (processor) ortak bir soyutlamaya göre oluşturulmuş; yeni dosya türleri eklendiğinde
        mevcut yöneticide herhangi bir değişiklik yapılmadan sistem genişletilebilir.


*/

using System;
using System.Collections.Generic;

namespace OCP_Advanced
{
    // Dosya bilgilerini tutan model.
    public class FileData
    {
        public string FileName { get; set; }
        public string Content { get; set; }
    }

    // Tüm dosya işleyiciler için ortak soyut sınıf.
    public abstract class FileProcessor
    {
        public abstract bool CanProcess(FileData file);
        public abstract void Process(FileData file);
    }

    // .txt dosyalarını işleyen sınıf.
    public class TextFileProcessor : FileProcessor
    {
        public override bool CanProcess(FileData file)
        {
            return file.FileName.EndsWith(".txt", StringComparison.OrdinalIgnoreCase);
        }
        public override void Process(FileData file)
        {
            Console.WriteLine($"Metin dosyası işleniyor: {file.FileName}");
            // .txt dosya işleme kodu burada yer alır.
        }
    }

    // .csv dosyalarını işleyen sınıf.
    public class CsvFileProcessor : FileProcessor
    {
        public override bool CanProcess(FileData file)
        {
            return file.FileName.EndsWith(".csv", StringComparison.OrdinalIgnoreCase);
        }
        public override void Process(FileData file)
        {
            Console.WriteLine($"CSV dosyası işleniyor: {file.FileName}");
            // .csv dosya işleme kodu burada yer alır.
        }
    }

    // Dosya işleyici yöneticisi; eklenecek yeni işlemcilerle genişletilebilir.
    public class FileProcessorManager
    {
        private List<FileProcessor> processors = new List<FileProcessor>();

        public void RegisterProcessor(FileProcessor processor)
        {
            processors.Add(processor);
        }

        public void ProcessFile(FileData file)
        {
            foreach (var processor in processors)
            {
                if (processor.CanProcess(file))
                {
                    processor.Process(file);
                    return;
                }
            }
            Console.WriteLine("Uygun dosya işleyici bulunamadı: " + file.FileName);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Dosya işleyici yöneticisi oluşturuluyor.
            FileProcessorManager manager = new FileProcessorManager();
            manager.RegisterProcessor(new TextFileProcessor());
            manager.RegisterProcessor(new CsvFileProcessor());

            // İşlenecek dosya örnekleri.
            FileData file1 = new FileData { FileName = "document.txt", Content = "Merhaba dünya!" };
            FileData file2 = new FileData { FileName = "data.csv", Content = "id,name\n1,Alice" };
            FileData file3 = new FileData { FileName = "image.png", Content = "..." };

            // Dosyalar işleniyor.
            manager.ProcessFile(file1);
            manager.ProcessFile(file2);
            manager.ProcessFile(file3);

            Console.ReadLine();
        }
    }
}


/*

Adım Adım Açıklama:
FileData:
– Dosya adı ve içeriğini tutan basit bir veri modeli.

FileProcessor Soyut Sınıfı:
– Tüm dosya işleyicilerin uygulaması gereken CanProcess ve Process metodlarını tanımlar.

Özel İşleyiciler (TextFileProcessor, CsvFileProcessor):
– Kendi dosya türlerine göre işleyebilme koşullarını ve işlemleri uygularlar.

FileProcessorManager:
– Kayıtlı işleyiciler arasında uygun olanı seçer. Yeni bir dosya türü eklendiğinde, sadece yeni bir işleyici sınıfı tanımlanıp manager’a eklenir; mevcut kodda değişiklik yapılmaz.
*/