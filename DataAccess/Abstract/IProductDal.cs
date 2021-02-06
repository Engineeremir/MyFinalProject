using Core.DataAccess;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Abstract
{
    //DataAccess bir nevi sql sorgularını yazdığımız katmandır

    //DataAccessLayer'ın Abstract ve Concretelerinde referans aldığımız Entity katmanındaki sınıfların dalları yazılır

    public interface IProductDal : IEntityRepository<Product> //İş yapan Product sınıfımızın Dal(DataAccessLayer)' ını burda yazacağız 
                                                              //Product ile ilgili yapacağım bütün operasyonlar (Add,Delete,Update,GetAll,..) burdaki interface'de yazılır 
    {
        // Interface metotları default olarak publictir.

        //------ÖNEMLİ----- ******Aşağıda yazmış olduğumuz kodlar GenericRepositoryDesignPatterni'ni kullanmadan önce idi artık aşağıdaki kodları yazmamıza gerek yok******
        //******Aşağıda yazmış olduğumuz kodlar GenericRepositoryDesignPatterni'ni kullanmadan önce idi artık aşağıdaki kodları yazmamıza gerek yok******


        //List<Product> GetAll(); //Product listesinin tamamını getir

        ////Yukarıda Product sınıfı başka bir katmandan gelecektir ve biz DataAccess olarak o katmana yani Entities katmanına bağımlı olduğumuzdan DataAccess e referans vermek zorundayız.

        ////Referansını verince yukarda using Entities.Concrete 'yi görmüş olacağız


        ////Şimdi Product classımız için farklı birkaç iş operasyonu daha yazlım

        //void Add(Product product); //Bir ekleme operasyonu oluşturduk ve parametre olarak Product tipinde bir değer almak zorundadır

        //void Update(Product product); //Bir güncelleme operasyonu oluşturduk ve parametre olarak Product tipinde bir değer almak zorundadır

        //void Delete(Product product); //Bir silme operasyonu oluşturduk ve parametre olarak Product tipinde bir değer almak zorundadır

        //List<Product> GetAllByCategoryId(int categoryId); //Product listesini, alınacak categoryId sine göre bize getirecek.

    }
}
