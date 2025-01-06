# Dünya Sağlık İstatistikleri Projesi

Bu projede [Kaggle](https://www.kaggle.com/)'da bulunan [Global Health Statistics](https://www.kaggle.com/datasets/malaiarasugraj/global-health-statistics) veri setini kullanarak bir dashboard sayfası hazırlandı. Veri setindeki 1.000.000 veri üzerinde sorgulamalar yapılarak istatistiksel analizler oluşturuldu.

## 📊 Dashboard

Dashboard, Türkiye ve dünya genelindeki sağlık verilerini görsel olarak kullanıcıya sunan interaktif bir arayüz sunmaktadır. Kullanıcıların sağlık verilerine kolay erişimini sağlamak amacıyla farklı widget'lar ve grafikler kullanılmıştır. 

**Dashboard üzerindeki başlıca veriler:**

🏥 Türkiye'de Görülen En Yaygın Hastalık, Türkiyede Bulunan En Yüksek Doktor Sayısı - Yılı, Şehirleşmeye Bağlı En Sık Görülen Hastalık Kategorileri gibi istatistik veriler belirtildi.

👩‍⚕️ Verilerin görselleştirilmesi grafikler kullanılarak sağlandı.

* Diyabet Hastalığının En Sık Görüldüğü Ülkeler

* Türkiyede Son 5 Yılda En Çok Görülen Hastalıklar

* Türkiye'deki En Yaygın Hastalıklar ve Ölüm Oranı farklı grafik türleri kullanılarak listelendi.

🌍 Dünyada en sık görülen hastalıklar ve hastalığa ait bilgiler tablo yapısı kullanılarak listelendi. 

## 🛠️ Kullanılan Teknolojiler

💻 **Asp.Net Core 6.0** kullanılarak geliştirilmiştir.

📦 **Dapper** veri tabanından veri çekmek ve işlemleri hızlı bir şekilde yapmak için kullanılan bir mikro ORM (Object-Relational Mapper) kütüphanesidir. Bu projede, veritabanı sorgularını optimize etmek amacıyla Dapper kullanılmıştır. Dapper, performans açısından oldukça hızlıdır ve SQL sorgularını doğrudan yazmak için esneklik sağlar.

🏗️ **Tek katmanlı yapı** prensibiyle geliştirilmiştir. Bu yapı, tüm iş mantığının tek bir katmanda toplanması ve basit bir veri akışı ile yönetilmesini sağlar.

📊 Verilerin görselleştirilmesi için **Chart.js** kullanılmıştır.

🔄 **Pagination (Sayfalama)** büyük veri setlerini daha yönetilebilir hale getirmek için kullanılan bir tekniktir. Sayfalama sayesinde, kullanıcılar yalnızca belirli bir sayfada gösterilen verileri görür ve bu da sayfa yüklenme sürelerini iyileştirir. 

🇹🇷 **Verilerin Türkçeleştirilmesi (Dictionary Sınıfı)**, veri setindeki İngilizce terimlerin Türkçeleştirilmesi için Dictionary sınıfı kullanılmıştır. 

📂 **Projede kullanılan veri seti**, **.csv** uzantılı bir dosyadan alınmıştır ve bu dosya, MSSQL Server veritabanına aktarılmıştır. Bu işlem, verilerin veritabanında daha verimli bir şekilde işlenmesi ve saklanması amacıyla yapılmıştır. CSV dosyaları, genellikle büyük veri setleriyle çalışırken kolayca dışa ve içe aktarılabilmesi nedeniyle tercih edilir.

## 🖼️ Görseller

![1](https://github.com/user-attachments/assets/297695ba-bb7e-4f06-9d02-d29aace8de38)
![2](https://github.com/user-attachments/assets/c971eef0-f266-49e2-8fcd-5d90586f9a7c)
![4](https://github.com/user-attachments/assets/2086fcb7-8581-4782-aebe-e829b1813faf)
![3](https://github.com/user-attachments/assets/6b6bf5f8-8f29-4fec-9342-a178e72634cf)
![sql](https://github.com/user-attachments/assets/9a94d5e6-ef66-4221-9785-abb841fc1ea3)




