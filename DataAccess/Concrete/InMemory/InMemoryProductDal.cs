using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.InMemory
{
    //Veriye ulaşma tekniklerimizin alternatifleri var ise klasörlemeye yönelmeliyiz bu yüzden Inmemory klasörünü oluşturduk.
    //Peki Inmemory nedir? 

    //Inmemory şuan için herhangi bir veritabanında çalışmayacağız sadece bellekte oluşturduğumuz veriler üzerinde çalışacağız demektir

    //Peki neden InmemoryProductDal

    //Interfaceler iş yapan sınıflarımızın operasyonlarını yazdığımız onların referansını tutan sınıflardır.
    //Dolayısıyla oluşturmuş olduğumuz, Product nesnesinin operasyonlarını tutan IProductDal'ın bir de İş yapan sınıfını Concrete de oluşturmalyız!!!!

    //InMemoryProductDal===>> InMemory kullandığımız veriye erişme teknolojisi yani bellek, Entity'de Product iş yapan sınıfımız,Dal DataAccessLayer

    //DataAccessLayer'ın Abstract ve Concretelerinde referans aldığımız Entity katmanındaki sınıfların dalları yazılır
    public class InMemoryProductDal : IProductDal //InmemoryProductDal bir IProductDal implementasyonu yani uygulamasıdır.
    {
        List<Product> _products; //Bu nesneyi bütün metotların dışında tanımladığımız için vermiş olduğumuz _products bir global değişkendir.Global olduğu için _ kullanmak bir yazım şeklidir

        //Oluşturmuş olduğumuz bu liste bir referans tiptir bu yüzdentek başına bir anlam ifade etmez sadece değişken oluşturur.Haydi o zaman bu nesne çağırıldığında çalışacak yapıcı metodu yazalım

        //Şimdi bellekte çalışacağımız içim kendi ürünlerimizi oluşturalım
        public InMemoryProductDal() //Bir Constructor oluşturduk, bellekte referans alınınca yani new lendiği anda otomatik olarak çalışacak.Peki içine ne yazacağız 
                                    //Direk çalışacak metot olduğundan burada ürünlerimizi oluşturacağız.
        {
            //Oracle,SQL Server, MongoDb, Postgres
            _products = new List<Product>() {
            new Product{ProductId=1,CategoryId=1,ProductName="Bardak",UnitPrice=15,UnitsInStock=15},
            new Product{ProductId=2,CategoryId=1,ProductName="Kamera",UnitPrice=500,UnitsInStock=3},
            new Product{ProductId=3,CategoryId=1,ProductName="Telefon",UnitPrice=1500,UnitsInStock=2},
            new Product{ProductId=4,CategoryId=1,ProductName="Klavye",UnitPrice=150,UnitsInStock=65},
            new Product{ProductId=5,CategoryId=1,ProductName="Fare",UnitPrice=85,UnitsInStock=1}
             //İşte şimdi yukarıda bellekte, sanki sqlden veri geliyormuş gibi veriler oluşturduk.
        

            };

        }

        public void Add(Product product) //Bir Add metodu oluşturuyoruz ve bu metot Product türünde bir product alır ve listeye ekler 
        {
            _products.Add(product); //Businesstan gelen product' ı veritabanına List<Product>'a ekliyorum 
        }

        public void Delete(Product product)  //DİKKAT!!!
        
            //İlk olarak şu kodun neden çalışmayacağına bakalım
            //_products.Remove(product); Bu kod biz her ne kadar product'ın bütün bilgilerini versek de Idsi name'i vs , hiçbir şekilde bu kodla silemeyiz Peki neden
            //Yukarıda yapıcı metotta ürünlerimizi newlediğimizde hepsinin bir referans numarası oluşur.Aynı şey silmek istediğimiz ürünü newlediğimiz zaman da oluşur ancak
            //dediğimiz gibi silmek istediğimiz ürün newlendiğinde kendine ait bir referans numarası oluşur ve bu referans numarası ürünlerin referansı ile aynı olmayacağından ürünler silinmez.

            //LİNQ Language Integrated Query Kullanımı
            {
                Product productToDelete = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //SingleOrDefault dolaşacağımız listeden tek bir eleman seçmek istediğimizde kullanılır
           //Her p için veritabanındaki ProductId sine bak ve benim gönderdiğim productın Id si ile eşleşiyor mu bak eşleşirse referansını productToDelete'ye ver.Artık silinecek verinin referansına ulaştık.


            _products.Remove(productToDelete);//Ve sildik...
        }

        public Product Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        public List<Product> GetAll() //Burada veritabanımı Business katmanıma return ediyorum
        {
            return _products;
        }

        public List<Product> GetAll(Expression<Func<Product, bool>> filter = null)
        {
            throw new NotImplementedException();
        }

        public void Update(Product product)
            //Girmiş olunan Product Id si Businestan gelen Product ıd si ile eşitse bunu productToUpdate e eşitle.
            //producToUpdate üzerinden Productların propertyleri güncellensin
        {
            //gönderilen product'ın Id si ile listedeki ürünün Id si eşleşen ürünü bul
            Product productToUpdate = _products.SingleOrDefault(p => p.ProductId == product.ProductId); //Bulduğum anda referansı artık yakalamış olurum
            productToUpdate.ProductName = product.ProductName;
            productToUpdate.CategoryId = product.CategoryId;
            productToUpdate.UnitPrice = product.UnitPrice;
            productToUpdate.UnitsInStock = product.UnitsInStock;
            //Gelen product ın bütün değerleri güncellenmiş oldu 

        }
        public List<Product> GetAllByCategoryId(int categoryId)
        {
            return _products.Where(p => p.CategoryId == categoryId).ToList(); // Yine LİNQ ile kolay bi şekilde yazdık sonuç olarak liste döndüreceği için de ToList e çevirdik.
        }

        List<Product> IEntityRepository<Product>.GetAll(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }

        Product IEntityRepository<Product>.Get(Expression<Func<Product, bool>> filter)
        {
            throw new NotImplementedException();
        }


    }
}
