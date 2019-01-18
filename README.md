# Genetic-Algorithm
C# ile genetik algoritma uygulaması(Yapay Zeka Proje Ödevi)

- 0<xn<1
- 3.5<a<4.0
- **Denklem** x(n+1)=x(n) * a * (1-x(n))
- **Problem**: Bir milyon tane 0 ve 1'den oluşan sayı dizisi oluşturulması gerekiyor.Bu 0 ve 1'lerin birbirlerine 
en yakın sayıda üretilmeleri isteniyor. Örneğin bir milyon tane üretilen sayılar içerisinde beşyüzbin 0 ve 
beşyüzbin 1 olması durumu en iyi durum anlamına geliyor. 
İlk 20 popülasyonda 0 ve 1'ler x(n+1)=x(n) * a * (1-x(n)) denklemine göre üretiliyor. Bu popülasyon içerisinden 
0 ve 1'lerin sayısı birbirine en yakın olan değer ile 20 popülasyon arasında rastgele birtanesi seçilip ikisi arasında 
çaprazlama işlemi gerçekleştiriliyor. Bu çaprazmalama sonucunda 20 tane çocuk oluşturuluyor. Bu çocuklar yine aynı denklem 
kullanılarak denklem sonucu 0.5 eşik değerinden küçük ise rastgele seçilen popülasyondan değeri alıyorum , büyük ise en iyi
fitness değerine sahip olan popülasyondan alıyorum. 
Eğer fitness değeri sürekli aynı çıkıyorsa mutasyon işlemi uyguluyorum.

# xn ve a değerleri 
![ekran alintisi](https://user-images.githubusercontent.com/24482512/51413527-54900800-1b80-11e9-95af-1df29e7cf236.PNG)

# 0'ların ve 1'lerin sayısı,Fitness değerleri, En iyi fitness ve rastgele fitness değerlerinin seçimi
![ekran alintisi1](https://user-images.githubusercontent.com/24482512/51413530-54900800-1b80-11e9-9400-e2da48781140.PNG)
