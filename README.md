# SOLID_PRINCIPLES_EXAMPLE
bae solid principles examples

## 1  Single Responsibility Principle (SRP)
   ### Temel Fikir:
       -- Her sınıfın yalnızca bir sorumluluğu olmalı. Yani, bir sınıfın yalnızca tek bir değişiklik nedeni (reason to change) bulunmalıdır. Böylece kod bakımı ve genişletilmesi kolaylaşır.


## 2  Open/Closed Principle (OCP)
   ### Temel Fikir
       -- Yazılım bileşenleri (sınıflar, modüller) genişlemeye açık (yeni özellik eklenebilir) fakat değişime kapalı (mevcut kod değiştirilmemeli). Böylece mevcut sistemin stabilitesi korunurken, yeni işlevler eklenebilir.
## 3  Liskov Substitution Principle (LSP)
   ### Temel Fikir
       -- Türetilmiş sınıflar, temel sınıfların yerine geçebilmeli ve beklenen davranışı bozmayacak şekilde kullanılabilmelidir. Yani, temel sınıfın nesnesi yerine türetilmiş sınıfın nesnesi konulsa, sistem aynı şekilde çalışmalıdır.
## 4  Interface Segregation Principle (ISP)
  ### Temel Fikir
      -- İstemciler, kullanmadıkları metodları içeren geniş kapsamlı arayüzlere bağımlı olmamalıdır. Bunun yerine, daha küçük, özelleşmiş arayüzler kullanılmalıdır.
## 5  Dependency Inversion Principle (DIP)
  ### Temel Fikir
    -- Yüksek seviye modüller, düşük seviye modüllere bağlı olmamalıdır; her ikisi de soyutlamalara bağlı olmalıdır. Böylece, uygulamanın bağımlılıkları esnek ve değiştirilebilir olur.