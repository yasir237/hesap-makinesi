# Hesap Makinesi Projesi
Bu proje, `birinci sınıf bilgisayar mühendisliği öğrencisi olarak geliştirdiğim bir hesap makinesi uygulamasıdır`. Bu uygulama, kullanıcılara temel matematiksel işlemleri hızlı ve kolay bir şekilde gerçekleştirme imkanı sunar. Projeyi geliştirirken, arayüz tasarımında `Guna` adlı kütüphaneyi kullanarak `modern` ve `şık` bir kullanıcı deneyimi sağlamaya odaklandım.

<div align = center >
  <img src = 'https://github.com/user-attachments/assets/86c3f767-c0fe-4d66-9ac9-730d7fa6a886' >
</div>

## Arayüz ve Tasarım
Projede arayüz tasarımı için `Guna kütüphanesi` kullanılmıştır. Guna, .NET platformunda kullanılabilen bir UI kütüphanesidir ve modern, estetik tasarım bileşenleri sunar. Bu kütüphane sayesinde, uygulamanın arayüzü daha çekici ve kullanıcı dostu hale getirilmiştir. Guna'nın sağladığı hazır bileşenler ve temalar, uygulamanın profesyonel bir görünüme kavuşmasını sağlamıştır.

### Light Modu
Uygulamayı açtığınızda, **kullanıcı dostu** bir ekran ile karşılaşırsınız.
<div align = center >
  <img src = 'https://github.com/user-attachments/assets/9b10226a-15d0-4b32-a34d-5e6688107886' >
  <img src='https://github.com/user-attachments/assets/b1fb994e-ee00-400a-867c-868e8b71f0d8'>
</div>

### Dark Modu
**Gece modu** kullanıcıya sürekli bir rahatlık sunar. Dark mod etkinleştirildiğinde, `bu tercih uygulamayı kapatıp açılırsa bile korunur`. Böylece, kullanıcı her kullanımda göz yormayan ve şık bir arayüzle karşılaşır.
<div align = center >
  <img src = 'https://github.com/user-attachments/assets/a5e2aa92-da5f-4ab1-a2f6-53871a0a793c' >
  <img src ='https://github.com/user-attachments/assets/332cd571-131c-475d-9552-9a48279f89a5'>
</div>


### Bilimsel matematik işlemleri
Bu hesap makinesi, sadece temel dört işlemle sınırlı kalmaz. Bilimsel matematik işlemleri için ek butonlar sunar, böylece daha karmaşık hesaplamaları da hızlı ve kolay bir şekilde gerçekleştirebilirsiniz.
<div align = center >
  <img src ='https://github.com/user-attachments/assets/eca1e2cb-d759-4384-bf96-31952de1d8fe'>
  <img src = 'https://github.com/user-attachments/assets/0868fef0-6f06-491e-a7b9-15666f5e72af' >
</div>

## Özellikler

1. **Numerik Butonlar (0-9):** Bu butonlar rakamları ekrana ekler ve sayı girişlerini sağlar. Örneğin, "1" butonu tıklandığında ekrana "1" eklenir.

2. **CE/C Butonu:**
   - **CE:** Son girdiyi temizler. Genellikle son basılan rakamı veya işlemi kaldırır.
   - **C:** Tüm hesaplamayı sıfırlar ve ekranı temizler.

3. **İşlem Butonları (+, -, x, ÷, %):** Bu butonlar toplama, çıkarma, çarpma, bölme ve yüzde hesaplamaları yapar. Örneğin, "+" butonu iki sayıyı toplar.

4. **Eşittir ( = ):** Sonuç hesaplamasını tamamlar ve ekranda gösterir.

5. **Karekök ( √ ):** Bir sayının karekökünü hesaplar.

6. **Üs ( xʸ ):** Bir sayıyı başka bir sayıya üslü olarak hesaplar. Örneğin, 2^3 = 8.

7. **Pi ( π ):** Pi sayısını (3.14159...) hesaplamada kullanır.

8. **e ( Euler Sayısı):** Euler sayısını (2.71828...) hesaplamada kullanır.

9. **Negatif/pozitif ( + / - ):** Sayının işaretini değiştirir. Pozitif sayıyı negatif yapar veya negatif sayıyı pozitif yapar.

10. **Ondalık ( , ):** Sayıya ondalık işareti ekler.

11. **Küp ( x³ ):** Bir sayının küpünü hesaplar. Örneğin, 2³ = 8.

12. **Faktöriyel ( n! ):** Bir sayının faktöriyelini hesaplar. Örneğin, 5! = 120.

13. **Logaritma ( log ):** Sayının 10 tabanında logaritmasını hesaplar.
14. **Logaritma ( ln ):** Doğal logaritmanın (e tabanında) hesaplanmasını sağlar

15. **10 Üzeri x ( 10ˣ ):** 10'un bir üssünü hesaplar. Örneğin, 10² = 100.

16. **Mutlak Değer ( |x| ):** Sayının mutlak değerini hesaplar.

17. **Reciprocal ( 1/x ):** Bir sayının tersini hesaplar. Örneğin, 1/5 = 0.2.
18. **Üs Alarak ( exp ):** e tabanında üstel fonksiyon hesaplar. Örneğin, exp(1) ≈ 2.71828.

19. **Trigonometrik Fonksiyonlar (sin, cos, tan, cot):** Bu butonlar, trigonometrik fonksiyonları kullanarak matematiksel hesaplamalar yapar.
    - Sinüs (sin): Bir açının sinüs değerini hesaplar.
    - Kosinüs (cos): Bir açının kosinüs değerini hesaplar.
    - Tanjant (tan): Bir açının tanjant değerini hesaplar. 
    - Kotanjant (cot): Bir açının kotanjant değerini hesaplar. 

20. **Tema Değiştirme Butonu:** Uygulamanın karanlık ve açık temaları arasında geçiş yapar.

21. **Bilimsel Butonlar:** Sayısal hesaplamaların ötesinde daha gelişmiş matematiksel işlemler için kullanılan butonlardır.
22. **Geçmiş Hesaplar:** Hesaplamaların geçmişini kaydedip, kullanıcıya düzgün ve şık bir şekilde sunar. Bu sayede kullanıcı, yaptığı hesaplamaları geçmişte kolayca görebilir ve erişebilir.
23. **Silme Butonu:** Hesaplama ekranında en son girilen rakamı veya karakteri siler.

