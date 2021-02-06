using Business.Abstract;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    //----ÖNEMLİ----> Business katmanının EntityFramework ile veya bellek ile veya herhangi biri ile işi yoktur
    //Business'ın tek bildiği IProductDal'dır


    //İş kodlarımızı buraya yazacağız.Manager iş katmanının somut kısmıdır.
    //IPrpductService ' yi işaretlemeyi unutmayalım

    public class ProductManager : IProductService //Artık IProductService 'nin iş kodlarını yazabilirim 
    {

        //İş kodları çalıştıktan sonra DataAccess' i çağırırız.Peki Şunu yaparsak ne olur
        //InMemoryProductDal inMemoryProductDal = new InMemoryProductDal(); 
        //Eğer yukarıda yazmış olduğum şekilde DataAccesi çağırırsak sadece bellekte ürettiğimiz veritabanını çağırmış oluruz.
        //Ancak biz farklı veritabanlarında da çalışacağımız için her metotta ayrı ayrı DataAccessimizi böyle çağıramayız.
        //Bir iş sınıfı başka sınıfları newlemez


        IProductDal _productDal; //ProductManager çağırıldığı anda Constructor IPorductDal referansı istiyor neden ? Metodun yanında açıklandı

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        public List<Product> GetAll()
        {
            //İş kodları var mı
            //İzin veriliyor mu yetkisi var mı 
            //Yukarıda bütün şartlar sağlandığında veritabanından GetAll metodu çalışacak

            return _productDal.GetAll(); //IProductDal ın referansıyla artık GetAll metodu çalıştı
        }

        public List<Product> GetAllByCategoryId(int id)
        {
            return _productDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitPrice(decimal min, decimal max)
        {
            return _productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}
